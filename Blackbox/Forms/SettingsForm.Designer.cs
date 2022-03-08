
using System.Windows.Forms;

namespace Blackbox
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.hostLabel = new System.Windows.Forms.Label();
            this.hostInput = new System.Windows.Forms.TextBox();
            this.serverTestButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.portLabel = new System.Windows.Forms.Label();
            this.portInput = new System.Windows.Forms.TextBox();
            this.sslCheckBox = new System.Windows.Forms.CheckBox();
            this.transcodeTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.transcodeCheckBox = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.transcodeFlagsLabel = new System.Windows.Forms.Label();
            this.transcodeFlags = new System.Windows.Forms.TextBox();
            this.jobTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.jobExpiryLabel = new System.Windows.Forms.Label();
            this.expiryDaysInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.explorerPreviewCheckBox = new System.Windows.Forms.CheckBox();
            this.deviceTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.devicesListView = new System.Windows.Forms.ListView();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.deviceAddButton = new System.Windows.Forms.Button();
            this.deviceRemoveButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.settingsTabControl.SuspendLayout();
            this.serverTab.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.transcodeTab.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.jobTab.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.deviceTab.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.settingsTabControl.Location = new System.Drawing.Point(3, 3);
            this.settingsTabControl.Name = "settingsTabControl";
            this.settingsTabControl.SelectedIndex = 0;
            this.settingsTabControl.Size = new System.Drawing.Size(380, 273);
            this.settingsTabControl.TabIndex = 0;
            // 
            // serverTab
            // 
            this.serverTab.Controls.Add(this.tableLayoutPanel2);
            this.serverTab.Location = new System.Drawing.Point(4, 24);
            this.serverTab.Name = "serverTab";
            this.serverTab.Padding = new System.Windows.Forms.Padding(3);
            this.serverTab.Size = new System.Drawing.Size(372, 245);
            this.serverTab.TabIndex = 0;
            this.serverTab.Text = "Server";
            this.serverTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.serverTestButton, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.sslCheckBox, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.22222F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(360, 233);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.hostLabel);
            this.flowLayoutPanel2.Controls.Add(this.hostInput);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(174, 29);
            this.flowLayoutPanel2.TabIndex = 0;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // hostLabel
            // 
            this.hostLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.hostLabel.AutoSize = true;
            this.hostLabel.Location = new System.Drawing.Point(3, 0);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(35, 29);
            this.hostLabel.TabIndex = 0;
            this.hostLabel.Text = "Host:";
            this.hostLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hostInput
            // 
            this.hostInput.Location = new System.Drawing.Point(44, 3);
            this.hostInput.Name = "hostInput";
            this.hostInput.Size = new System.Drawing.Size(126, 23);
            this.hostInput.TabIndex = 1;
            this.hostInput.TextChanged += new System.EventHandler(this.SettingChange);
            // 
            // serverTestButton
            // 
            this.serverTestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.serverTestButton.Location = new System.Drawing.Point(251, 38);
            this.serverTestButton.Name = "serverTestButton";
            this.serverTestButton.Size = new System.Drawing.Size(106, 23);
            this.serverTestButton.TabIndex = 6;
            this.serverTestButton.Text = "Test Connection";
            this.serverTestButton.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.Controls.Add(this.portLabel);
            this.flowLayoutPanel3.Controls.Add(this.portInput);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(183, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(174, 29);
            this.flowLayoutPanel3.TabIndex = 1;
            this.flowLayoutPanel3.WrapContents = false;
            // 
            // portLabel
            // 
            this.portLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(3, 0);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(32, 29);
            this.portLabel.TabIndex = 2;
            this.portLabel.Text = "Port:";
            this.portLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // portInput
            // 
            this.portInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.portInput.Location = new System.Drawing.Point(41, 3);
            this.portInput.Name = "portInput";
            this.portInput.Size = new System.Drawing.Size(129, 23);
            this.portInput.TabIndex = 3;
            this.portInput.TextChanged += new System.EventHandler(this.SettingChange);
            // 
            // sslCheckBox
            // 
            this.sslCheckBox.AutoSize = true;
            this.sslCheckBox.Location = new System.Drawing.Point(3, 38);
            this.sslCheckBox.Name = "sslCheckBox";
            this.sslCheckBox.Size = new System.Drawing.Size(71, 19);
            this.sslCheckBox.TabIndex = 5;
            this.sslCheckBox.Text = "Use SSL?";
            this.sslCheckBox.UseVisualStyleBackColor = true;
            this.sslCheckBox.CheckedChanged += new System.EventHandler(this.SettingChange);
            // 
            // transcodeTab
            // 
            this.transcodeTab.Controls.Add(this.tableLayoutPanel3);
            this.transcodeTab.Location = new System.Drawing.Point(4, 24);
            this.transcodeTab.Name = "transcodeTab";
            this.transcodeTab.Padding = new System.Windows.Forms.Padding(3);
            this.transcodeTab.Size = new System.Drawing.Size(372, 245);
            this.transcodeTab.TabIndex = 1;
            this.transcodeTab.Text = "Transcoding";
            this.transcodeTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.transcodeCheckBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel5, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 253F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(345, 228);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // transcodeCheckBox
            // 
            this.transcodeCheckBox.AutoSize = true;
            this.transcodeCheckBox.Location = new System.Drawing.Point(3, 3);
            this.transcodeCheckBox.Name = "transcodeCheckBox";
            this.transcodeCheckBox.Size = new System.Drawing.Size(118, 19);
            this.transcodeCheckBox.TabIndex = 6;
            this.transcodeCheckBox.Text = "Use Transcoding?";
            this.transcodeCheckBox.UseVisualStyleBackColor = true;
            this.transcodeCheckBox.CheckedChanged += new System.EventHandler(this.SettingChange);
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel5.AutoSize = true;
            this.flowLayoutPanel5.Controls.Add(this.transcodeFlagsLabel);
            this.flowLayoutPanel5.Controls.Add(this.transcodeFlags);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 28);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(339, 130);
            this.flowLayoutPanel5.TabIndex = 8;
            this.flowLayoutPanel5.WrapContents = false;
            // 
            // transcodeFlagsLabel
            // 
            this.transcodeFlagsLabel.AutoSize = true;
            this.transcodeFlagsLabel.Location = new System.Drawing.Point(3, 0);
            this.transcodeFlagsLabel.Name = "transcodeFlagsLabel";
            this.transcodeFlagsLabel.Size = new System.Drawing.Size(37, 15);
            this.transcodeFlagsLabel.TabIndex = 8;
            this.transcodeFlagsLabel.Text = "Flags:";
            // 
            // transcodeFlags
            // 
            this.transcodeFlags.Location = new System.Drawing.Point(46, 3);
            this.transcodeFlags.Multiline = true;
            this.transcodeFlags.Name = "transcodeFlags";
            this.transcodeFlags.Size = new System.Drawing.Size(283, 124);
            this.transcodeFlags.TabIndex = 7;
            this.transcodeFlags.TextChanged += new System.EventHandler(this.SettingChange);
            // 
            // jobTab
            // 
            this.jobTab.Controls.Add(this.tableLayoutPanel4);
            this.jobTab.Location = new System.Drawing.Point(4, 24);
            this.jobTab.Name = "jobTab";
            this.jobTab.Padding = new System.Windows.Forms.Padding(3);
            this.jobTab.Size = new System.Drawing.Size(372, 245);
            this.jobTab.TabIndex = 3;
            this.jobTab.Text = "Job";
            this.jobTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel6, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.explorerPreviewCheckBox, 0, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(352, 228);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.AutoSize = true;
            this.flowLayoutPanel6.Controls.Add(this.jobExpiryLabel);
            this.flowLayoutPanel6.Controls.Add(this.expiryDaysInput);
            this.flowLayoutPanel6.Controls.Add(this.label1);
            this.flowLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(188, 29);
            this.flowLayoutPanel6.TabIndex = 0;
            // 
            // jobExpiryLabel
            // 
            this.jobExpiryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.jobExpiryLabel.AutoSize = true;
            this.jobExpiryLabel.Location = new System.Drawing.Point(3, 0);
            this.jobExpiryLabel.Name = "jobExpiryLabel";
            this.jobExpiryLabel.Size = new System.Drawing.Size(112, 29);
            this.jobExpiryLabel.TabIndex = 0;
            this.jobExpiryLabel.Text = "Jobs will expire after";
            this.jobExpiryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // expiryDaysInput
            // 
            this.expiryDaysInput.Location = new System.Drawing.Point(121, 3);
            this.expiryDaysInput.MaxLength = 3;
            this.expiryDaysInput.Name = "expiryDaysInput";
            this.expiryDaysInput.Size = new System.Drawing.Size(24, 23);
            this.expiryDaysInput.TabIndex = 1;
            this.expiryDaysInput.TextChanged += new System.EventHandler(this.SettingChange);
            this.expiryDaysInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitOnlyInput);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(151, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "days.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // explorerPreviewCheckBox
            // 
            this.explorerPreviewCheckBox.AutoSize = true;
            this.explorerPreviewCheckBox.Location = new System.Drawing.Point(3, 38);
            this.explorerPreviewCheckBox.Name = "explorerPreviewCheckBox";
            this.explorerPreviewCheckBox.Size = new System.Drawing.Size(236, 19);
            this.explorerPreviewCheckBox.TabIndex = 1;
            this.explorerPreviewCheckBox.Text = "Show drive in explorer when connected.";
            this.explorerPreviewCheckBox.UseVisualStyleBackColor = true;
            this.explorerPreviewCheckBox.CheckedChanged += new System.EventHandler(this.SettingChange);
            // 
            // deviceTab
            // 
            this.deviceTab.Controls.Add(this.tableLayoutPanel5);
            this.deviceTab.Location = new System.Drawing.Point(4, 24);
            this.deviceTab.Name = "deviceTab";
            this.deviceTab.Padding = new System.Windows.Forms.Padding(3);
            this.deviceTab.Size = new System.Drawing.Size(372, 245);
            this.deviceTab.TabIndex = 2;
            this.deviceTab.Text = "Devices";
            this.deviceTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.35577F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.devicesListView, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.flowLayoutPanel7, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(352, 228);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // devicesListView
            // 
            this.devicesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.devicesListView.FullRowSelect = true;
            this.devicesListView.HideSelection = false;
            this.devicesListView.Location = new System.Drawing.Point(3, 3);
            this.devicesListView.Name = "devicesListView";
            this.devicesListView.Size = new System.Drawing.Size(259, 222);
            this.devicesListView.TabIndex = 0;
            this.devicesListView.UseCompatibleStateImageBehavior = false;
            this.devicesListView.View = System.Windows.Forms.View.List;
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.AutoSize = true;
            this.flowLayoutPanel7.Controls.Add(this.deviceAddButton);
            this.flowLayoutPanel7.Controls.Add(this.deviceRemoveButton);
            this.flowLayoutPanel7.Location = new System.Drawing.Point(268, 3);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Size = new System.Drawing.Size(81, 58);
            this.flowLayoutPanel7.TabIndex = 1;
            // 
            // deviceAddButton
            // 
            this.deviceAddButton.Location = new System.Drawing.Point(3, 3);
            this.deviceAddButton.Name = "deviceAddButton";
            this.deviceAddButton.Size = new System.Drawing.Size(75, 23);
            this.deviceAddButton.TabIndex = 1;
            this.deviceAddButton.Text = "Add";
            this.deviceAddButton.UseVisualStyleBackColor = true;
            this.deviceAddButton.Click += new System.EventHandler(this.AddDeviceClick);
            // 
            // deviceRemoveButton
            // 
            this.deviceRemoveButton.Location = new System.Drawing.Point(3, 32);
            this.deviceRemoveButton.Name = "deviceRemoveButton";
            this.deviceRemoveButton.Size = new System.Drawing.Size(75, 23);
            this.deviceRemoveButton.TabIndex = 2;
            this.deviceRemoveButton.Text = "Remove";
            this.deviceRemoveButton.UseVisualStyleBackColor = true;
            this.deviceRemoveButton.Click += new System.EventHandler(this.RemoveDeviceClick);
            // 
            // applyButton
            // 
            this.applyButton.Enabled = false;
            this.applyButton.Location = new System.Drawing.Point(84, 3);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 1;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.ApplyButtonClick);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(3, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButtonClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.settingsTabControl, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.78626F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(386, 314);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.applyButton);
            this.flowLayoutPanel1.Controls.Add(this.closeButton);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(221, 282);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(162, 29);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.applyButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(410, 338);
            this.Controls.Add(this.tableLayoutPanel1);
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
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.transcodeTab.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.jobTab.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.deviceTab.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.flowLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl settingsTabControl;
        private System.Windows.Forms.TabPage serverTab;
        private System.Windows.Forms.TabPage transcodeTab;
        private System.Windows.Forms.TabPage deviceTab;
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
        private ListView devicesListView;
        private CheckBox transcodeCheckBox;
        private Label transcodeFlagsLabel;
        private TextBox transcodeFlags;
        private TabPage jobTab;
        private TextBox expiryDaysInput;
        private Label jobExpiryLabel;
        private TableLayoutPanel tableLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel3;
        private FlowLayoutPanel flowLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel4;
        private FlowLayoutPanel flowLayoutPanel6;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel5;
        private FlowLayoutPanel flowLayoutPanel7;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private CheckBox explorerPreviewCheckBox;
    }
}