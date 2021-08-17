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
            job.TranscodeComplete += TranscodeComplete;
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
                jobProgress.Value = (jobProgress.Value + 20) % (100 + 20);
                progressLabel.Text = $"Transcoding {e.Duration}";
            }));
        }

        public void TranscodeComplete(object sender, TranscodeCompleteEventArgs e)
        {
            Invoke(new Action(() =>
            {
                jobProgress.Value = 100;
                progressLabel.Text = $"Finishing";
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

        public new void Show()
        {
            BringToFront();
            Opacity = 100;
        }

        public new void Hide()
        {
            Opacity = 0;
        }

        private void TrayIconClick(object sender, MouseEventArgs e)
        {
            Show();
        }

        private void CloseButtonClick(object sender, EventArgs e)
        {
            Hide();
        }

        private void OpenJobProgressMenu(object sender, EventArgs e)
        {
            Show();
        }

        private void ExitButtonClick(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }

        private void OpenJobQueueMenu(object sender, EventArgs e)
        {
            JobQueueForm jobQueueForm = new();
            jobQueueForm.Show();
        }

        private void OpenJobHistoryMenu(object sender, EventArgs e)
        {
            JobHistoryForm jobHistoryForm = new();
            jobHistoryForm.Show();
        }

        private void OpenNewJobMenu(object sender, EventArgs e)
        {
            NewJobForm newJobForm = new();
            newJobForm.Show();
        }

        private void OpenSettingsMenu(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new();
            settingsForm.Show();
        }
    }
}
