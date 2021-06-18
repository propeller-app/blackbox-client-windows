using System.Drawing;
using System.Windows.Forms;

namespace Redhvid
{
    public partial class SettingsForm : Form
    {
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
        }
    }
}
