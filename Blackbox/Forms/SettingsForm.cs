using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Windows.Forms;
using Usb.Events;

namespace Blackbox
{
    public partial class SettingsForm : Utils.RightBottomAlignedForm
    {
        private bool settingLoaded = false;
        private static ManagementEventWatcher pnpWatcher;

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
                if (applyButton.InvokeRequired)
                {
                    applyButton.Invoke(new Action(() => applyButton.Enabled = true));
                }
                else
                {
                    applyButton.Enabled = true;
                }
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
            string pnpQuery = "SELECT * FROM __InstanceCreationEvent " +
                              "WITHIN 2 " +
                              "WHERE TargetInstance ISA 'Win32_PnPEntity'";
            pnpWatcher = new ManagementEventWatcher(new WqlEventQuery(pnpQuery));

            AddDeviceForm addDeviceForm = new();

            pnpWatcher.EventArrived += (s, evt) =>
            {
                var instance = (ManagementBaseObject)evt.NewEvent["TargetInstance"];
                string name = instance["Name"]?.ToString() ?? "(Unknown)";
                string pnpId = instance["PNPDeviceID"]?.ToString();

                // Always marshal to the main form’s thread (this), not the AddDeviceForm
                if (!IsDisposed && InvokeRequired)
                {
                    BeginInvoke(new Action(() =>
                    {
                        if (addDeviceForm != null && !addDeviceForm.IsDisposed)
                        {
                            var res = MessageBox.Show(
                                addDeviceForm,
                                $"Device '{name}' has been connected. Add to list of devices?",
                                "New Device Detected",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

                            if (res == DialogResult.Yes)
                            {
                                devicesListView.Items.Add(pnpId, name, null);
                                SettingChange(sender, EventArgs.Empty);
                            }

                            // Close the AddDeviceForm safely
                            addDeviceForm.Close();
                        }
                    }));
                }

                pnpWatcher.Stop();
            };

            pnpWatcher.Start();
            addDeviceForm.Left = Left + (Width / 2) - (addDeviceForm.Width / 2);
            addDeviceForm.Top = Top + (Height / 2) - (addDeviceForm.Height / 2);

            addDeviceForm.ShowDialog();
        }


        private void RemoveDeviceClick(object sender, EventArgs e)
        {
            foreach (ListViewItem item in devicesListView.SelectedItems)
            {
                item.Remove();
            }
            SettingChange(sender, e);
        }

        private void InstallFfmpeg_Click(object sender, EventArgs e)
        {
            try
            {
                string scriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tools/Master.ps1");

                if (!File.Exists(scriptPath))
                {
                    MessageBox.Show("Script not found: " + scriptPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ProcessStartInfo psi = new ProcessStartInfo()
                {
                    FileName = "powershell.exe",
                    Arguments = $"-ExecutionPolicy Bypass -File \"{scriptPath}\"",
                    //Verb = "runas", // 🚨 This triggers the UAC prompt to run as Administrator
                    UseShellExecute = true,
                    CreateNoWindow = false
                };

                Process.Start(psi);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                if (ex.NativeErrorCode == 1223) // User clicked "No" on UAC
                {
                    MessageBox.Show("Administrator privileges are required to install FFmpeg.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

