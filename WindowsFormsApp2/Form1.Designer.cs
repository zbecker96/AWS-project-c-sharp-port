namespace WindowsFormsApp2 {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.FilePathBox = new System.Windows.Forms.TextBox();
            this.ChooseFileButton = new System.Windows.Forms.Button();
            this.FilePathBoxLabel = new System.Windows.Forms.Label();
            this.LabelButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ResultsLabel = new System.Windows.Forms.Label();
            this.ActionsLabel = new System.Windows.Forms.Label();
            this.ResultsTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // FilePathBox
            // 
            this.FilePathBox.Location = new System.Drawing.Point(12, 420);
            this.FilePathBox.Name = "FilePathBox";
            this.FilePathBox.Size = new System.Drawing.Size(257, 20);
            this.FilePathBox.TabIndex = 0;
            // 
            // ChooseFileButton
            // 
            this.ChooseFileButton.Location = new System.Drawing.Point(275, 417);
            this.ChooseFileButton.Name = "ChooseFileButton";
            this.ChooseFileButton.Size = new System.Drawing.Size(75, 23);
            this.ChooseFileButton.TabIndex = 1;
            this.ChooseFileButton.Text = "Choose File";
            this.ChooseFileButton.UseVisualStyleBackColor = true;
            this.ChooseFileButton.Click += new System.EventHandler(this.ChooseFileButton_Click);
            // 
            // FilePathBoxLabel
            // 
            this.FilePathBoxLabel.AutoSize = true;
            this.FilePathBoxLabel.Location = new System.Drawing.Point(13, 398);
            this.FilePathBoxLabel.Name = "FilePathBoxLabel";
            this.FilePathBoxLabel.Size = new System.Drawing.Size(51, 13);
            this.FilePathBoxLabel.TabIndex = 2;
            this.FilePathBoxLabel.Text = "File Path:";
            // 
            // LabelButton
            // 
            this.LabelButton.Location = new System.Drawing.Point(12, 330);
            this.LabelButton.Name = "LabelButton";
            this.LabelButton.Size = new System.Drawing.Size(75, 23);
            this.LabelButton.TabIndex = 3;
            this.LabelButton.Text = "Labels";
            this.LabelButton.UseMnemonic = false;
            this.LabelButton.UseVisualStyleBackColor = false;
            this.LabelButton.Visible = false;
            this.LabelButton.Click += new System.EventHandler(this.LabelButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(16, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(772, 290);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // ResultsLabel
            // 
            this.ResultsLabel.AutoSize = true;
            this.ResultsLabel.Location = new System.Drawing.Point(353, 308);
            this.ResultsLabel.Name = "ResultsLabel";
            this.ResultsLabel.Size = new System.Drawing.Size(42, 13);
            this.ResultsLabel.TabIndex = 6;
            this.ResultsLabel.Text = "Results";
            // 
            // ActionsLabel
            // 
            this.ActionsLabel.AutoSize = true;
            this.ActionsLabel.Location = new System.Drawing.Point(12, 308);
            this.ActionsLabel.Name = "ActionsLabel";
            this.ActionsLabel.Size = new System.Drawing.Size(45, 13);
            this.ActionsLabel.TabIndex = 7;
            this.ActionsLabel.Text = "Actions:";
            // 
            // ResultsTextBox
            // 
            this.ResultsTextBox.Location = new System.Drawing.Point(356, 330);
            this.ResultsTextBox.Name = "ResultsTextBox";
            this.ResultsTextBox.Size = new System.Drawing.Size(432, 110);
            this.ResultsTextBox.TabIndex = 8;
            this.ResultsTextBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ResultsTextBox);
            this.Controls.Add(this.ActionsLabel);
            this.Controls.Add(this.ResultsLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LabelButton);
            this.Controls.Add(this.FilePathBoxLabel);
            this.Controls.Add(this.ChooseFileButton);
            this.Controls.Add(this.FilePathBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FilePathBox;
        private System.Windows.Forms.Button ChooseFileButton;
        private System.Windows.Forms.Label FilePathBoxLabel;
        private System.Windows.Forms.Button LabelButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label ResultsLabel;
        private System.Windows.Forms.Label ActionsLabel;
        private System.Windows.Forms.RichTextBox ResultsTextBox;
    }
}

