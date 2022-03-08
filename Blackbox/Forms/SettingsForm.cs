using System;
using System.Windows.Forms;
using Usb.Events;

namespace Blackbox
{
    public partial class SettingsForm : Utils.RightBottomAlignedForm
    {
        private bool settingLoaded = false;

        public SettingsForm()
        {
            InitializeComponent();
            AlignForm();
            GetSettings();
        }

        public void GetSettings()
        {
            hostInput.Text = Properties.Settings.Default.GrpcHost;
            portInput.Text = Properties.Settings.Default.GrpcPort.ToString();
            sslCheckBox.Checked = Properties.Settings.Default.GrpcSSL;
            transcodeCheckBox.Checked = Properties.Settings.Default.TranscodingEnabled;
            transcodeFlags.Text = Properties.Settings.Default.FFmpegFlags;
            expiryDaysInput.Text = Properties.Settings.Default.JobExpiryDays.ToString();
            explorerPreviewCheckBox.Checked = Properties.Settings.Default.Explorer;

            foreach (Device device in Properties.Settings.Default.Devices)
            {
                devicesListView.Items.Add(device.Id, device.Name, null);
            }

            settingLoaded = true;
        }
        private void ApplySettings()
        {
            Properties.Settings.Default.GrpcHost = hostInput.Text;
            Properties.Settings.Default.GrpcPort = uint.Parse(portInput.Text);
            Properties.Settings.Default.GrpcSSL = sslCheckBox.Checked;
            Properties.Settings.Default.TranscodingEnabled = transcodeCheckBox.Checked;
            Properties.Settings.Default.FFmpegFlags = transcodeFlags.Text;
            Properties.Settings.Default.JobExpiryDays = int.Parse(expiryDaysInput.Text);
            Properties.Settings.Default.Explorer = explorerPreviewCheckBox.Checked;

            Properties.Settings.Default.Devices = new System.Collections.Generic.List<Device>();
            foreach (ListViewItem item in devicesListView.Items)
            {
                Properties.Settings.Default.Devices.Add(new Device(item.Name, item.Text));
            }

            Properties.Settings.Default.Save();
        }

        private void SettingChange(object sender, EventArgs e)
        {
            if (settingLoaded)
            {
                applyButton.Enabled = true;
            }
        }

        private void DigitOnlyInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CloseButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void ApplyButtonClick(object sender, EventArgs e)
        {
            applyButton.Enabled = false;
            ApplySettings();
        }

        private void AddDeviceClick(object sender, EventArgs e)
        {
            IUsbEventWatcher usbEventWatcher = new UsbEventWatcher();
            AddDeviceForm addDeviceForm = new();
            addDeviceForm.Left = Left + (Width / 2) - (addDeviceForm.Width / 2);
            addDeviceForm.Top = Top + (Height / 2) - (addDeviceForm.Height / 2);

            void HandleNewDeviceConnected(object sender, UsbDevice device) => Invoke(new Action(() =>
            {
                if (devicesListView.Items.ContainsKey(device.DeviceSystemPath))
                {
                    return;
                }

                DialogResult res = MessageBox.Show(
                    addDeviceForm,
                    $"Device '{device.DeviceName}' has been connected. Add to list of devices?",
                    "New Device Detected",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    devicesListView.Items.Add(device.DeviceSystemPath, device.DeviceName, null);
                    SettingChange(sender, e);
                }
                addDeviceForm.Close();
            }));

            usbEventWatcher.UsbDeviceAdded += HandleNewDeviceConnected;

            DialogResult res = addDeviceForm.ShowDialog();
            usbEventWatcher.UsbDeviceAdded -= HandleNewDeviceConnected;
        }

        private void RemoveDeviceClick(object sender, EventArgs e)
        {
            foreach (ListViewItem item in devicesListView.SelectedItems)
            {
                item.Remove();
            }
            SettingChange(sender, e);
        }
    }
}
