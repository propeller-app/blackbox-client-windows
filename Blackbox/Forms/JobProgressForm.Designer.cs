
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
            this.components = new System.ComponentModel.Container();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.jobProgressMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jobQueueMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jobHistoryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newJobMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeButton = new System.Windows.Forms.Button();
            this.jobProgress = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.userNotifyLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.contextMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.contextMenu;
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Show);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jobProgressMenuItem,
            this.jobQueueMenuItem,
            this.jobHistoryMenuItem,
            this.newJobMenuItem,
            this.settingsMenuItem,
            this.toolStripSeparator,
            this.exitMenuItem});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(169, 142);
            // 
            // jobProgressMenuItem
            // 
            this.jobProgressMenuItem.Name = "jobProgressMenuItem";
            this.jobProgressMenuItem.Size = new System.Drawing.Size(168, 22);
            this.jobProgressMenuItem.Text = "View Job Progress";
            this.jobProgressMenuItem.Click += new System.EventHandler(this.Show);
            // 
            // jobQueueMenuItem
            // 
            this.jobQueueMenuItem.Enabled = false;
            this.jobQueueMenuItem.Name = "jobQueueMenuItem";
            this.jobQueueMenuItem.Size = new System.Drawing.Size(168, 22);
            this.jobQueueMenuItem.Text = "View Job Queue";
            this.jobQueueMenuItem.Click += new System.EventHandler(this.OpenJobQueueMenu);
            // 
            // jobHistoryMenuItem
            // 
            this.jobHistoryMenuItem.Enabled = false;
            this.jobHistoryMenuItem.Name = "jobHistoryMenuItem";
            this.jobHistoryMenuItem.Size = new System.Drawing.Size(168, 22);
            this.jobHistoryMenuItem.Text = "View Job History";
            this.jobHistoryMenuItem.Click += new System.EventHandler(this.OpenJobHistoryMenu);
            // 
            // newJobMenuItem
            // 
            this.newJobMenuItem.Enabled = false;
            this.newJobMenuItem.Name = "newJobMenuItem";
            this.newJobMenuItem.Size = new System.Drawing.Size(168, 22);
            this.newJobMenuItem.Text = "Create New Job";
            this.newJobMenuItem.Click += new System.EventHandler(this.OpenNewJobMenu);
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.Name = "settingsMenuItem";
            this.settingsMenuItem.Size = new System.Drawing.Size(168, 22);
            this.settingsMenuItem.Text = "Settings";
            this.settingsMenuItem.Click += new System.EventHandler(this.OpenSettingsMenu);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(165, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(168, 22);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.ExitButtonClick);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(225, 60);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Hide";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.Hide);
            // 
            // jobProgress
            // 
            this.jobProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.jobProgress, 2);
            this.jobProgress.Location = new System.Drawing.Point(3, 20);
            this.jobProgress.Name = "jobProgress";
            this.jobProgress.Size = new System.Drawing.Size(297, 33);
            this.jobProgress.TabIndex = 2;
            // 
            // progressLabel
            // 
            this.progressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.progressLabel, 2);
            this.progressLabel.Location = new System.Drawing.Point(3, 0);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(297, 15);
            this.progressLabel.TabIndex = 3;
            this.progressLabel.Text = "Ready";
            // 
            // userNotifyLabel
            // 
            this.userNotifyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.userNotifyLabel.AutoSize = true;
            this.userNotifyLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userNotifyLabel.Location = new System.Drawing.Point(3, 56);
            this.userNotifyLabel.Name = "userNotifyLabel";
            this.userNotifyLabel.Size = new System.Drawing.Size(0, 30);
            this.userNotifyLabel.TabIndex = 4;
            this.userNotifyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.progressLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.jobProgress, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.closeButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.userNotifyLabel, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 9);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.85075F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.14925F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(303, 86);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // JobProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 104);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JobProgressForm";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Current Job";
            this.TopMost = true;
            this.contextMenu.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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