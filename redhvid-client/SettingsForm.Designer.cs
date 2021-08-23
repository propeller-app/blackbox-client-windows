
using System.Drawing;
using System.Windows.Forms;

namespace Redhvid
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.settingsTabControl = new System.Windows.Forms.TabControl();
            this.serverTab = new System.Windows.Forms.TabPage();
            this.serverSettingsPanel = new System.Windows.Forms.Panel();
            this.serverTestButton = new System.Windows.Forms.Button();
            this.sslCheckBox = new System.Windows.Forms.CheckBox();
            this.portInput = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.hostInput = new System.Windows.Forms.TextBox();
            this.hostLabel = new System.Windows.Forms.Label();
            this.transcodeTab = new System.Windows.Forms.TabPage();
            this.bytesLabel = new System.Windows.Forms.Label();
            this.maxMessageSizeInput = new System.Windows.Forms.TextBox();
            this.messageSizeLabel = new System.Windows.Forms.Label();
            this.transcodeFlagsLabel = new System.Windows.Forms.Label();
            this.transcodeFlags = new System.Windows.Forms.TextBox();
            this.transcodeCheckBox = new System.Windows.Forms.CheckBox();
            this.jobTab = new System.Windows.Forms.TabPage();
            this.expiryDaysInput = new System.Windows.Forms.TextBox();
            this.jobExpiryLabel = new System.Windows.Forms.Label();
            this.deviceTab = new System.Windows.Forms.TabPage();
            this.deviceRemoveButton = new System.Windows.Forms.Button();
            this.deviceAddButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.applyButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.settingsTabControl.SuspendLayout();
            this.serverTab.SuspendLayout();
            this.serverSettingsPanel.SuspendLayout();
            this.transcodeTab.SuspendLayout();
            this.jobTab.SuspendLayout();
            this.deviceTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsTabControl
            // 
            this.settingsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsTabControl.Controls.Add(this.serverTab);
            this.settingsTabControl.Controls.Add(this.transcodeTab);
            this.settingsTabControl.Controls.Add(this.jobTab);
            this.settingsTabControl.Controls.Add(this.deviceTab);
            this.settingsTabControl.Location = new System.Drawing.Point(12, 12);
            this.settingsTabControl.Name = "settingsTabControl";
            this.settingsTabControl.SelectedIndex = 0;
            this.settingsTabControl.Size = new System.Drawing.Size(490, 290);
            this.settingsTabControl.TabIndex = 0;
            // 
            // serverTab
            // 
            this.serverTab.Controls.Add(this.serverSettingsPanel);
            this.serverTab.Location = new System.Drawing.Point(4, 24);
            this.serverTab.Name = "serverTab";
            this.serverTab.Padding = new System.Windows.Forms.Padding(3);
            this.serverTab.Size = new System.Drawing.Size(482, 262);
            this.serverTab.TabIndex = 0;
            this.serverTab.Text = "Server";
            this.serverTab.UseVisualStyleBackColor = true;
            // 
            // serverSettingsPanel
            // 
            this.serverSettingsPanel.Controls.Add(this.serverTestButton);
            this.serverSettingsPanel.Controls.Add(this.sslCheckBox);
            this.serverSettingsPanel.Controls.Add(this.portInput);
            this.serverSettingsPanel.Controls.Add(this.portLabel);
            this.serverSettingsPanel.Controls.Add(this.hostInput);
            this.serverSettingsPanel.Controls.Add(this.hostLabel);
            this.serverSettingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serverSettingsPanel.Location = new System.Drawing.Point(3, 3);
            this.serverSettingsPanel.Name = "serverSettingsPanel";
            this.serverSettingsPanel.Padding = new System.Windows.Forms.Padding(10);
            this.serverSettingsPanel.Size = new System.Drawing.Size(476, 256);
            this.serverSettingsPanel.TabIndex = 0;
            // 
            // serverTestButton
            // 
            this.serverTestButton.Location = new System.Drawing.Point(357, 59);
            this.serverTestButton.Name = "serverTestButton";
            this.serverTestButton.Size = new System.Drawing.Size(106, 23);
            this.serverTestButton.TabIndex = 6;
            this.serverTestButton.Text = "Test Connection";
            this.serverTestButton.UseVisualStyleBackColor = true;
            // 
            // sslCheckBox
            // 
            this.sslCheckBox.AutoSize = true;
            this.sslCheckBox.Location = new System.Drawing.Point(13, 59);
            this.sslCheckBox.Name = "sslCheckBox";
            this.sslCheckBox.Size = new System.Drawing.Size(71, 19);
            this.sslCheckBox.TabIndex = 5;
            this.sslCheckBox.Text = "Use SSL?";
            this.sslCheckBox.UseVisualStyleBackColor = true;
            this.sslCheckBox.CheckedChanged += new System.EventHandler(this.SettingChange);
            // 
            // portInput
            // 
            this.portInput.Location = new System.Drawing.Point(395, 13);
            this.portInput.Name = "portInput";
            this.portInput.Size = new System.Drawing.Size(68, 23);
            this.portInput.TabIndex = 3;
            this.portInput.TextChanged += new System.EventHandler(this.SettingChange);
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(347, 16);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(32, 15);
            this.portLabel.TabIndex = 2;
            this.portLabel.Text = "Port:";
            // 
            // hostInput
            // 
            this.hostInput.Location = new System.Drawing.Point(54, 13);
            this.hostInput.Name = "hostInput";
            this.hostInput.Size = new System.Drawing.Size(210, 23);
            this.hostInput.TabIndex = 1;
            this.hostInput.TextChanged += new System.EventHandler(this.SettingChange);
            // 
            // hostLabel
            // 
            this.hostLabel.AutoSize = true;
            this.hostLabel.Location = new System.Drawing.Point(13, 16);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(35, 15);
            this.hostLabel.TabIndex = 0;
            this.hostLabel.Text = "Host:";
            // 
            // transcodeTab
            // 
            this.transcodeTab.Controls.Add(this.bytesLabel);
            this.transcodeTab.Controls.Add(this.maxMessageSizeInput);
            this.transcodeTab.Controls.Add(this.messageSizeLabel);
            this.transcodeTab.Controls.Add(this.transcodeFlagsLabel);
            this.transcodeTab.Controls.Add(this.transcodeFlags);
            this.transcodeTab.Controls.Add(this.transcodeCheckBox);
            this.transcodeTab.Location = new System.Drawing.Point(4, 24);
            this.transcodeTab.Name = "transcodeTab";
            this.transcodeTab.Padding = new System.Windows.Forms.Padding(10);
            this.transcodeTab.Size = new System.Drawing.Size(482, 262);
            this.transcodeTab.TabIndex = 1;
            this.transcodeTab.Text = "Transcoding";
            this.transcodeTab.UseVisualStyleBackColor = true;
            // 
            // bytesLabel
            // 
            this.bytesLabel.AutoSize = true;
            this.bytesLabel.Location = new System.Drawing.Point(210, 47);
            this.bytesLabel.Name = "bytesLabel";
            this.bytesLabel.Size = new System.Drawing.Size(38, 15);
            this.bytesLabel.TabIndex = 11;
            this.bytesLabel.Text = "bytes.";
            // 
            // maxMessageSizeInput
            // 
            this.maxMessageSizeInput.Location = new System.Drawing.Point(123, 44);
            this.maxMessageSizeInput.Name = "maxMessageSizeInput";
            this.maxMessageSizeInput.Size = new System.Drawing.Size(81, 23);
            this.maxMessageSizeInput.TabIndex = 10;
            this.maxMessageSizeInput.TextChanged += new System.EventHandler(this.SettingChange);
            this.maxMessageSizeInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitOnlyInput);
            // 
            // messageSizeLabel
            // 
            this.messageSizeLabel.AutoSize = true;
            this.messageSizeLabel.Location = new System.Drawing.Point(13, 47);
            this.messageSizeLabel.Name = "messageSizeLabel";
            this.messageSizeLabel.Size = new System.Drawing.Size(104, 15);
            this.messageSizeLabel.TabIndex = 9;
            this.messageSizeLabel.Text = "Max Message Size:";
            // 
            // transcodeFlagsLabel
            // 
            this.transcodeFlagsLabel.AutoSize = true;
            this.transcodeFlagsLabel.Location = new System.Drawing.Point(13, 84);
            this.transcodeFlagsLabel.Name = "transcodeFlagsLabel";
            this.transcodeFlagsLabel.Size = new System.Drawing.Size(37, 15);
            this.transcodeFlagsLabel.TabIndex = 8;
            this.transcodeFlagsLabel.Text = "Flags:";
            // 
            // transcodeFlags
            // 
            this.transcodeFlags.Location = new System.Drawing.Point(56, 84);
            this.transcodeFlags.Multiline = true;
            this.transcodeFlags.Name = "transcodeFlags";
            this.transcodeFlags.Size = new System.Drawing.Size(413, 165);
            this.transcodeFlags.TabIndex = 7;
            this.transcodeFlags.TextChanged += new System.EventHandler(this.SettingChange);
            // 
            // transcodeCheckBox
            // 
            this.transcodeCheckBox.AutoSize = true;
            this.transcodeCheckBox.Location = new System.Drawing.Point(13, 13);
            this.transcodeCheckBox.Name = "transcodeCheckBox";
            this.transcodeCheckBox.Size = new System.Drawing.Size(118, 19);
            this.transcodeCheckBox.TabIndex = 6;
            this.transcodeCheckBox.Text = "Use Transcoding?";
            this.transcodeCheckBox.UseVisualStyleBackColor = true;
            this.transcodeCheckBox.CheckedChanged += new System.EventHandler(this.SettingChange);
            // 
            // jobTab
            // 
            this.jobTab.Controls.Add(this.expiryDaysInput);
            this.jobTab.Controls.Add(this.jobExpiryLabel);
            this.jobTab.Location = new System.Drawing.Point(4, 24);
            this.jobTab.Name = "jobTab";
            this.jobTab.Padding = new System.Windows.Forms.Padding(10);
            this.jobTab.Size = new System.Drawing.Size(482, 262);
            this.jobTab.TabIndex = 3;
            this.jobTab.Text = "Job";
            this.jobTab.UseVisualStyleBackColor = true;
            // 
            // expiryDaysInput
            // 
            this.expiryDaysInput.Location = new System.Drawing.Point(129, 11);
            this.expiryDaysInput.Name = "expiryDaysInput";
            this.expiryDaysInput.Size = new System.Drawing.Size(24, 23);
            this.expiryDaysInput.TabIndex = 1;
            this.expiryDaysInput.TextChanged += new System.EventHandler(this.SettingChange);
            this.expiryDaysInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitOnlyInput);
            // 
            // jobExpiryLabel
            // 
            this.jobExpiryLabel.AutoSize = true;
            this.jobExpiryLabel.Location = new System.Drawing.Point(14, 14);
            this.jobExpiryLabel.Name = "jobExpiryLabel";
            this.jobExpiryLabel.Size = new System.Drawing.Size(175, 15);
            this.jobExpiryLabel.TabIndex = 0;
            this.jobExpiryLabel.Text = "Jobs will expire after            days.";
            // 
            // deviceTab
            // 
            this.deviceTab.Controls.Add(this.deviceRemoveButton);
            this.deviceTab.Controls.Add(this.deviceAddButton);
            this.deviceTab.Controls.Add(this.listView1);
            this.deviceTab.Location = new System.Drawing.Point(4, 24);
            this.deviceTab.Name = "deviceTab";
            this.deviceTab.Padding = new System.Windows.Forms.Padding(50);
            this.deviceTab.Size = new System.Drawing.Size(482, 262);
            this.deviceTab.TabIndex = 2;
            this.deviceTab.Text = "Devices";
            this.deviceTab.UseVisualStyleBackColor = true;
            // 
            // deviceRemoveButton
            // 
            this.deviceRemoveButton.Location = new System.Drawing.Point(404, 32);
            this.deviceRemoveButton.Name = "deviceRemoveButton";
            this.deviceRemoveButton.Size = new System.Drawing.Size(75, 23);
            this.deviceRemoveButton.TabIndex = 2;
            this.deviceRemoveButton.Text = "Remove";
            this.deviceRemoveButton.UseVisualStyleBackColor = true;
            // 
            // deviceAddButton
            // 
            this.deviceAddButton.Location = new System.Drawing.Point(404, 3);
            this.deviceAddButton.Name = "deviceAddButton";
            this.deviceAddButton.Size = new System.Drawing.Size(75, 23);
            this.deviceAddButton.TabIndex = 1;
            this.deviceAddButton.Text = "Add";
            this.deviceAddButton.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(395, 256);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // applyButton
            // 
            this.applyButton.Enabled = false;
            this.applyButton.Location = new System.Drawing.Point(427, 308);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 1;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.ApplyButtonClick);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(346, 308);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButtonClick);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.applyButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(514, 343);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.settingsTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Settings";
            this.TopMost = true;
            this.settingsTabControl.ResumeLayout(false);
            this.serverTab.ResumeLayout(false);
            this.serverSettingsPanel.ResumeLayout(false);
            this.serverSettingsPanel.PerformLayout();
            this.transcodeTab.ResumeLayout(false);
            this.transcodeTab.PerformLayout();
            this.jobTab.ResumeLayout(false);
            this.jobTab.PerformLayout();
            this.deviceTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl settingsTabControl;
        private System.Windows.Forms.TabPage serverTab;
        private System.Windows.Forms.TabPage transcodeTab;
        private System.Windows.Forms.TabPage deviceTab;
        private Panel serverSettingsPanel;
        private Label hostLabel;
        private Label portLabel;
        private TextBox hostInput;
        private Button serverTestButton;
        private CheckBox sslCheckBox;
        private TextBox portInput;
        private Button applyButton;
        private Button closeButton;
        private Button deviceRemoveButton;
        private Button deviceAddButton;
        private ListView listView1;
        private CheckBox transcodeCheckBox;
        private Label transcodeFlagsLabel;
        private TextBox transcodeFlags;
        private TabPage jobTab;
        private TextBox expiryDaysInput;
        private Label jobExpiryLabel;
        private Label bytesLabel;
        private TextBox maxMessageSizeInput;
        private Label messageSizeLabel;
    }
}