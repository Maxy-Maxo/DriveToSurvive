namespace DriveToSurvive
{
    partial class GameScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameScreen));
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.helpButton = new System.Windows.Forms.Label();
            this.helpText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.Color.DimGray;
            this.helpButton.Font = new System.Drawing.Font("Squada One", 20F);
            this.helpButton.Location = new System.Drawing.Point(704, 24);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(72, 38);
            this.helpButton.TabIndex = 0;
            this.helpButton.Text = "HELP";
            this.helpButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // helpText
            // 
            this.helpText.AutoSize = true;
            this.helpText.BackColor = System.Drawing.Color.Transparent;
            this.helpText.Location = new System.Drawing.Point(450, 62);
            this.helpText.Name = "helpText";
            this.helpText.Size = new System.Drawing.Size(326, 150);
            this.helpText.TabIndex = 1;
            this.helpText.Text = resources.GetString("helpText.Text");
            this.helpText.Visible = false;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.Controls.Add(this.helpText);
            this.Controls.Add(this.helpButton);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Squada One", 13.8F);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(0, 7, 0, 7);
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(800, 600);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameScreen_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GameScreen_MouseMove);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GameScreen_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label helpButton;
        private System.Windows.Forms.Label helpText;
    }
}
