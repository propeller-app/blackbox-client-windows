
namespace Redhvid
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
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.contextMenu;
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIconClick);
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
            this.jobProgressMenuItem.Click += new System.EventHandler(this.OpenJobProgressMenu);
            // 
            // jobQueueMenuItem
            // 
            this.jobQueueMenuItem.Name = "jobQueueMenuItem";
            this.jobQueueMenuItem.Size = new System.Drawing.Size(168, 22);
            this.jobQueueMenuItem.Text = "View Job Queue";
            this.jobQueueMenuItem.Click += new System.EventHandler(this.OpenJobQueueMenu);
            // 
            // jobHistoryMenuItem
            // 
            this.jobHistoryMenuItem.Name = "jobHistoryMenuItem";
            this.jobHistoryMenuItem.Size = new System.Drawing.Size(168, 22);
            this.jobHistoryMenuItem.Text = "View Job History";
            this.jobHistoryMenuItem.Click += new System.EventHandler(this.OpenJobHistoryMenu);
            // 
            // newJobMenuItem
            // 
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
            this.closeButton.Location = new System.Drawing.Point(271, 102);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Hide";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButtonClick);
            // 
            // jobProgress
            // 
            this.jobProgress.Location = new System.Drawing.Point(12, 37);
            this.jobProgress.Name = "jobProgress";
            this.jobProgress.Size = new System.Drawing.Size(334, 44);
            this.jobProgress.TabIndex = 2;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(12, 9);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(39, 15);
            this.progressLabel.TabIndex = 3;
            this.progressLabel.Text = "Ready";
            // 
            // JobProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 137);
            this.ControlBox = false;
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.jobProgress);
            this.Controls.Add(this.closeButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JobProgressForm";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Current Job";
            this.contextMenu.ResumeLayout(false);
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
    }
}