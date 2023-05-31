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
    public partial class GameScreen : UserControl
    {
        SolidBrush brush = new SolidBrush(Color.White);
        Pen pen = new Pen(Color.Red, 2);
        public static List<Car> cars = new List<Car>();
        public static List<Trackpoint> trackpoints = new List<Trackpoint>();
        int mouseX, mouseY;

        bool upArrow, downArrow, leftArrow, rightArrow;

        public GameScreen()
        {
            InitializeComponent();
            cars.Add(new Car(Width / 2, Height / 2, 90));
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (upArrow && !downArrow)
            {
                cars[0].speed++;
            }
            else if (!upArrow && downArrow)
            {
                cars[0].speed--;
            }
            
            if (leftArrow && !rightArrow && cars[0].steer >= -4)
            {
                cars[0].steer--;
            }
            else if (!leftArrow && rightArrow && cars[0].steer <= 4)
            {
                cars[0].steer++;
            }

            if (cars[0].speed != 0 && (!upArrow && !downArrow || (upArrow && downArrow)))
            {
                if (cars[0].speed > 0)
                {
                    cars[0].speed--;
                }
                else
                {
                    cars[0].speed++;
                }
            }

            if (cars[0].steer != 0 && (!leftArrow && !rightArrow || (leftArrow && rightArrow)))
            {
                if (cars[0].steer > 0)
                {
                    cars[0].steer--;
                }
                else
                {
                    cars[0].steer++;
                }
            }

            foreach (Car c in cars)
            {
                c.Move();
            }

            Refresh();
        }

        private void GameScreen_MouseClick(object sender, MouseEventArgs e)
        {
            trackpoints.Add(new Trackpoint(mouseX, mouseY, 90, Convert.ToInt16(sizeInput.Text)));
            if (trackpoints.Count > 1)
            {
                trackpoints[trackpoints.Count - 2].direction = Form1.GetDirection(trackpoints[trackpoints.Count - 1].x - trackpoints[trackpoints.Count - 2].x, trackpoints[trackpoints.Count - 1].y - trackpoints[trackpoints.Count - 2].y);
                trackpoints[trackpoints.Count - 1].direction = Form1.GetDirection(trackpoints[0].x - trackpoints[trackpoints.Count - 1].x, trackpoints[0].y - trackpoints[trackpoints.Count - 1].y);

            }
        }

        private void GameScreen_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            foreach (Trackpoint p in trackpoints)
            {
                e.Graphics.FillEllipse(brush, p.x - p.size / 2, p.y - p.size / 2, p.size, p.size);
                e.Graphics.DrawLine(pen, p.x, p.y, (float)(p.x + Math.Sin(p.direction * Math.PI / 180) * p.size / 2), (float)(p.y + Math.Cos(p.direction * Math.PI / 180) * p.size / 2));
            }

            foreach (Car c in cars)
            {
                //e.Graphics.TranslateTransform(c.width / 2 + (int)c.x, c.width / 2 + (int)c.y);
                //e.Graphics.RotateTransform(Convert.ToInt32(c.direction));
                e.Graphics.FillRectangle(brush, Convert.ToInt16(c.x), Convert.ToInt16(c.y), 30, 30);
                //e.Graphics.FillRectangle(brush, 10, 10, 30, 50);
                //e.Graphics.DrawImage();
            }
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upArrow = true;
                    break;
                case Keys.Down:
                    downArrow = true;
                    break;
                case Keys.Left:
                    leftArrow = true;
                    break;
                case Keys.Right:
                    rightArrow = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upArrow = false;
                    break;
                case Keys.Down:
                    downArrow = false;
                    break;
                case Keys.Left:
                    leftArrow = false;
                    break;
                case Keys.Right:
                    rightArrow = false;
                    break;
            }
        }
    }
}
