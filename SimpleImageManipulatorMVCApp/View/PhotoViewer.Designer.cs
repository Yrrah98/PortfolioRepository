namespace View
{
    partial class PhotoViewer
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
            this.RotateL = new System.Windows.Forms.Button();
            this.RotateR = new System.Windows.Forms.Button();
            this.FlipHorizontal = new System.Windows.Forms.Button();
            this.FlipVertical = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // RotateL
            // 
            this.RotateL.Location = new System.Drawing.Point(12, 415);
            this.RotateL.Name = "RotateL";
            this.RotateL.Size = new System.Drawing.Size(83, 23);
            this.RotateL.TabIndex = 0;
            this.RotateL.Text = "Rotate Left";
            this.RotateL.UseVisualStyleBackColor = true;
            // 
            // RotateR
            // 
            this.RotateR.Location = new System.Drawing.Point(101, 415);
            this.RotateR.Name = "RotateR";
            this.RotateR.Size = new System.Drawing.Size(75, 23);
            this.RotateR.TabIndex = 1;
            this.RotateR.Text = "Rotate Right";
            this.RotateR.UseVisualStyleBackColor = true;
            // 
            // FlipHorizontal
            // 
            this.FlipHorizontal.Location = new System.Drawing.Point(182, 415);
            this.FlipHorizontal.Name = "FlipHorizontal";
            this.FlipHorizontal.Size = new System.Drawing.Size(96, 23);
            this.FlipHorizontal.TabIndex = 2;
            this.FlipHorizontal.Text = "Flip Horizontal";
            this.FlipHorizontal.UseVisualStyleBackColor = true;
            // 
            // FlipVertical
            // 
            this.FlipVertical.Location = new System.Drawing.Point(284, 415);
            this.FlipVertical.Name = "FlipVertical";
            this.FlipVertical.Size = new System.Drawing.Size(75, 23);
            this.FlipVertical.TabIndex = 3;
            this.FlipVertical.Text = "Flip Vertical";
            this.FlipVertical.UseVisualStyleBackColor = true;
            this.FlipVertical.Click += new System.EventHandler(this.FlipVertical_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(365, 415);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 4;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(441, 397);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // PhotoViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.FlipVertical);
            this.Controls.Add(this.FlipHorizontal);
            this.Controls.Add(this.RotateR);
            this.Controls.Add(this.RotateL);
            this.Name = "PhotoViewer";
            this.Text = "PhotoViewer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RotateL;
        private System.Windows.Forms.Button RotateR;
        private System.Windows.Forms.Button FlipHorizontal;
        private System.Windows.Forms.Button FlipVertical;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}