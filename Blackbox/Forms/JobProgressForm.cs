using System;
using System.Windows.Forms;

namespace Blackbox
{
    public partial class JobProgressForm : Utils.RightBottomAlignedForm
    {
        public JobProgressForm()
        {
            InitializeComponent();
            AlignForm();
        }

        public new void Show()
        {
            Show(this, null);
        }

        public new void Hide()
        {
            Hide(this, null);
        }

        public void Show(object sender, EventArgs e)
        {
            if (!InvokeRequired)
            {
                BringToFront();
                Opacity = 100;
            }
            else
            {
                Invoke(new Action<object, EventArgs>(Show), sender, e);
            }
        }

        public void Hide(object sender, EventArgs e)
        {
            if (!InvokeRequired)
            {
                Opacity = 0;
            }
            else
            {
                Invoke(new Action<object, EventArgs>(Hide), sender, e);
            }
        }

        public void UpdateProgress(int percent)
        {
            if (!InvokeRequired)
            {
                jobProgress.Value = percent;
            }
            else
            {
                Invoke(new Action<int>(UpdateProgress), percent);
            }
        }

        public void UpdateStatus(string status)
        {
            if (!InvokeRequired)
            {
                progressLabel.Text = status;
            }
            else
            {
                Invoke(new Action<string>(UpdateStatus), status);
            }
        }

        public void UpdateNotification(string status)
        {
            if (!InvokeRequired)
            {
                userNotifyLabel.Text = status;
            }
            else
            {
                Invoke(new Action<string>(UpdateNotification), status);
            }
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
