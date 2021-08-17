
namespace Redhvid
{
    partial class JobDataForm
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
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.uploadButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(9, 14);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(67, 15);
            this.firstNameLabel.TabIndex = 0;
            this.firstNameLabel.Text = "First Name:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(82, 83);
            this.emailTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(187, 23);
            this.emailTextBox.TabIndex = 3;
            this.emailTextBox.TextChanged += new System.EventHandler(this.Validate);
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(9, 50);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(66, 15);
            this.lastNameLabel.TabIndex = 2;
            this.lastNameLabel.Text = "Last Name:";
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(82, 47);
            this.lastNameTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(187, 23);
            this.lastNameTextBox.TabIndex = 2;
            this.lastNameTextBox.TextChanged += new System.EventHandler(this.Validate);
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(9, 86);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(39, 15);
            this.emailLabel.TabIndex = 4;
            this.emailLabel.Text = "Email:";
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(82, 11);
            this.firstNameTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(187, 23);
            this.firstNameTextBox.TabIndex = 1;
            this.firstNameTextBox.TextChanged += new System.EventHandler(this.Validate);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.statusProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 149);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(284, 22);
            this.statusStrip.TabIndex = 6;
            this.statusStrip.Text = "Text";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(167, 17);
            this.statusLabel.Spring = true;
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusProgressBar
            // 
            this.statusProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.statusProgressBar.Name = "statusProgressBar";
            this.statusProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // uploadButton
            // 
            this.uploadButton.Enabled = false;
            this.uploadButton.Location = new System.Drawing.Point(194, 119);
            this.uploadButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(75, 23);
            this.uploadButton.TabIndex = 4;
            this.uploadButton.Text = "Upload";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.StartUpload);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(113, 119);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelUpload);
            // 
            // JobDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 171);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.firstNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "JobDataForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "New Job";
            this.TopMost = true;
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripProgressBar statusProgressBar;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.Button cancelButton;
    }
}