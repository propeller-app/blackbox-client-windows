using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Redhvid
{
    public partial class SettingsForm : Form
    {
        private readonly bool settingLoaded = false;

        public SettingsForm()
        {
            InitializeComponent();

            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(
                workingArea.Width - this.Width,
                workingArea.Height - this.Height
            );

            hostInput.Text = Properties.Settings.Default.GrpcHost;
            portInput.Text = Properties.Settings.Default.GrpcPort.ToString();
            sslCheckBox.Checked = Properties.Settings.Default.GrpcSSL;
            transcodeCheckBox.Checked = Properties.Settings.Default.TranscodingEnabled;
            transcodeFlags.Text = Properties.Settings.Default.FFmpegFlags;
            expiryDaysInput.Text = Properties.Settings.Default.JobExpiryDays.ToString();
            maxMessageSizeInput.Text = Properties.Settings.Default.MaxMessageSize.ToString();
            settingLoaded = true;
        }

        private void DigitOnlyInput(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CloseButtonClick(object sender, System.EventArgs e)
        {
            Close();
        }

        private void SettingChange(object sender, System.EventArgs e)
        {
            if(settingLoaded)
            {
                applyButton.Enabled = true;
            }

        }

        private void ApplyButtonClick(object sender, System.EventArgs e)
        {
            applyButton.Enabled = false;
            ApplySettings();
        }

        private void ApplySettings()
        {
            Properties.Settings.Default.GrpcHost = hostInput.Text;
            Properties.Settings.Default.GrpcPort = uint.Parse(portInput.Text);
            Properties.Settings.Default.GrpcSSL = sslCheckBox.Checked;
            Properties.Settings.Default.TranscodingEnabled = transcodeCheckBox.Checked;
            Properties.Settings.Default.FFmpegFlags = transcodeFlags.Text;
            Properties.Settings.Default.JobExpiryDays = int.Parse(expiryDaysInput.Text);
            Properties.Settings.Default.MaxMessageSize = uint.Parse(maxMessageSizeInput.Text);
            Properties.Settings.Default.Save();
        }
    }
}
