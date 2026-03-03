
namespace Blackbox
{
    partial class JobProgressForm
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
            components = new System.ComponentModel.Container();
            trayIcon = new System.Windows.Forms.NotifyIcon(components);
            contextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            jobProgressMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            jobQueueMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            jobHistoryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            newJobMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            closeButton = new System.Windows.Forms.Button();
            jobProgress = new System.Windows.Forms.ProgressBar();
            progressLabel = new System.Windows.Forms.Label();
            userNotifyLabel = new System.Windows.Forms.Label();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            contextMenu.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // trayIcon
            // 
            trayIcon.ContextMenuStrip = contextMenu;
            trayIcon.Visible = true;
            trayIcon.MouseDoubleClick += Show;
            // 
            // contextMenu
            // 
            contextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { jobProgressMenuItem, jobQueueMenuItem, jobHistoryMenuItem, newJobMenuItem, settingsMenuItem, toolStripSeparator, exitMenuItem });
            contextMenu.Name = "contextMenuStrip1";
            contextMenu.Size = new System.Drawing.Size(229, 202);
            // 
            // jobProgressMenuItem
            // 
            jobProgressMenuItem.Name = "jobProgressMenuItem";
            jobProgressMenuItem.Size = new System.Drawing.Size(228, 32);
            jobProgressMenuItem.Text = "View Job Progress";
            jobProgressMenuItem.Click += Show;
            // 
            // jobQueueMenuItem
            // 
            jobQueueMenuItem.Enabled = false;
            jobQueueMenuItem.Name = "jobQueueMenuItem";
            jobQueueMenuItem.Size = new System.Drawing.Size(228, 32);
            jobQueueMenuItem.Text = "View Job Queue";
            jobQueueMenuItem.Click += OpenJobQueueMenu;
            // 
            // jobHistoryMenuItem
            // 
            jobHistoryMenuItem.Enabled = false;
            jobHistoryMenuItem.Name = "jobHistoryMenuItem";
            jobHistoryMenuItem.Size = new System.Drawing.Size(228, 32);
            jobHistoryMenuItem.Text = "View Job History";
            jobHistoryMenuItem.Click += OpenJobHistoryMenu;
            // 
            // newJobMenuItem
            // 
            newJobMenuItem.Enabled = false;
            newJobMenuItem.Name = "newJobMenuItem";
            newJobMenuItem.Size = new System.Drawing.Size(228, 32);
            newJobMenuItem.Text = "Create New Job";
            newJobMenuItem.Click += OpenNewJobMenu;
            // 
            // settingsMenuItem
            // 
            settingsMenuItem.Name = "settingsMenuItem";
            settingsMenuItem.Size = new System.Drawing.Size(228, 32);
            settingsMenuItem.Text = "Settings";
            settingsMenuItem.Click += OpenSettingsMenu;
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new System.Drawing.Size(225, 6);
            // 
            // exitMenuItem
            // 
            exitMenuItem.Name = "exitMenuItem";
            exitMenuItem.Size = new System.Drawing.Size(228, 32);
            exitMenuItem.Text = "Exit";
            exitMenuItem.Click += ExitButtonClick;
            // 
            // closeButton
            // 
            closeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            closeButton.Dock = System.Windows.Forms.DockStyle.Right;
            closeButton.Location = new System.Drawing.Point(328, 108);
            closeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            closeButton.Name = "closeButton";
            closeButton.Size = new System.Drawing.Size(107, 40);
            closeButton.TabIndex = 1;
            closeButton.Text = "Hide";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += Hide;
            // 
            // jobProgress
            // 
            tableLayoutPanel1.SetColumnSpan(jobProgress, 2);
            jobProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            jobProgress.Location = new System.Drawing.Point(14, 43);
            jobProgress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            jobProgress.Name = "jobProgress";
            jobProgress.Size = new System.Drawing.Size(421, 55);
            jobProgress.TabIndex = 2;
            // 
            // progressLabel
            // 
            progressLabel.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(progressLabel, 2);
            progressLabel.Dock = System.Windows.Forms.DockStyle.Top;
            progressLabel.Location = new System.Drawing.Point(14, 10);
            progressLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            progressLabel.Name = "progressLabel";
            progressLabel.Size = new System.Drawing.Size(421, 25);
            progressLabel.TabIndex = 3;
            progressLabel.Text = "Ready";
            // 
            // userNotifyLabel
            // 
            userNotifyLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            userNotifyLabel.AutoSize = true;
            userNotifyLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            userNotifyLabel.Location = new System.Drawing.Point(14, 103);
            userNotifyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            userNotifyLabel.Name = "userNotifyLabel";
            userNotifyLabel.Size = new System.Drawing.Size(0, 50);
            userNotifyLabel.TabIndex = 4;
            userNotifyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(progressLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(jobProgress, 0, 1);
            tableLayoutPanel1.Controls.Add(closeButton, 1, 2);
            tableLayoutPanel1.Controls.Add(userNotifyLabel, 0, 2);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.85075F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.14925F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.Size = new System.Drawing.Size(449, 163);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // JobProgressForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(449, 163);
            ControlBox = false;
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "JobProgressForm";
            Opacity = 0D;
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Current Job";
            TopMost = true;
            contextMenu.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem jobProgressMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem jobQueueMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jobHistoryMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newJobMenuItem;
        public System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
        private System.Windows.Forms.ProgressBar jobProgress;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Label userNotifyLabel;
    }
}