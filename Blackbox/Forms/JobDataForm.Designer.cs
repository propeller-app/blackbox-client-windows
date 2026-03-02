
namespace Blackbox
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
            firstNameLabel = new System.Windows.Forms.Label();
            emailTextBox = new System.Windows.Forms.TextBox();
            lastNameLabel = new System.Windows.Forms.Label();
            lastNameTextBox = new System.Windows.Forms.TextBox();
            emailLabel = new System.Windows.Forms.Label();
            firstNameTextBox = new System.Windows.Forms.TextBox();
            statusStrip = new System.Windows.Forms.StatusStrip();
            statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            statusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            uploadButton = new System.Windows.Forms.Button();
            cancelButton = new System.Windows.Forms.Button();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            groupBox1 = new System.Windows.Forms.GroupBox();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            statusStrip.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // firstNameLabel
            // 
            firstNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new System.Drawing.Point(3, 0);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new System.Drawing.Size(77, 33);
            firstNameLabel.TabIndex = 0;
            firstNameLabel.Text = "First Name:";
            firstNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // emailTextBox
            // 
            emailTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            emailTextBox.Location = new System.Drawing.Point(88, 71);
            emailTextBox.Margin = new System.Windows.Forms.Padding(5);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new System.Drawing.Size(234, 23);
            emailTextBox.TabIndex = 3;
            emailTextBox.TextChanged += Validate;
            // 
            // lastNameLabel
            // 
            lastNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new System.Drawing.Point(3, 33);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new System.Drawing.Size(77, 33);
            lastNameLabel.TabIndex = 2;
            lastNameLabel.Text = "Last Name:";
            lastNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lastNameTextBox.Location = new System.Drawing.Point(88, 38);
            lastNameTextBox.Margin = new System.Windows.Forms.Padding(5);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new System.Drawing.Size(234, 23);
            lastNameTextBox.TabIndex = 2;
            lastNameTextBox.TextChanged += Validate;
            // 
            // emailLabel
            // 
            emailLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(3, 66);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(77, 34);
            emailLabel.TabIndex = 4;
            emailLabel.Text = "Email:";
            emailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            firstNameTextBox.Location = new System.Drawing.Point(88, 5);
            firstNameTextBox.Margin = new System.Windows.Forms.Padding(5);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new System.Drawing.Size(234, 23);
            firstNameTextBox.TabIndex = 1;
            firstNameTextBox.TextChanged += Validate;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusLabel, statusProgressBar });
            statusStrip.Location = new System.Drawing.Point(0, 219);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new System.Drawing.Size(363, 22);
            statusStrip.TabIndex = 6;
            statusStrip.Text = "Text";
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new System.Drawing.Size(246, 17);
            statusLabel.Spring = true;
            statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusProgressBar
            // 
            statusProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            statusProgressBar.Name = "statusProgressBar";
            statusProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // uploadButton
            // 
            uploadButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            uploadButton.Enabled = false;
            uploadButton.Location = new System.Drawing.Point(227, 3);
            uploadButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            uploadButton.Name = "uploadButton";
            uploadButton.Size = new System.Drawing.Size(97, 28);
            uploadButton.TabIndex = 4;
            uploadButton.Text = "Upload";
            uploadButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cancelButton.Location = new System.Drawing.Point(3, 3);
            cancelButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(97, 28);
            cancelButton.TabIndex = 5;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.53192F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.46809F));
            tableLayoutPanel1.Controls.Add(firstNameLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(lastNameLabel, 0, 1);
            tableLayoutPanel1.Controls.Add(emailLabel, 0, 2);
            tableLayoutPanel1.Controls.Add(firstNameTextBox, 1, 0);
            tableLayoutPanel1.Controls.Add(emailTextBox, 1, 2);
            tableLayoutPanel1.Controls.Add(lastNameTextBox, 1, 1);
            tableLayoutPanel1.Location = new System.Drawing.Point(6, 22);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.Size = new System.Drawing.Size(327, 100);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.Controls.Add(tableLayoutPanel2);
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Location = new System.Drawing.Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(339, 204);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Customer Data";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.9821434F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.0178566F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            tableLayoutPanel2.Controls.Add(cancelButton, 0, 0);
            tableLayoutPanel2.Controls.Add(uploadButton, 2, 0);
            tableLayoutPanel2.Location = new System.Drawing.Point(6, 159);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new System.Drawing.Size(327, 39);
            tableLayoutPanel2.TabIndex = 8;
            // 
            // JobDataForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(363, 241);
            ControlBox = false;
            Controls.Add(groupBox1);
            Controls.Add(statusStrip);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Name = "JobDataForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "New Job";
            TopMost = true;
            Load += JobDataForm_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.StatusStrip statusStrip;
        public System.Windows.Forms.ToolStripStatusLabel statusLabel;
        public System.Windows.Forms.ToolStripProgressBar statusProgressBar;
        public System.Windows.Forms.TextBox emailTextBox;
        public System.Windows.Forms.TextBox lastNameTextBox;
        public System.Windows.Forms.TextBox firstNameTextBox;
        public System.Windows.Forms.Button uploadButton;
        public System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}