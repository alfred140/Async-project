
namespace lab5
{
    partial class main
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
            this.extractButton = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.imgListBox = new System.Windows.Forms.ListBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.imageCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // extractButton
            // 
            this.extractButton.Location = new System.Drawing.Point(118, 12);
            this.extractButton.Name = "extractButton";
            this.extractButton.Size = new System.Drawing.Size(75, 23);
            this.extractButton.TabIndex = 0;
            this.extractButton.Text = "Exctract";
            this.extractButton.UseVisualStyleBackColor = true;
            this.extractButton.Click += new System.EventHandler(this.extractButton_Click);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(12, 12);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(100, 20);
            this.searchBox.TabIndex = 1;
            this.searchBox.Text = "https://";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(625, 418);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(81, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save images";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // imgListBox
            // 
            this.imgListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgListBox.FormattingEnabled = true;
            this.imgListBox.Location = new System.Drawing.Point(12, 38);
            this.imgListBox.Name = "imgListBox";
            this.imgListBox.Size = new System.Drawing.Size(694, 368);
            this.imgListBox.TabIndex = 4;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(373, 418);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(246, 23);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 5;
            // 
            // imageCount
            // 
            this.imageCount.AutoSize = true;
            this.imageCount.Location = new System.Drawing.Point(12, 418);
            this.imageCount.Name = "imageCount";
            this.imageCount.Size = new System.Drawing.Size(0, 13);
            this.imageCount.TabIndex = 6;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 450);
            this.Controls.Add(this.imageCount);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.imgListBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.extractButton);
            this.MaximizeBox = false;
            this.Name = "main";
            this.Text = "Web scraper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button extractButton;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ListBox imgListBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label imageCount;
    }
}

