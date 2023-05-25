namespace DriveToSurvive
{
    partial class TrackSelectScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.track1 = new System.Windows.Forms.Label();
            this.track2 = new System.Windows.Forms.Label();
            this.track3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // track1
            // 
            this.track1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.track1.ForeColor = System.Drawing.Color.White;
            this.track1.Location = new System.Drawing.Point(35, 104);
            this.track1.Name = "track1";
            this.track1.Size = new System.Drawing.Size(151, 170);
            this.track1.TabIndex = 0;
            this.track1.Text = "1";
            this.track1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // track2
            // 
            this.track2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.track2.ForeColor = System.Drawing.Color.White;
            this.track2.Location = new System.Drawing.Point(205, 104);
            this.track2.Name = "track2";
            this.track2.Size = new System.Drawing.Size(151, 170);
            this.track2.TabIndex = 1;
            this.track2.Text = "2";
            this.track2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // track3
            // 
            this.track3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.track3.ForeColor = System.Drawing.Color.White;
            this.track3.Location = new System.Drawing.Point(375, 104);
            this.track3.Name = "track3";
            this.track3.Size = new System.Drawing.Size(151, 170);
            this.track3.TabIndex = 2;
            this.track3.Text = "3";
            this.track3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // TrackSelectScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.track3);
            this.Controls.Add(this.track2);
            this.Controls.Add(this.track1);
            this.Font = new System.Drawing.Font("Leelawadee", 14.25F);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "TrackSelectScreen";
            this.Size = new System.Drawing.Size(800, 600);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label track1;
        private System.Windows.Forms.Label track2;
        private System.Windows.Forms.Label track3;
    }
}
