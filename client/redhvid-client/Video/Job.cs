using Grpc.Net.Client;
using System.IO;
using System.Threading.Tasks;

namespace Redhvid.Video
{
    class Job
    {
        public int number;
        public JobStatus status = JobStatus.Queued;

        private string path;

        public Job(int number, string path)
        {
            this.number = number;
            this.path = path;
        }

        public async Task Start()
        {
            await Clone();
        }

        public async Task Clone()
        {
            status = JobStatus.Cloning;

            string[] filesToCopy = Directory.GetFiles(this.path);
            foreach (string file in filesToCopy)
            {
                DirectoryInfo tempDir = Directory.CreateDirectory(Path.Combine(
                    Path.GetTempPath(),
                    "redh",
                    $"job_{number}"
                ));
                byte[] buffer = new byte[4096];
                using Stream source = File.OpenRead(file);
                using Stream destination = File.Create(Path.Combine(
                    tempDir.FullName,
                    Path.GetFileName(file)
                ));

                int count;
                while ((count = await source.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    await destination.WriteAsync(buffer, 0, count);
                }
            }
        }

        public async Task Transcode()
        {
            status = JobStatus.Transcoding;
            using GrpcChannel channel = GrpcChannel.ForAddress(Utils.GetGRPCUrl());
            FlightVideoDistributor.FlightVideoDistributorClient client =
                new FlightVideoDistributor.FlightVideoDistributorClient(channel);
        }

        public async Task Cancel()
        {

        }
    }
}
