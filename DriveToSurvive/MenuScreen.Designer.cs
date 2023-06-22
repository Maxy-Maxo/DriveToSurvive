namespace DriveToSurvive
{
    partial class MenuScreen
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
            this.playButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.buildButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.GreenYellow;
            this.playButton.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.playButton.FlatAppearance.BorderSize = 5;
            this.playButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.playButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.playButton.Font = new System.Drawing.Font("Squada One", 35F, System.Drawing.FontStyle.Bold);
            this.playButton.Location = new System.Drawing.Point(309, 245);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(181, 80);
            this.playButton.TabIndex = 0;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Orange;
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkGoldenrod;
            this.exitButton.FlatAppearance.BorderSize = 5;
            this.exitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.exitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Goldenrod;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exitButton.Font = new System.Drawing.Font("Squada One", 28F, System.Drawing.FontStyle.Bold);
            this.exitButton.Location = new System.Drawing.Point(330, 519);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(140, 55);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // buildButton
            // 
            this.buildButton.BackColor = System.Drawing.Color.SkyBlue;
            this.buildButton.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.buildButton.FlatAppearance.BorderSize = 5;
            this.buildButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buildButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.buildButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buildButton.Font = new System.Drawing.Font("Squada One", 20F, System.Drawing.FontStyle.Bold);
            this.buildButton.Location = new System.Drawing.Point(309, 349);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(181, 80);
            this.buildButton.TabIndex = 2;
            this.buildButton.Text = "Track Builder";
            this.buildButton.UseVisualStyleBackColor = false;
            this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // MenuScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.Controls.Add(this.buildButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.playButton);
            this.Font = new System.Drawing.Font("Squada One", 13.8F);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "MenuScreen";
            this.Size = new System.Drawing.Size(800, 600);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button buildButton;
    }
}
