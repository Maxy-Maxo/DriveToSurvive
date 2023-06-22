using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveToSurvive
{
    public partial class MenuScreen : UserControl
    {
        public static int mode;
        public MenuScreen()
        {
            InitializeComponent();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            //mode = 0;
            //Form1.ChangeScreen(this, new TrackSelectScreen());
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buildButton_Click(object sender, EventArgs e)
        {
            mode = 1;
            Form1.ChangeScreen(this, new GameScreen());
        }
    }
}
