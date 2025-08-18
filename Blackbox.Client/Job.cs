using Blackbox.Client.Enums;
using Blackbox.Client.Events;
using Blackbox.Client.Rpc;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Events;
using Xabe.FFmpeg.Exceptions;
using static Blackbox.Client.Rpc.Job.Types;
using static Blackbox.Client.Rpc.JobSpool;
using MediaDevices;

namespace Blackbox.Client
{
    public class Job
    {
        /// <summary>
        /// The identifier of this job issued by the server.
        /// </summary>
        public int JobId { get; private set; }

        /// <summary>
        /// The current state of this job.
        /// </summary>
        public JobStatus Status { get; private set; } = JobStatus.Queued;

        /// <summary>
        /// Array of source files which should be transcoded.
        /// </summary>
        public List<string> SourceFiles { get; private set; } = new List<string>();

        public MediaDevice MtpDevice { get; private set; } 

        /// <summary>
        /// Temporary directory to clone source files to.
        /// </summary>
        public DirectoryInfo TempDirectory { get; private set; }

        /// <summary>
        /// Custom flags to pass into ffmpeg.
        /// </summary>
        public string FfmpegFlags { get; private set; } = "";

        /// <summary>
        /// How long to inform server to keep video files for.
        /// </summary>
        public int JobExpiryDays { get; private set; } = 30;

        /// <summary>
        /// URL of gRPC server.
        /// </summary>
        public string GrpcUrl { get; private set; }

        /// <summary>
        /// Data associated with this job.
        /// </summary>
        private JobData jobData;

        /// <summary>
        /// RPC client used by the job.
        /// </summary>
        private JobSpoolClient client;

        /// <summary>
        /// Queue video data is written to as it arrived from ffMPEG.
        /// </summary>
        private BufferedVideoDataQueue videoDataQueue;

        /// <summary>
        /// Source of cancellation token used to stop the job.
        /// </summary>
        private CancellationTokenSource cancellationTokenSource;

        /// <summary>
        /// Event fired as cloning progresses.
        /// </summary>
        public event EventHandler<CloneProgressEventArgs> CloneProgress;

        /// <summary>
        /// Event fired when cloning is completed.
        /// </summary>
        public event EventHandler<CloneCompleteEventArgs> CloneComplete;

        /// <summary>
        /// Event fired when trancode progresses.
        /// </summary>
        public event EventHandler<TranscodeProgressEventArgs> TranscodeProgress;

        /// <summary>
        /// Event fired when transcode is completed.
        /// </summary>
        public event EventHandler<TranscodeCompleteEventArgs> TranscodeComplete;

        /// <summary>
        /// Event fired when upload progresses.
        /// </summary>
        public event EventHandler<UploadProgressEventArgs> UploadProgress;

        /// <summary>
        /// Event fired when upload is completed.
        /// </summary>
        public event EventHandler<UploadCompleteEventArgs> UploadComplete;

        /// <summary>
        /// Event fired when job is completed.
        /// </summary>
        public event EventHandler<JobCompleteEventArgs> JobComplete;

        /// <summary>
        /// Event fired when job is cancelled.
        /// </summary>
        public event EventHandler<JobCancelledEventArgs> JobCancelled;


