namespace View
{
    partial class PhotoLibrary
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
            this.OpenPhotoBtn = new System.Windows.Forms.Button();
            this.ThumbnailArea = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // OpenPhotoBtn
            // 
            this.OpenPhotoBtn.Location = new System.Drawing.Point(12, 528);
            this.OpenPhotoBtn.Name = "OpenPhotoBtn";
            this.OpenPhotoBtn.Size = new System.Drawing.Size(75, 23);
            this.OpenPhotoBtn.TabIndex = 0;
            this.OpenPhotoBtn.Text = "Open Files";
            this.OpenPhotoBtn.UseVisualStyleBackColor = true;
            this.OpenPhotoBtn.Click += new System.EventHandler(this.OpenPhotoBtn_Click);
            // 
            // ThumbnailArea
            // 
            this.ThumbnailArea.Location = new System.Drawing.Point(12, 12);
            this.ThumbnailArea.Name = "ThumbnailArea";
            this.ThumbnailArea.Size = new System.Drawing.Size(780, 510);
            this.ThumbnailArea.TabIndex = 1;
            // 
            // PhotoLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 563);
            this.Controls.Add(this.ThumbnailArea);
            this.Controls.Add(this.OpenPhotoBtn);
            this.Name = "PhotoLibrary";
            this.Text = "Photo Library";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OpenPhotoBtn;
        private System.Windows.Forms.FlowLayoutPanel ThumbnailArea;
    }
}

