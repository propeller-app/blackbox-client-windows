using System;

namespace Blackbox
{
    public partial class JobDataForm : Utils.RightBottomAlignedForm
    {
        public JobDataForm()
        {
            InitializeComponent();
            AlignForm();
        }

        public new void Show()
        {
            if (!InvokeRequired)
            {
                base.Show();
            }
            else
            {
                Invoke(new Action(Show));
            }
        }

        public new void Close()
        {
            if (!InvokeRequired)
            {
                base.Close();
            }
            else
            {
                Invoke(new Action(Close));
            }
        }

        public void UpdateProgress(int percent)
        {
            if (!InvokeRequired)
            {
                statusProgressBar.Value = percent;
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
                statusLabel.Text = status;
            }
            else
            {
                Invoke(new Action<string>(UpdateStatus), status);
            }
        }

        private void Validate(object sender, EventArgs e)
        {
            uploadButton.Enabled = firstNameTextBox.TextLength > 0 && lastNameTextBox.TextLength > 0 && emailTextBox.TextLength > 0;
        }

        private void JobDataForm_Load(object sender, EventArgs e)
        {

        }
    }
}
