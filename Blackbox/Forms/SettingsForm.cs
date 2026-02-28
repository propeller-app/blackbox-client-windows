using Blackbox.Client;
using Grpc.Net.Client;
using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Windows.Forms;
using Usb.Events;
using Xabe.FFmpeg;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            this.Load += SettingsForm_Load;
        }

        public void GetSettings()
        {
            hostInput.Text = Properties.Settings.Default.GrpcHost;
            portInput.Text = Properties.Settings.Default.GrpcPort.ToString();
            sslCheckBox.Checked = Properties.Settings.Default.GrpcSSL;
            expiryDaysInput.Text = Properties.Settings.Default.JobExpiryDays.ToString();
            explorerPreviewCheckBox.Checked = Properties.Settings.Default.Explorer;

            foreach (Device device in Properties.Settings.Default.Devices)
            {
                devicesListView.Items.Add(device.Id, device.Name, null);
            }

            if (Properties.Settings.Default.SelectedTemplateId != 0)
            {
                templateBox.SelectedValue = Properties.Settings.Default.SelectedTemplateId;
            }

            settingLoaded = true;
        }
        private void ApplySettings()
        {
            Properties.Settings.Default.GrpcHost = hostInput.Text;
            Properties.Settings.Default.GrpcPort = uint.Parse(portInput.Text);
            Properties.Settings.Default.GrpcSSL = sslCheckBox.Checked;
            Properties.Settings.Default.JobExpiryDays = int.Parse(expiryDaysInput.Text);
            Properties.Settings.Default.Explorer = explorerPreviewCheckBox.Checked;

            Properties.Settings.Default.Devices = new System.Collections.Generic.List<Device>();
            foreach (ListViewItem item in devicesListView.Items)
            {
                Properties.Settings.Default.Devices.Add(new Device(item.Name, item.Text));
            }

            if (templateBox.SelectedItem is TemplateItem selected)
            {
                Properties.Settings.Default.SelectedTemplateId = selected.Id;
            }
            else
            {
                Properties.Settings.Default.SelectedTemplateId = 1;
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

        public class TemplateItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public override string ToString()
            {
                return Name;
            }

        }

        private void PopulateTemplates(AuthClient authClient)
        {
            templateBox.Items.Clear();

            foreach (var item in Program.AuthClient.Templates)
            {
                templateBox.Items.Add(new TemplateItem
                {
                    Name = item.Name,
                    Id = item.Id,
                });
            }

            int storedId = Properties.Settings.Default.SelectedTemplateId;
            for (int i = 0; i < templateBox.Items.Count; i++)
            {
                if (templateBox.Items[i] is TemplateItem t && t.Id == storedId)
                {
                    templateBox.SelectedIndex = i;
                    break;
                }
            }
        }

        public class EncoderItem
        {
            public string Name { get; set; }
            public override string ToString()
            {
                return Name;
            }

        }

        private void PopulateEncodes()
        {
            encoderSelectionBox.Items.Clear();

            encoderSelectionBox.Items.Add(new EncoderItem
            {
                Name = "Automatic Selection"
            });

            foreach (string ffmpeg in Properties.Settings.Default.FFmpegFlavors)
            {
                encoderSelectionBox.Items.Add(new EncoderItem
                {
                    Name = ffmpeg
                });
            }

            string storedFlavor = Properties.Settings.Default.FlavorSelection;
            
            for (int i = 0; i < encoderSelectionBox.Items.Count; i++)
            {   
                Console.WriteLine($"Checking encoder item {i}: {encoderSelectionBox.Items[i]}");
                if (encoderSelectionBox.Items[i] is EncoderItem t && t.Name == storedFlavor)
                {
                    encoderSelectionBox.SelectedIndex = i;
                    break;
                }
            }

        }

        private async void SettingsForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (Program.AuthClient == null)
                {
                    string grpcUrl = Utils.GetGrpcUrl();
                    Program.AuthClient = new AuthClient(grpcUrl);
                }
                bool loggedIn = await Program.AuthClient.RefreshAsync();
                if (loggedIn)
                {
                    serverTab.Text = "My Account";
                    LoggedInUser.Text = $"Logged in as {Program.AuthClient.LoggedInEmail}";
                    int credits = Program.AuthClient.Credits;
                    decimal valueInPounds = credits / 1000m;
                    string valueHumanised = valueInPounds.ToString("N2");
                    CreditsRemaining.Text = $"You have {credits:N0} credits remaining, worth about £{valueHumanised}.";
                    PopulateTemplates(Program.AuthClient);
                    PopulateEncodes();


                    loginTable.Visible = false;
                    tableLayoutPanel2.Visible = false;
                    LoggedInTable.Visible = true;
                }
                else
                {
                    serverTab.Text = "Blackbox Login";
                    loginTable.Visible = true;
                    tableLayoutPanel2.Visible = true;
                    LoggedInTable.Visible = false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error refreshing login: {ex.Message}");
                loginTable.Visible = true;
            }
        }

        private async void loginButtonClick(object sender, EventArgs e)
        {
            string email = usernameInput.Text.Trim();
            string password = passwordInput.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string grpcUrl = Utils.GetGrpcUrl();
                var authClient = new AuthClient(grpcUrl);
                bool success = await authClient.LoginAsync(email, password);
                if (success)
                {
                    serverTab.Text = "My Account";
                    Program.AuthClient = authClient;
                    LoggedInUser.Text = $"Logged in as {Program.AuthClient.LoggedInEmail}";
                    int credits = Program.AuthClient.Credits;
                    decimal valueInPounds = credits / 1000m;
                    string valueHumanised = valueInPounds.ToString("N2");
                    CreditsRemaining.Text = $"You have {credits:N0} credits remaining, worth about £{valueHumanised}.";
                    PopulateTemplates(Program.AuthClient);
                    PopulateEncodes();

                    loginTable.Visible = false;
                    tableLayoutPanel2.Visible = false;
                    LoggedInTable.Visible = true;
                    passwordInput.Text = "";
                }
                else
                {
                    MessageBox.Show("❌ Login failed. Please check your credentials.");
                }
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to server: {ex.Message}", "Connection Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TemplateBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (templateBox.SelectedItem is TemplateItem selected)
            {
                Properties.Settings.Default.SelectedTemplateId = selected.Id;
                Properties.Settings.Default.Save();

                Console.WriteLine($"Template saved: {selected.Name} (ID: {Properties.Settings.Default.SelectedTemplateId})");
            }
        }

        private void EncodeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (encoderSelectionBox.SelectedItem is EncoderItem selected)
            {
                Properties.Settings.Default.FlavorSelection = selected.Name;
                Properties.Settings.Default.Save();

                Console.WriteLine($"Flavor saved: {selected.Name} (and in the settings: {Properties.Settings.Default.FlavorSelection})");
            }
        }


        private void LogOut_Click(object sender, EventArgs e)
        {
            TokenStore store = new TokenStore();
            store.Clear();
            Program.AuthClient = null;
            loginTable.Visible = true;
            serverTab.Text = "Blackbox Login";
            tableLayoutPanel2.Visible = true;
            LoggedInTable.Visible = false;
        }

        private void InstallFfmpeg_Click_1(object sender, EventArgs e)
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

        async private void BenchmarkEncoderButton_Click(object sender, EventArgs e)
        {
            BenchmarkEncoderButton.Enabled = false;
            InstallFfmpeg.Enabled = false;
            jobScreenBar1.Visible = true;
            try
            {
                jobScreenBar1.Style = ProgressBarStyle.Marquee;
                jobScreenBar1.MarqueeAnimationSpeed = 60;
                await Program.BenchmarkFlavors(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Benchmark failed: {ex.Message}");
            }
            finally
            {
                InstallFfmpeg.Enabled = true;
                BenchmarkEncoderButton.Enabled = true;
                jobScreenBar1.Visible = false;
                jobScreenBar1.Style = ProgressBarStyle.Blocks;
                jobScreenBar1.MarqueeAnimationSpeed = 0;
            }
        }

    }
}