        /// <summary>
        /// Fires the clone progress event.
        /// </summary>
        /// <param name="e">Clone progress event arguments</param>
        protected virtual void OnCloneProgress(CloneProgressEventArgs e)
        {
            EventHandler<CloneProgressEventArgs> handler = CloneProgress;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Fires the clone complete event.
        /// </summary>
        /// <param name="e">Clone complete event arguments</param>
        protected virtual void OnCloneComplete(CloneCompleteEventArgs e)
        {
            EventHandler<CloneCompleteEventArgs> handler = CloneComplete;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Fires the transcode progress event.
        /// </summary>
        /// <param name="e">Transcode progress event arguments</param>
        protected virtual void OnTranscodeProgress(TranscodeProgressEventArgs e)
        {
            EventHandler<TranscodeProgressEventArgs> handler = TranscodeProgress;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Fires the transcode complete event.
        /// </summary>
        /// <param name="e">Transcode complete event arguments</param>
        protected virtual void OnTranscodeComplete(TranscodeCompleteEventArgs e)
        {
            EventHandler<TranscodeCompleteEventArgs> handler = TranscodeComplete;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Fires the upload progress event.
        /// </summary>
        /// <param name="e">Upload progress event arguments.</param>
        protected virtual void OnUploadProgress(UploadProgressEventArgs e)
        {
            EventHandler<UploadProgressEventArgs> handler = UploadProgress;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Fires the upload complete event.
        /// </summary>
        /// <param name="e">Upload complete event arguments.</param>
        protected virtual void OnUploadComplete(UploadCompleteEventArgs e)
        {
            EventHandler<UploadCompleteEventArgs> handler = UploadComplete;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Fires the job complete event.
        /// </summary>
        /// <param name="e">Job complete event arguments.</param>
        protected virtual void OnJobComplete(JobCompleteEventArgs e)
        {
            EventHandler<JobCompleteEventArgs> handler = JobComplete;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Fires the job cancelled event.
        /// </summary>
        /// <param name="e">Job cancelled event arguments.</param>
        protected virtual void OnJobCancelled(JobCancelledEventArgs e)
        {
            EventHandler<JobCancelledEventArgs> handler = JobCancelled;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Starts the job.
        /// </summary>
        public void Start()
        {
            cancellationTokenSource = new();
            Task.Run(Run, cancellationTokenSource.Token);
        }

        /// <summary>
        /// Cancels the job and all of its sub-tasks.
        /// </summary>
        public void Cancel()
        {
            if (!cancellationTokenSource.IsCancellationRequested)
            {
                cancellationTokenSource.Cancel();
            }

            if (Status == JobStatus.Sleeping)
            {
                OnJobCancelled(new JobCancelledEventArgs());
            }
        }

        /// <summary>
        /// Sets the job customer data.
        /// 
        /// Wakes the job if it is in a sleeping state.
        /// </summary>
        /// <param name="jobData">The customer data for this job</param>
        /// <returns>This job</returns>
        public Job SetJobData(JobData jobData)
        {
            this.jobData = jobData;
            if (Status == JobStatus.Sleeping)
            {
                Task.Run(Finish);
            }
            return this;
        }

        /// <summary>
        /// Sets the source files to use for transcoding.
        /// </summary>
        /// <param name="sourceFiles">An array of strings representing source file paths.</param>
        /// <returns>This job.</returns>
        public Job SetSourceFiles(List<String> sourceFiles)
        {
            SourceFiles = sourceFiles;
            return this;
        }

        public Job SetMtpDevice(MediaDevice device)
        {
            MtpDevice = device;
            return this;
        }

        /// <summary>
        /// Sets the temporary clone directory.
        /// </summary>
        /// <param name="tempDirectory">Directory object representing directory.</param>
        /// <returns>This job.</returns>
        public Job SetTempDirectory(DirectoryInfo tempDirectory)
        {
            TempDirectory = tempDirectory;
            return this;
        }

        /// <summary>
        /// Sets the custom flags for ffmpeg.
        /// 
        /// This does not affect the required flags for uploading.
        /// </summary>
        /// <param name="ffmpegFlags">A string of flags.</param>
        /// <returns>This job.</returns>
        public Job SetFfmpegFlags(String ffmpegFlags)
        {
            FfmpegFlags = ffmpegFlags;
            return this;
        }

        /// <summary>
        /// Sets job expiry in days.
        /// </summary>
        /// <param name="jobExpiryDays">Number of days server should keep job for.</param>
        /// <returns>This job.</returns>
        public Job SetJobExpiryDays(int jobExpiryDays)
        {
            JobExpiryDays = jobExpiryDays;
            return this;
        }

        /// <summary>
        /// Sets the gRPC URL used to locate the gRPC server.
        /// </summary>
        /// <param name="grpcUrl">String representing the URL of the gRPC server.</param>
        /// <returns>This job.</returns>
        public Job SetGrpcUrl(String grpcUrl)
        {
            GrpcChannel channel = GrpcChannel.ForAddress(grpcUrl);
            client = new(channel);
            GrpcUrl = grpcUrl;
            return this;
        }

        /// <summary>
        /// Task that runs the job.
        /// </summary>
        /// <returns></returns>
        private void Run()
        {
            CancellationToken ct = cancellationTokenSource.Token;
            try
            {
                Task.Run(Heartbeat);
                Clone();
                ct.ThrowIfCancellationRequested();
                Transcode();
                ct.ThrowIfCancellationRequested();

                if (jobData != null)
                {
                    Finish();
                }
            }
            catch (Exception e)
            {
                OnJobCancelled(new JobCancelledEventArgs(e));
            }
            finally
            {
                Directory.Delete(TempDirectory.FullName, true);
            }
        }

        /// <summary>
        /// Sends heartbeat message every minute to indicate to server that job is still alive.
        /// </summary>
        private void Heartbeat()
        {
            try
            {
                CancellationToken ct = cancellationTokenSource.Token;
                while (Status != JobStatus.Complete && !ct.IsCancellationRequested)
                {
                    client.Heartbeat(new JobIdentifier()
                    {
                        JobId = JobId
                    });
                    Thread.Sleep(60 * 1000);
                }
            }
            catch (RpcException)
            {
                cancellationTokenSource.Cancel();
            }
        }

        /// <summary>
        /// Clones the video files from the set device path to a temporary folder on the local machine.
        /// </summary>
        private void Clone()
        {
            try
            {
                CancellationToken ct = cancellationTokenSource.Token;
                ct.ThrowIfCancellationRequested();

                JobIdentifier newJob = client.GetNewJob(new Empty());
                JobId = newJob.JobId;

                Status = JobStatus.Cloning;
                byte[] buffer = new byte[131072];

                if (MtpDevice is null)
                {
                    int i = 0;
                    foreach (string file in SourceFiles)
                    {
                        ct.ThrowIfCancellationRequested();

                        string fileName = Path.GetFileName(file);
                        using Stream source = File.OpenRead(file);
                        using Stream destination = File.Create(Path.Combine(TempDirectory.FullName, fileName));

                        int count;
                        while ((count = source.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            ct.ThrowIfCancellationRequested();

                            OnCloneProgress(new CloneProgressEventArgs(fileName, i, SourceFiles.Count, destination.Length, source.Length));

                            destination.Write(buffer, 0, count);
                        }
                        i++;
                    }
                }
                else
                {
                    // --- MTP device copy with progress ---
                    MtpDevice.Connect();

                    var root = MtpDevice.GetDirectoryInfo(@"\");
                    var mp4Files = root.EnumerateFiles("*.mp4", SearchOption.AllDirectories).ToList();

                    int i = 0;
                    foreach (var file in mp4Files)
                    {
                        ct.ThrowIfCancellationRequested();

                        string fileName = file.Name;
                        string destPath = Path.Combine(TempDirectory.FullName, fileName);

                        using FileStream destination = File.Create(destPath);

                        long totalLength = (long)file.Length;
                        long totalWritten = 0;

                        // Wrap destination to intercept progress
                        using Stream progressStream = new ProgressStream(destination, written =>
                        {
                            totalWritten = written;
                            ct.ThrowIfCancellationRequested();

                            OnCloneProgress(new CloneProgressEventArgs(
                                fileName,
                                i,
                                mp4Files.Count,
                                totalWritten,
                                totalLength));
                        });

                        MtpDevice.DownloadFile(file.FullName, progressStream);

                        i++;
                    }

                    MtpDevice.Disconnect();
                }

                int completedCount = (MtpDevice is null ? SourceFiles.Count : TempDirectory.GetFiles().Length);
                OnCloneComplete(new CloneCompleteEventArgs(completedCount, TempDirectory));
            }
            catch (Exception e) when (e is RpcException || e is IOException)
            {
                cancellationTokenSource.Cancel();
                throw;
            }
            catch (OperationCanceledException)
            {
                throw;
            }
        }

        private class ProgressStream : Stream
        {
            private readonly Stream inner;
            private readonly Action<long> progressAction;
            private long totalWritten;

            public ProgressStream(Stream inner, Action<long> progressAction)
            {
                this.inner = inner;
                this.progressAction = progressAction;
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                inner.Write(buffer, offset, count);
                totalWritten += count;
                progressAction(totalWritten);
            }

            // Forward everything else
            public override bool CanRead => inner.CanRead;
            public override bool CanSeek => inner.CanSeek;
            public override bool CanWrite => inner.CanWrite;
            public override long Length => inner.Length;
            public override long Position { get => inner.Position; set => inner.Position = value; }
            public override void Flush() => inner.Flush();
            public override int Read(byte[] buffer, int offset, int count) => inner.Read(buffer, offset, count);
            public override long Seek(long offset, SeekOrigin origin) => inner.Seek(offset, origin);
            public override void SetLength(long value) => inner.SetLength(value);
        }

        /// <summary>
        /// Starts the transcode job and runs upload in parallel.
        /// 
        /// As data comes in from ffMPEG a concurrent queue has bytes arrays enqueued onto it, the upload worker then dequeues and writes to the gRPC channel.
        /// </summary>
        private void Transcode()
        {
            try
            {
                string ffmpegFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ffmpeg");
                FFmpeg.SetExecutablesPath(ffmpegFolder);

                CancellationToken ct = cancellationTokenSource.Token;
                ct.ThrowIfCancellationRequested();

                Status = JobStatus.Transcoding;

                string[] inputVideos = Directory.GetFiles(TempDirectory.FullName);
                Task<IMediaInfo>[] tasks = inputVideos.Select(video => FFmpeg.GetMediaInfo(video)).ToArray();
                Task.WaitAll(tasks);
                TimeSpan totalDuration = tasks.Select(task => task.Result).Aggregate(new TimeSpan(), (acc, mi) => acc.Add(mi.Duration));

                var frameRates = tasks
                    .Select(task => task.Result.VideoStreams.FirstOrDefault()?.Framerate)
                    .Where(fps => fps > 0)
                    .ToList();

                double outputFrameRate = (double)(frameRates.Any() ? frameRates.Min() : 30);

                string outputFile = "pipe:stdout";

                Task<IConversion> converter = (inputVideos.Length > 1)
                    ? FFmpeg.Conversions.FromSnippet.Concatenate(outputFile, inputVideos)
                    : FFmpeg.Conversions.FromSnippet.Convert(inputVideos[0], outputFile);

                converter.Wait(ct);
                IConversion conversion = converter.Result;

                conversion.AddParameter(FfmpegFlags);
                conversion.AddParameter(Properties.Strings.RequiredFfmpegFlags);
                conversion.AddParameter("-r " + outputFrameRate);
                conversion.PipeOutput();

                //Console.WriteLine("Ffmpeg Command: " + conversion.Build()); // Writes the full ffmpeg command to console for debugging

                videoDataQueue = new BufferedVideoDataQueue();
                conversion.OnVideoDataReceived += (object sender, VideoDataEventArgs e) =>
                    videoDataQueue.Enqueue(e.Data);

                conversion.OnProgress += (object sender, ConversionProgressEventArgs e) =>
                    OnTranscodeProgress(new TranscodeProgressEventArgs(e.Duration, totalDuration));

                Task upload = Task.Run(Upload, ct);
                Task convert = conversion.Start(ct);
                convert.Wait();

                OnTranscodeComplete(new TranscodeCompleteEventArgs());

                Status = JobStatus.Uploading;
                upload.Wait();
            }
            catch (Exception e) when (e is RpcException || e is IOException || e is ConversionException || e is AggregateException)
            {
                cancellationTokenSource.Cancel();
                throw;
            }
            catch (OperationCanceledException)
            {
                throw;
            }

        }

        /// <summary>
        /// Dequeues from the concurrent queue containing video data provided by the transcode worker and writes it to the gRPC channel.
        /// </summary>
        private void Upload()
        {
            try
            {
                CancellationToken ct = cancellationTokenSource.Token;

                long bytesProcessed = 0;
                long bytesTotal = 0;
                JobStatus status;
                byte[] buffer = new byte[32 * 1024];
                while (!ct.IsCancellationRequested && ((status = Status) == JobStatus.Transcoding || !videoDataQueue.IsEmpty))
                {
                    int count = videoDataQueue.Dequeue(buffer);

                    if (count > 0)
                    {
                        client.Upload(new VideoData()
                        {
                            JobId = JobId,
                            Content = ByteString.CopyFrom(buffer, 0, count)
                        });
                        if (status == JobStatus.Uploading)
                        {
                            bytesProcessed += count;
                            if (bytesTotal == 0)
                            {
                                bytesTotal = bytesProcessed + videoDataQueue.Sum(bytes => (long)bytes.Length);
                            }
                            OnUploadProgress(new UploadProgressEventArgs(bytesTotal, bytesProcessed));
                        }
                    }
                }

                if (!ct.IsCancellationRequested)
                {
                    OnUploadComplete(new UploadCompleteEventArgs());

                    Status = JobStatus.Sleeping;
                }

            }
            catch (RpcException)
            {
                cancellationTokenSource.Cancel();
                throw;
            }
        }

        /// <summary>
        /// Submits a command to the gRPC server to indicate that the job is completed along with customer data associated with the job.
        /// </summary>
        private void Finish()
        {
            try
            {
                DateTime expiresOn = DateTime.Now.AddDays(JobExpiryDays);
                long expiresTimestamp = ((DateTimeOffset)expiresOn).ToUnixTimeSeconds();
                client.Flush(new Rpc.Job()
                {
                    JobId = JobId,
                    MachineId = Environment.MachineName,
                    Expires = (int)expiresTimestamp,
                    Customer = new Customer()
                    {
                        FirstName = jobData.CustomerFirstName,
                        LastName = jobData.CustomerLastName,
                        Email = jobData.CustomerEmail
                    }
                });

                OnJobComplete(new JobCompleteEventArgs());

                Status = JobStatus.Complete;
            }
            catch (RpcException)
            {
                cancellationTokenSource.Cancel();
                throw;
            }
        }
    }
}

