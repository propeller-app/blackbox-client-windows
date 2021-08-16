using Redhvid.Events;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Xabe.FFmpeg.Events;

namespace Redhvid
{
    public partial class JobProgressForm : Form
    {
        Job job;

        public JobProgressForm()
        {
            InitializeComponent();

            trayIcon.Icon = Properties.Resources.AppIcon;
            trayIcon.Text = Properties.Resources.AppName;

            Rectangle workingArea = Screen.GetWorkingArea(this);
            Location = new Point(
                workingArea.Width - Width,
                workingArea.Height - Height
            );
        }
        public void SetJob(Job job)
        {
            this.job = job;
            job.CloneProgress += CloneProgress;
            job.TranscodeProgress += TranscodeProgress;
            job.JobComplete += JobComplete;
        }

        public void CloneProgress(object sender, CloneProgressEventArgs e)
        {
            Invoke(new Action(() =>
            {
                jobProgress.Value = (int)Math.Round((((e.FileNum - 1) + e.Percent) / e.FileTotal)*50);
                progressLabel.Text = $"Cloning ({e.FileNum}/{e.FileTotal})";
            }));
        }

        public void TranscodeProgress(object sender, ConversionProgressEventArgs e)
        {
            Invoke(new Action(() =>
            {
                jobProgress.Value = (jobProgress.Value + 10) % 100;
                progressLabel.Text = $"Transcoding {e.Duration}";
            }));
        }

        public void JobComplete(object sender, JobCompleteEventArgs e)
        {
            Invoke(new Action(() =>
            {
                jobProgress.Value = 0;
                progressLabel.Text = "Ready";
            }));

            job.CloneProgress -= CloneProgress;
            job.TranscodeProgress -= TranscodeProgress;
            job.JobComplete -= JobComplete;
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Opacity = 100;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Opacity = 0;
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }

        private void jobQueueMenuItem_Click(object sender, EventArgs e)
        {
            JobQueueForm jobQueueForm = new JobQueueForm();
            jobQueueForm.Show();
        }

        private void jobHistoryMenuItem_Click(object sender, EventArgs e)
        {
            JobHistoryForm jobHistoryForm = new JobHistoryForm();
            jobHistoryForm.Show();
        }

        private void newJobMenuItem_Click(object sender, EventArgs e)
        {
            NewJobForm newJobForm = new NewJobForm();
            newJobForm.Show();
        }

        private void jobProgressMenuItem_Click(object sender, EventArgs e)
        {
            Opacity = 100;
        }

        private void settingsMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new();
            settingsForm.Show();
        }
    }
}
