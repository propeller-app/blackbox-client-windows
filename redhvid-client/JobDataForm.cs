using Redhvid.Events;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Redhvid
{
    public partial class JobDataForm : Form
    {

        private readonly Job job;
        public JobDataForm(Job job)
        {
            InitializeComponent();
            Location = Utils.GetTrayWindowLocation(this);

            this.job = job;
            job.CloneProgress += CloneProgress;
            job.CloneComplete += CloneComplete;
        }

        private void CloneProgress(object sender, CloneProgressEventArgs e)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    statusProgressBar.Value = (int)Math.Round(e.Percent * 100m);
                    statusLabel.Text = $"Cloning ({e.FileNum}/{e.FileTotal})";
                }));
            } catch(ObjectDisposedException)
            {
                Debug.WriteLine("Form was disposed of before events were fully un-subscribed.");
            }
        }

        private void CloneComplete(object sender, CloneCompleteEventArgs e)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    statusProgressBar.Value = 0;
                    statusProgressBar.Enabled = false;
                    statusLabel.Text = "Ready";
                }));
            } catch(ObjectDisposedException)
            {
                Debug.WriteLine("Form was disposed of before events were fully un-subscribed.");
            }
        }

        private void StartUpload(object sender, EventArgs e)
        {
            job.SetJobData(new JobData(firstNameTextBox.Text, lastNameTextBox.Text, emailTextBox.Text));

            Close();
            Program.ShowJobProgress();
        }

        private void CancelUpload(object sender, EventArgs e)
        {
            job.Cancel();

            Close();
        }

        private new void Close()
        {
            job.CloneProgress -= CloneProgress;
            job.CloneComplete -= CloneComplete;
            base.Close();
        }

        private void Validate(object sender, EventArgs e)
        {
            uploadButton.Enabled = firstNameTextBox.TextLength > 0 && lastNameTextBox.TextLength > 0 && emailTextBox.TextLength > 0;
        }
    }
}
