using Blackbox.Client.Events;
using System;

namespace Blackbox.Client
{
    public class JobWatcher
    {
        private static readonly int JobSteps = 3;
        public JobWatcher(Job job)
        {
            Job = job;
            Job.CloneProgress += CloneProgress;
            Job.CloneComplete += CloneComplete;
            Job.TranscodeProgress += TranscodeProgress;
            Job.TranscodeComplete += TranscodeComplete;
            Job.UploadProgress += UploadProgress;
            Job.UploadComplete += UploadComplete;
            Job.JobComplete += JobComplete;
        }

        public Job Job { get; }

        public event EventHandler<JobProgressEventArgs> JobProgress;

        protected virtual void OnJobProgress(JobProgressEventArgs e)
        {
            EventHandler<JobProgressEventArgs> handler = JobProgress;
            handler?.Invoke(this, e);
        }

        private void CloneProgress(object sender, CloneProgressEventArgs e)
        {
            int jobPercent = (int)Math.Ceiling((e.Percent * (1.0 / JobSteps)));
            OnJobProgress(new JobProgressEventArgs(e, jobPercent));
        }

        private void CloneComplete(object sender, CloneCompleteEventArgs e)
        {
            int jobPercent = (int)Math.Ceiling((double)100 / JobSteps);
            OnJobProgress(new JobProgressEventArgs(e, jobPercent));
        }

        private void TranscodeProgress(object sender, TranscodeProgressEventArgs e)
        {
            int jobPercent = (int)Math.Ceiling((e.Percent * (1.0 / JobSteps)) + 100 / JobSteps);
            OnJobProgress(new JobProgressEventArgs(e, jobPercent));
        }

        private void TranscodeComplete(object sender, TranscodeCompleteEventArgs e)
        {
            int jobPercent = (int)Math.Ceiling((double)200 / JobSteps);
            OnJobProgress(new JobProgressEventArgs(e, jobPercent));
        }

        private void UploadProgress(object sender, UploadProgressEventArgs e)
        {
            int jobPercent = (int)Math.Ceiling((e.Percent * (1.0 / JobSteps)) + 200 / JobSteps);
            OnJobProgress(new JobProgressEventArgs(e, jobPercent));
        }

        private void UploadComplete(object sender, UploadCompleteEventArgs e)
        {
            OnJobProgress(new JobProgressEventArgs(e, 100));
        }

        private void JobComplete(object sender, JobCompleteEventArgs e)
        {
            OnJobProgress(new JobProgressEventArgs(e, 100));
        }
    }
}
