
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
            settingsTabControl = new TabControl();
            serverTab = new TabPage();
            LoggedInTable = new TableLayoutPanel();
            tableLayoutPanel9 = new TableLayoutPanel();
            CreditsRemaining = new Label();
            LoggedInUser = new Label();
            LogOut = new Button();
            tableLayoutPanel8 = new TableLayoutPanel();
            label2 = new Label();
            templateBox = new ComboBox();
            loginTable = new TableLayoutPanel();
            loginRequiredLabel = new Label();
            loginButton = new Button();
            tableLayoutPanel6 = new TableLayoutPanel();
            usernameInput = new TextBox();
            passwordInput = new TextBox();
            passwordLabel = new Label();
            usernameLabel = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            hostLabel = new Label();
            hostInput = new TextBox();
            flowLayoutPanel3 = new FlowLayoutPanel();
            portLabel = new Label();
            portInput = new TextBox();
            sslCheckBox = new CheckBox();
            serverTestButton = new Button();
            tableLayoutPanel7 = new TableLayoutPanel();
            transcodeTab = new TabPage();
            InstallFfmpeg = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            transcodeCheckBox = new CheckBox();
            flowLayoutPanel5 = new FlowLayoutPanel();
            transcodeFlagsLabel = new Label();
            transcodeFlags = new TextBox();
            jobTab = new TabPage();
            tableLayoutPanel4 = new TableLayoutPanel();
            flowLayoutPanel6 = new FlowLayoutPanel();
            jobExpiryLabel = new Label();
            expiryDaysInput = new TextBox();
            label1 = new Label();
            explorerPreviewCheckBox = new CheckBox();
            deviceTab = new TabPage();
            tableLayoutPanel5 = new TableLayoutPanel();
            devicesListView = new ListView();
            flowLayoutPanel7 = new FlowLayoutPanel();
            deviceAddButton = new Button();
            deviceRemoveButton = new Button();
            applyButton = new Button();
            closeButton = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            settingsTabControl.SuspendLayout();
            serverTab.SuspendLayout();
            LoggedInTable.SuspendLayout();
            tableLayoutPanel9.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            loginTable.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            transcodeTab.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            jobTab.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            flowLayoutPanel6.SuspendLayout();
            deviceTab.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            flowLayoutPanel7.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // settingsTabControl
            // 
            settingsTabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            settingsTabControl.Controls.Add(serverTab);
            settingsTabControl.Controls.Add(transcodeTab);
            settingsTabControl.Controls.Add(jobTab);
            settingsTabControl.Controls.Add(deviceTab);
            settingsTabControl.Location = new System.Drawing.Point(3, 3);
            settingsTabControl.Name = "settingsTabControl";
            settingsTabControl.SelectedIndex = 0;
            settingsTabControl.Size = new System.Drawing.Size(380, 273);
            settingsTabControl.TabIndex = 0;
            // 
            // serverTab
            // 
            serverTab.Controls.Add(LoggedInTable);
            serverTab.Controls.Add(loginTable);
            serverTab.Controls.Add(tableLayoutPanel2);
            serverTab.Location = new System.Drawing.Point(4, 24);
            serverTab.Name = "serverTab";
            serverTab.Padding = new Padding(3);
            serverTab.Size = new System.Drawing.Size(372, 245);
            serverTab.TabIndex = 0;
            serverTab.Text = "Server";
            serverTab.UseVisualStyleBackColor = true;
            // 
            // LoggedInTable
            // 
            LoggedInTable.ColumnCount = 1;
            LoggedInTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            LoggedInTable.Controls.Add(tableLayoutPanel9, 0, 0);
            LoggedInTable.Location = new System.Drawing.Point(5, 3);
            LoggedInTable.Name = "LoggedInTable";
            LoggedInTable.RowCount = 1;
            LoggedInTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            LoggedInTable.Size = new System.Drawing.Size(369, 233);
            LoggedInTable.TabIndex = 14;
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.ColumnCount = 1;
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.Controls.Add(CreditsRemaining, 0, 2);
            tableLayoutPanel9.Controls.Add(LoggedInUser, 0, 1);
            tableLayoutPanel9.Controls.Add(LogOut, 0, 4);
            tableLayoutPanel9.Controls.Add(tableLayoutPanel8, 0, 3);
            tableLayoutPanel9.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 5;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 10.6796112F));
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 89.32039F));
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Absolute, 94F));
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutPanel9.Size = new System.Drawing.Size(363, 218);
            tableLayoutPanel9.TabIndex = 0;
            // 
            // CreditsRemaining
            // 
            CreditsRemaining.Location = new System.Drawing.Point(3, 44);
            CreditsRemaining.Name = "CreditsRemaining";
            CreditsRemaining.Size = new System.Drawing.Size(357, 45);
            CreditsRemaining.TabIndex = 1;
            CreditsRemaining.Text = "Credits Remaining";
            // 
            // LoggedInUser
            // 
            LoggedInUser.AutoSize = true;
            LoggedInUser.Location = new System.Drawing.Point(3, 4);
            LoggedInUser.Name = "LoggedInUser";
            LoggedInUser.Size = new System.Drawing.Size(74, 15);
            LoggedInUser.TabIndex = 0;
            LoggedInUser.Text = "Logged in as";
            // 
            // LogOut
            // 
            LogOut.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LogOut.Location = new System.Drawing.Point(285, 191);
            LogOut.Name = "LogOut";
            LogOut.Size = new System.Drawing.Size(75, 23);
            LogOut.TabIndex = 2;
            LogOut.Text = "Log Out";
            LogOut.UseVisualStyleBackColor = true;
            LogOut.Click += LogOut_Click;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 1;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.Controls.Add(label2, 0, 0);
            tableLayoutPanel8.Controls.Add(templateBox, 0, 1);
            tableLayoutPanel8.Location = new System.Drawing.Point(3, 97);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 2;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 28.7356319F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 71.2643661F));
            tableLayoutPanel8.Size = new System.Drawing.Size(357, 87);
            tableLayoutPanel8.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(165, 15);
            label2.TabIndex = 0;
            label2.Text = "Current Template for Uploads:";
            // 
            // templateBox
            // 
            templateBox.FormattingEnabled = true;
            templateBox.Location = new System.Drawing.Point(3, 28);
            templateBox.Name = "templateBox";
            templateBox.Size = new System.Drawing.Size(278, 23);
            templateBox.TabIndex = 1;
            templateBox.SelectedIndexChanged += TemplateBox_SelectedIndexChanged;
            // 
            // loginTable
            // 
            loginTable.ColumnCount = 1;
            loginTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            loginTable.Controls.Add(loginRequiredLabel, 0, 0);
            loginTable.Controls.Add(loginButton, 0, 2);
            loginTable.Controls.Add(tableLayoutPanel6, 0, 1);
            loginTable.Location = new System.Drawing.Point(0, 121);
            loginTable.Name = "loginTable";
            loginTable.RowCount = 3;
            loginTable.RowStyles.Add(new RowStyle(SizeType.Percent, 30.434782F));
            loginTable.RowStyles.Add(new RowStyle(SizeType.Percent, 69.5652161F));
            loginTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            loginTable.Size = new System.Drawing.Size(372, 118);
            loginTable.TabIndex = 13;
            // 
            // loginRequiredLabel
            // 
            loginRequiredLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            loginRequiredLabel.AutoSize = true;
            loginRequiredLabel.Location = new System.Drawing.Point(3, 0);
            loginRequiredLabel.Name = "loginRequiredLabel";
            loginRequiredLabel.RightToLeft = RightToLeft.No;
            loginRequiredLabel.Size = new System.Drawing.Size(223, 27);
            loginRequiredLabel.TabIndex = 7;
            loginRequiredLabel.Text = "Login to Blackbox (required for uploads):";
            loginRequiredLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loginButton
            // 
            loginButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            loginButton.Location = new System.Drawing.Point(294, 93);
            loginButton.Name = "loginButton";
            loginButton.Size = new System.Drawing.Size(75, 22);
            loginButton.TabIndex = 12;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButtonClick;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 2;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 281F));
            tableLayoutPanel6.Controls.Add(usernameInput, 1, 0);
            tableLayoutPanel6.Controls.Add(passwordInput, 1, 1);
            tableLayoutPanel6.Controls.Add(passwordLabel, 0, 1);
            tableLayoutPanel6.Controls.Add(usernameLabel, 0, 0);
            tableLayoutPanel6.Location = new System.Drawing.Point(3, 30);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel6.Size = new System.Drawing.Size(360, 57);
            tableLayoutPanel6.TabIndex = 11;
            // 
            // usernameInput
            // 
            usernameInput.Location = new System.Drawing.Point(82, 3);
            usernameInput.Name = "usernameInput";
            usernameInput.Size = new System.Drawing.Size(275, 23);
            usernameInput.TabIndex = 8;
            // 
            // passwordInput
            // 
            passwordInput.Location = new System.Drawing.Point(82, 31);
            passwordInput.Name = "passwordInput";
            passwordInput.PasswordChar = '●';
            passwordInput.Size = new System.Drawing.Size(275, 23);
            passwordInput.TabIndex = 11;
            // 
            // passwordLabel
            // 
            passwordLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new System.Drawing.Point(2, 30);
            passwordLabel.Margin = new Padding(2);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new System.Drawing.Size(60, 25);
            passwordLabel.TabIndex = 10;
            passwordLabel.Text = "Password:";
            passwordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // usernameLabel
            // 
            usernameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new System.Drawing.Point(2, 2);
            usernameLabel.Margin = new Padding(2);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new System.Drawing.Size(63, 24);
            usernameLabel.TabIndex = 9;
            usernameLabel.Text = "Username:";
            usernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(flowLayoutPanel2, 0, 0);
            tableLayoutPanel2.Controls.Add(flowLayoutPanel3, 1, 0);
            tableLayoutPanel2.Controls.Add(sslCheckBox, 0, 1);
            tableLayoutPanel2.Controls.Add(serverTestButton, 1, 1);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel7, 0, 2);
            tableLayoutPanel2.Location = new System.Drawing.Point(6, 6);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new System.Drawing.Size(360, 69);
            tableLayoutPanel2.TabIndex = 7;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.Controls.Add(hostLabel);
            flowLayoutPanel2.Controls.Add(hostInput);
            flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new System.Drawing.Size(174, 29);
            flowLayoutPanel2.TabIndex = 0;
            flowLayoutPanel2.WrapContents = false;
            // 
            // hostLabel
            // 
            hostLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            hostLabel.AutoSize = true;
            hostLabel.Location = new System.Drawing.Point(3, 0);
            hostLabel.Name = "hostLabel";
            hostLabel.Size = new System.Drawing.Size(35, 29);
            hostLabel.TabIndex = 0;
            hostLabel.Text = "Host:";
            hostLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hostInput
            // 
            hostInput.Location = new System.Drawing.Point(44, 3);
            hostInput.Name = "hostInput";
            hostInput.Size = new System.Drawing.Size(126, 23);
            hostInput.TabIndex = 1;
            hostInput.TextChanged += SettingChange;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel3.AutoSize = true;
            flowLayoutPanel3.Controls.Add(portLabel);
            flowLayoutPanel3.Controls.Add(portInput);
            flowLayoutPanel3.Location = new System.Drawing.Point(183, 3);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new System.Drawing.Size(174, 29);
            flowLayoutPanel3.TabIndex = 1;
            flowLayoutPanel3.WrapContents = false;
            // 
            // portLabel
            // 
            portLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            portLabel.AutoSize = true;
            portLabel.Location = new System.Drawing.Point(3, 0);
            portLabel.Name = "portLabel";
            portLabel.Size = new System.Drawing.Size(32, 29);
            portLabel.TabIndex = 2;
            portLabel.Text = "Port:";
            portLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // portInput
            // 
            portInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            portInput.Location = new System.Drawing.Point(41, 3);
            portInput.Name = "portInput";
            portInput.Size = new System.Drawing.Size(129, 23);
            portInput.TabIndex = 3;
            portInput.TextChanged += SettingChange;
            // 
            // sslCheckBox
            // 
            sslCheckBox.AutoSize = true;
            sslCheckBox.Location = new System.Drawing.Point(3, 38);
            sslCheckBox.Name = "sslCheckBox";
            sslCheckBox.Size = new System.Drawing.Size(71, 19);
            sslCheckBox.TabIndex = 5;
            sslCheckBox.Text = "Use SSL?";
            sslCheckBox.UseVisualStyleBackColor = true;
            sslCheckBox.CheckedChanged += SettingChange;
            // 
            // serverTestButton
            // 
            serverTestButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            serverTestButton.Location = new System.Drawing.Point(251, 38);
            serverTestButton.Name = "serverTestButton";
            serverTestButton.Size = new System.Drawing.Size(106, 23);
            serverTestButton.TabIndex = 6;
            serverTestButton.Text = "Test Connection";
            serverTestButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 2;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Location = new System.Drawing.Point(3, 69);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 2;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Size = new System.Drawing.Size(174, 14);
            tableLayoutPanel7.TabIndex = 7;
            // 
            // transcodeTab
            // 
            transcodeTab.Controls.Add(InstallFfmpeg);
            transcodeTab.Controls.Add(tableLayoutPanel3);
            transcodeTab.Location = new System.Drawing.Point(4, 24);
            transcodeTab.Name = "transcodeTab";
            transcodeTab.Padding = new Padding(3);
            transcodeTab.Size = new System.Drawing.Size(372, 245);
            transcodeTab.TabIndex = 1;
            transcodeTab.Text = "Transcoding";
            transcodeTab.UseVisualStyleBackColor = true;
            // 
            // InstallFfmpeg
            // 
            InstallFfmpeg.Location = new System.Drawing.Point(9, 216);
            InstallFfmpeg.Name = "InstallFfmpeg";
            InstallFfmpeg.Size = new System.Drawing.Size(100, 23);
            InstallFfmpeg.TabIndex = 5;
            InstallFfmpeg.Text = "Install FFmpeg";
            InstallFfmpeg.UseVisualStyleBackColor = true;
            InstallFfmpeg.Click += InstallFfmpeg_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(transcodeCheckBox, 0, 0);
            tableLayoutPanel3.Controls.Add(flowLayoutPanel5, 0, 1);
            tableLayoutPanel3.Location = new System.Drawing.Point(6, 6);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 253F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new System.Drawing.Size(345, 171);
            tableLayoutPanel3.TabIndex = 4;
            // 
            // transcodeCheckBox
            // 
            transcodeCheckBox.AutoSize = true;
            transcodeCheckBox.Location = new System.Drawing.Point(3, 3);
            transcodeCheckBox.Name = "transcodeCheckBox";
            transcodeCheckBox.Size = new System.Drawing.Size(117, 19);
            transcodeCheckBox.TabIndex = 6;
            transcodeCheckBox.Text = "Use Transcoding?";
            transcodeCheckBox.UseVisualStyleBackColor = true;
            transcodeCheckBox.CheckedChanged += SettingChange;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel5.AutoSize = true;
            flowLayoutPanel5.Controls.Add(transcodeFlagsLabel);
            flowLayoutPanel5.Controls.Add(transcodeFlags);
            flowLayoutPanel5.Location = new System.Drawing.Point(3, 28);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new System.Drawing.Size(339, 130);
            flowLayoutPanel5.TabIndex = 8;
            flowLayoutPanel5.WrapContents = false;
            // 
            // transcodeFlagsLabel
            // 
            transcodeFlagsLabel.AutoSize = true;
            transcodeFlagsLabel.Location = new System.Drawing.Point(3, 0);
            transcodeFlagsLabel.Name = "transcodeFlagsLabel";
            transcodeFlagsLabel.Size = new System.Drawing.Size(37, 15);
            transcodeFlagsLabel.TabIndex = 8;
            transcodeFlagsLabel.Text = "Flags:";
            // 
            // transcodeFlags
            // 
            transcodeFlags.Location = new System.Drawing.Point(46, 3);
            transcodeFlags.Multiline = true;
            transcodeFlags.Name = "transcodeFlags";
            transcodeFlags.Size = new System.Drawing.Size(283, 124);
            transcodeFlags.TabIndex = 7;
            transcodeFlags.TextChanged += SettingChange;
            // 
            // jobTab
            // 
            jobTab.Controls.Add(tableLayoutPanel4);
            jobTab.Location = new System.Drawing.Point(4, 24);
            jobTab.Name = "jobTab";
            jobTab.Padding = new Padding(3);
            jobTab.Size = new System.Drawing.Size(372, 245);
            jobTab.TabIndex = 3;
            jobTab.Text = "Job";
            jobTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(flowLayoutPanel6, 0, 0);
            tableLayoutPanel4.Controls.Add(explorerPreviewCheckBox, 0, 1);
            tableLayoutPanel4.Location = new System.Drawing.Point(6, 6);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new RowStyle());
            tableLayoutPanel4.RowStyles.Add(new RowStyle());
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new System.Drawing.Size(352, 228);
            tableLayoutPanel4.TabIndex = 2;
            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.AutoSize = true;
            flowLayoutPanel6.Controls.Add(jobExpiryLabel);
            flowLayoutPanel6.Controls.Add(expiryDaysInput);
            flowLayoutPanel6.Controls.Add(label1);
            flowLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            flowLayoutPanel6.Size = new System.Drawing.Size(189, 29);
            flowLayoutPanel6.TabIndex = 0;
            // 
            // jobExpiryLabel
            // 
            jobExpiryLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            jobExpiryLabel.AutoSize = true;
            jobExpiryLabel.Location = new System.Drawing.Point(3, 0);
            jobExpiryLabel.Name = "jobExpiryLabel";
            jobExpiryLabel.Size = new System.Drawing.Size(113, 29);
            jobExpiryLabel.TabIndex = 0;
            jobExpiryLabel.Text = "Jobs will expire after";
            jobExpiryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // expiryDaysInput
            // 
            expiryDaysInput.Location = new System.Drawing.Point(122, 3);
            expiryDaysInput.MaxLength = 3;
            expiryDaysInput.Name = "expiryDaysInput";
            expiryDaysInput.Size = new System.Drawing.Size(24, 23);
            expiryDaysInput.TabIndex = 1;
            expiryDaysInput.TextChanged += SettingChange;
            expiryDaysInput.KeyPress += DigitOnlyInput;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(152, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(34, 29);
            label1.TabIndex = 2;
            label1.Text = "days.";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // explorerPreviewCheckBox
            // 
            explorerPreviewCheckBox.AutoSize = true;
            explorerPreviewCheckBox.Location = new System.Drawing.Point(3, 38);
            explorerPreviewCheckBox.Name = "explorerPreviewCheckBox";
            explorerPreviewCheckBox.Size = new System.Drawing.Size(237, 19);
            explorerPreviewCheckBox.TabIndex = 1;
            explorerPreviewCheckBox.Text = "Show drive in explorer when connected.";
            explorerPreviewCheckBox.UseVisualStyleBackColor = true;
            explorerPreviewCheckBox.CheckedChanged += SettingChange;
            // 
            // deviceTab
            // 
            deviceTab.Controls.Add(tableLayoutPanel5);
            deviceTab.Location = new System.Drawing.Point(4, 24);
            deviceTab.Name = "deviceTab";
            deviceTab.Padding = new Padding(3);
            deviceTab.Size = new System.Drawing.Size(372, 245);
            deviceTab.TabIndex = 2;
            deviceTab.Text = "Devices";
            deviceTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72.35577F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel5.Controls.Add(devicesListView, 0, 0);
            tableLayoutPanel5.Controls.Add(flowLayoutPanel7, 1, 0);
            tableLayoutPanel5.Location = new System.Drawing.Point(6, 6);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new System.Drawing.Size(352, 228);
            tableLayoutPanel5.TabIndex = 0;
            // 
            // devicesListView
            // 
            devicesListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            devicesListView.FullRowSelect = true;
            devicesListView.Location = new System.Drawing.Point(3, 3);
            devicesListView.Name = "devicesListView";
            devicesListView.Size = new System.Drawing.Size(259, 222);
            devicesListView.TabIndex = 0;
            devicesListView.UseCompatibleStateImageBehavior = false;
            devicesListView.View = View.List;
            // 
            // flowLayoutPanel7
            // 
            flowLayoutPanel7.AutoSize = true;
            flowLayoutPanel7.Controls.Add(deviceAddButton);
            flowLayoutPanel7.Controls.Add(deviceRemoveButton);
            flowLayoutPanel7.Location = new System.Drawing.Point(268, 3);
            flowLayoutPanel7.Name = "flowLayoutPanel7";
            flowLayoutPanel7.Size = new System.Drawing.Size(81, 58);
            flowLayoutPanel7.TabIndex = 1;
            // 
            // deviceAddButton
            // 
            deviceAddButton.Location = new System.Drawing.Point(3, 3);
            deviceAddButton.Name = "deviceAddButton";
            deviceAddButton.Size = new System.Drawing.Size(75, 23);
            deviceAddButton.TabIndex = 1;
            deviceAddButton.Text = "Add";
            deviceAddButton.UseVisualStyleBackColor = true;
            deviceAddButton.Click += AddDeviceClick;
            // 
            // deviceRemoveButton
            // 
            deviceRemoveButton.Location = new System.Drawing.Point(3, 32);
            deviceRemoveButton.Name = "deviceRemoveButton";
            deviceRemoveButton.Size = new System.Drawing.Size(75, 23);
            deviceRemoveButton.TabIndex = 2;
            deviceRemoveButton.Text = "Remove";
            deviceRemoveButton.UseVisualStyleBackColor = true;
            deviceRemoveButton.Click += RemoveDeviceClick;
            // 
            // applyButton
            // 
            applyButton.Enabled = false;
            applyButton.Location = new System.Drawing.Point(84, 3);
            applyButton.Name = "applyButton";
            applyButton.Size = new System.Drawing.Size(75, 23);
            applyButton.TabIndex = 1;
            applyButton.Text = "Apply";
            applyButton.UseVisualStyleBackColor = true;
            applyButton.Click += ApplyButtonClick;
            // 
            // closeButton
            // 
            closeButton.Location = new System.Drawing.Point(3, 3);
            closeButton.Name = "closeButton";
            closeButton.Size = new System.Drawing.Size(75, 23);
            closeButton.TabIndex = 2;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += CloseButtonClick;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutPanel1.Controls.Add(settingsTabControl, 0, 0);
            tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 87.78626F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new System.Drawing.Size(386, 314);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(applyButton);
            flowLayoutPanel1.Controls.Add(closeButton);
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(221, 282);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(162, 29);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // SettingsForm
            // 
            AcceptButton = applyButton;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = closeButton;
            ClientSize = new System.Drawing.Size(410, 338);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "Settings";
            TopMost = true;
            settingsTabControl.ResumeLayout(false);
            serverTab.ResumeLayout(false);
            LoggedInTable.ResumeLayout(false);
            tableLayoutPanel9.ResumeLayout(false);
            tableLayoutPanel9.PerformLayout();
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            loginTable.ResumeLayout(false);
            loginTable.PerformLayout();
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            transcodeTab.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            jobTab.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            flowLayoutPanel6.ResumeLayout(false);
            flowLayoutPanel6.PerformLayout();
            deviceTab.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            flowLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);

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
        private Button InstallFfmpeg;
        private Label loginRequiredLabel;
        private Label passwordLabel;
        private Label usernameLabel;
        private TextBox usernameInput;
        private TableLayoutPanel tableLayoutPanel6;
        private Button loginButton;
        private TextBox passwordInput;
        private TableLayoutPanel loginTable;
        private TableLayoutPanel LoggedInTable;
        private TableLayoutPanel tableLayoutPanel9;
        private TableLayoutPanel tableLayoutPanel7;
        private Label LoggedInUser;
        private Label CreditsRemaining;
        private Button LogOut;
        private TableLayoutPanel tableLayoutPanel8;
        private Label label2;
        private ComboBox templateBox;
    }
}