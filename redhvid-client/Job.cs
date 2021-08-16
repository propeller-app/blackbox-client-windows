using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using Redhvid.Enums;
using Redhvid.Events;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Events;
using static Redhvid.Rpc.JobSpool;

namespace Redhvid
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
        /// Data associated with this job.
        /// </summary>
        private JobData jobData;

        /// <summary>
        /// The directory of video source files.
        /// </summary>
        private string path;

        /// <summary>
        /// RPC client used by the job.
        /// </summary>
        private JobSpoolClient client;

        /// <summary>
        /// Queue video data is written to as it arrived from ffMPEG.
        /// </summary>
        private ConcurrentQueue<byte[]> videoDataQueue;

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
        public event EventHandler<ConversionProgressEventArgs> TranscodeProgress;

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
        protected virtual void OnTranscodeProgress(ConversionProgressEventArgs e)
        {
            EventHandler<ConversionProgressEventArgs> handler = TranscodeProgress;
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
        /// <param name="reason">An exception that caused the job to be canceled</param>
        public void Cancel(Exception reason = null)
        {
            if(!cancellationTokenSource.IsCancellationRequested)
            {
                cancellationTokenSource.Cancel();
                OnJobCancelled(new JobCancelledEventArgs(reason));
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
            if(Status == JobStatus.Sleeping)
            {
                Task.Run(Finish);
            }
            return this;
        }

        /// <summary>
        /// Sets the source directory of the device containing the video files.
        /// </summary>
        /// <param name="path">The device directory path</param>
        /// <returns>This job</returns>
        public Job SetDevicePath(string path)
        {
            this.path = path;
            return this;
        }

        /// <summary>
        /// Sets the gRPC spooler client used to communicate with gRPC server.
        /// </summary>
        /// <param name="client">The spooler client to use</param>
        /// <returns>This job</returns>
        public Job SetSpoolClient(JobSpoolClient client)
        {
            this.client = client;
            return this;
        }

        /// <summary>
        /// Task that runs the job.
        /// </summary>
        /// <returns></returns>
        private void Run()
        {
            try
            {
                Clone();
                Transcode();

                if (jobData != null)
                {
                    Finish();
                }
            } 
            catch (OperationCanceledException)
            {
                Debug.WriteLine("Job exited before finishing.");
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

                Rpc.JobIdentifier newJob = client.GetNewJob(new Empty());
                JobId = newJob.JobId;

                Status = JobStatus.Cloning;
                List<string> filesToCopy = Utils.GetAllAccessibleFiles(this.path, "*.mp4");
                byte[] buffer = new byte[4096];
                DirectoryInfo tempDir = Utils.GetTempJobDirectory(this);
                foreach(FileInfo file in tempDir.GetFiles())
                    file.Delete();

                int i = 0;
                foreach(string file in filesToCopy) 
                {
                    ct.ThrowIfCancellationRequested();

                    string fileName = Path.GetFileName(file);
                    using Stream source = File.OpenRead(file);
                    using Stream destination = File.Create(Path.Combine(tempDir.FullName, fileName));

                    int count;
                    while ((count = source.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        ct.ThrowIfCancellationRequested();

                        decimal percentComplete = (decimal)destination.Length / (decimal)source.Length;
                        OnCloneProgress(new CloneProgressEventArgs(i + 1, fileName, filesToCopy.Count, percentComplete));

                        destination.Write(buffer, 0, count);
                    }
                    i++;
                }

                OnCloneComplete(new CloneCompleteEventArgs(filesToCopy.Count, tempDir));
            }
            catch (RpcException e)
            {
                Cancel(e);
            }
        }

        /// <summary>
        /// Starts the transcode job and runs upload in parallel.
        /// 
        /// As data comes in from ffMPEG a concurrent queue has bytes arrays enqueued onto it, the upload worker then dequeues and writes to the gRPC channel.
        /// </summary>
        /// <returns></returns>
        private void Transcode()
        {
            CancellationToken ct = cancellationTokenSource.Token;
            ct.ThrowIfCancellationRequested();

            Status = JobStatus.Transcoding;

            string[] inputVideos = Directory.GetFiles(Utils.GetTempJobDirectory(this).FullName);

            Task<IConversion> concatenate = FFmpeg.Conversions.FromSnippet.Concatenate(null, inputVideos);
            concatenate.Wait();
            IConversion conversion = concatenate.Result;

            conversion.AddParameter(Properties.Settings.Default.FFmpegFlags);
            conversion.AddParameter("-f mp4 -movflags frag_keyframe+empty_moov");
            conversion.PipeOutput();

            videoDataQueue = new ConcurrentQueue<byte[]>();
            conversion.OnVideoDataReceived += (object sender, VideoDataEventArgs e) =>
            {
                videoDataQueue.Enqueue(e.Data);
            };
            conversion.OnProgress += (object sender, ConversionProgressEventArgs e) => OnTranscodeProgress(e);

            Task upload = Task.Run(Upload, ct);
            Task convert = conversion.Start(ct);
            convert.Wait();

            OnTranscodeComplete(new TranscodeCompleteEventArgs());

            Status = JobStatus.Uploading;
            upload.Wait();
        }

        /// <summary>
        /// Dequeues from the concurrent queue containing video data provided by the transcode worker and writes it to the gRPC channel.
        /// </summary>
        private void Upload()
        {
            try
            {
                CancellationToken ct = cancellationTokenSource.Token;
                ct.ThrowIfCancellationRequested();

                while (Status == JobStatus.Transcoding || !videoDataQueue.IsEmpty)
                {
                    ct.ThrowIfCancellationRequested();
                    if (videoDataQueue.TryDequeue(out byte[] buffer))
                    {
                        client.Upload(new Rpc.VideoData()
                        {
                            JobId = JobId,
                            Content = ByteString.CopyFrom(buffer)
                        });
                        OnUploadProgress(new UploadProgressEventArgs());
                    }
                }

                OnUploadComplete(new UploadCompleteEventArgs());

                Status = JobStatus.Sleeping;
            }
            catch (RpcException e)
            {
                Cancel(e);
            }
        }

        /// <summary>
        /// Submits a command to the gRPC server to indicate that the job is completed along with customer data associated with the job.
        /// </summary>
        private void Finish()
        {
            try
            {
                DateTime expiresOn = DateTime.Now.AddDays(Properties.Settings.Default.JobExpiryDays);
                long expiresTimestamp = ((DateTimeOffset)expiresOn).ToUnixTimeSeconds();
                client.Flush(new Rpc.Job()
                {
                    JobId = JobId,
                    MachineId = Environment.MachineName,
                    Expires = (int)expiresTimestamp,
                    Customer = new Rpc.Job.Types.Customer()
                    {
                        FirstName = jobData.CustomerFirstName,
                        LastName = jobData.CustomerLastName,
                        Email = jobData.CustomerEmail
                    }
                });

                OnJobComplete(new JobCompleteEventArgs());

                Status = JobStatus.Complete;
            }
            catch (RpcException e)
            {
                Cancel(e);
            }
        }
    }
}
