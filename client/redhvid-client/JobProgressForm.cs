using System;
using System.Drawing;
using System.Windows.Forms;

namespace Redhvid
{
    public partial class JobProgressForm : Form
    {
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

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Opacity = 100;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Opacity = 0;
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
            this.Opacity = 100;
        }

        private void settingsMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();
        }
    }
}
