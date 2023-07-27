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
    public partial class Form1 : Form
    {
        public static int formHeight, formWidth;
        public Form1()
        {
            InitializeComponent();
            ChangeScreen(this, new MenuScreen());
            formHeight = Height;
            formWidth = Width;
        }

        public static void ChangeScreen(object sender, UserControl next)
        {
            Form f; // will either be the sender or parent of sender

            if (sender is Form)
            {
                f = (Form)sender;
            }

            else
            {
                UserControl current = (UserControl)sender;
                f = current.FindForm();
                f.Controls.Remove(current);
            }

            next.Location = new Point((f.ClientSize.Width - next.Width) / 2, (f.ClientSize.Height - next.Height) / 2);

            f.Controls.Add(next);
            next.Focus();
        }

        public static double GetDirection(double xSpeed, double ySpeed)
        {
            double direction;

            if (ySpeed == 0)
            {
                if (xSpeed < 0)
                {
                    return -90;
                }
                else
                {
                    return 90;
                }
            }
            else
            {
                direction = Math.Atan2(xSpeed, ySpeed) * 180 / Math.PI;

                if (xSpeed <= 0 && ySpeed > 0)
                {
                    direction += 360;
                }

                return direction;
            }
        }

        public static double GetDirection(int xSpeed, int ySpeed)
        {
            double direction;

            if (ySpeed == 0)
            {
                if (xSpeed < 0)
                {
                    return -90;
                }
                else
                {
                    return 90;
                }
            }
            else
            {
                direction = Math.Atan2(xSpeed, ySpeed) * 180 / Math.PI;

                if (xSpeed <= 0 && ySpeed > 0)
                {
                    direction += 360;
                }

                return direction;
            }
        }
        public static double GetDistance(int x, int y)
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }
        public static double GetDistance(double x, double y)
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }
    }
}
