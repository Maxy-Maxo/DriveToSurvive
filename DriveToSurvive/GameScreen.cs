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
        SolidBrush trackColour = new SolidBrush(Color.FromArgb(50, 50, 50));
        Pen pen = new Pen(Color.Red, 2);
        Font gameFont = new Font("Squada One", 20, FontStyle.Regular);

        public static List<Car> cars = new List<Car>();
        public static List<Trackpoint> trackpoints = new List<Trackpoint>();
        double mouseX, mouseY;
        public static double gameX, gameY;
        int size = 100;
        int player = 1;

        bool upArrow, downArrow, leftArrow, rightArrow;

        public GameScreen()
        {
            InitializeComponent();
            cars.Add(new Car(Width / 2, Height / 2, 90, Properties.Resources.tealCar));
            cars.Add(new Car(Width / 2, Height / 2, 0, Properties.Resources.yellowCar));
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (upArrow && !downArrow)
            {
                cars[player].speed++;
            }
            else if (!upArrow && downArrow)
            {
                cars[player].speed--;
            }
            
            if (leftArrow && !rightArrow && cars[player].steer >= -4)
            {
                cars[player].steer--;
            }
            else if (!leftArrow && rightArrow && cars[player].steer <= 4)
            {
                cars[player].steer++;
            }

            if (cars[player].speed != 0 && (!upArrow && !downArrow || (upArrow && downArrow)))
            {
                if (cars[player].speed > 0)
                {
                    cars[player].speed--;
                }
                else
                {
                    cars[player].speed++;
                }
            }

            if (cars[player].steer != 0 && (!leftArrow && !rightArrow || (leftArrow && rightArrow)))
            {
                if (cars[player].steer > 0)
                {
                    cars[player].steer--;
                }
                else
                {
                    cars[player].steer++;
                }
            }

            foreach (Car c in cars)
            {
                c.Move();
            }
            gameX -= cars[player].xSpeed * cars[player].speed / 20;
            gameY += cars[player].ySpeed * cars[player].speed / 20;

            Refresh();
        }

        private void GameScreen_MouseClick(object sender, MouseEventArgs e)
        {
            trackpoints.Add(new Trackpoint((int)(mouseX - gameX), (int)(mouseY - gameY), 90, Convert.ToInt16(size * 2), trackpoints.Count));
            if (trackpoints.Count > 1)
            {
                trackpoints[trackpoints.Count - 2].direction = Form1.GetDirection(trackpoints[trackpoints.Count - 1].x - trackpoints[trackpoints.Count - 2].x, trackpoints[trackpoints.Count - 1].y - trackpoints[trackpoints.Count - 2].y);
                trackpoints[trackpoints.Count - 1].direction = Form1.GetDirection(trackpoints[0].x - trackpoints[trackpoints.Count - 1].x, trackpoints[0].y - trackpoints[trackpoints.Count - 1].y);

            }
        }

        private void GameScreen_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X * Math.Pow(2, cars[player].z);
            mouseY = e.Y * Math.Pow(2, cars[player].z);
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            foreach (Trackpoint p in trackpoints)
            {
                e.Graphics.DrawImage(Properties.Resources.Edge, (float)((p.x - p.size / 20 - p.size / 2 + gameX) / Math.Pow(2, cars[player].z)), (float)((p.y - p.size / 20 - p.size / 2 + gameY) / Math.Pow(2, cars[player].z)), (float)((p.size + p.size / 10) / Math.Pow(2, cars[player].z)), (float)((p.size + p.size / 10) / Math.Pow(2, cars[player].z)));
            }
            foreach (Trackpoint p in trackpoints)
            {
                e.Graphics.FillEllipse(trackColour, (float)((p.x - p.size / 2 + gameX) / Math.Pow(2, cars[player].z)), (float)((p.y - p.size / 2 + gameY) / Math.Pow(2, cars[player].z)), (float)(p.size / Math.Pow(2, cars[player].z)), (float)(p.size / Math.Pow(2, cars[player].z)));
                //e.Graphics.DrawLine(pen, p.x, p.y, (float)(p.x + Math.Sin(p.direction * Math.PI / 180) * p.size / 2), (float)(p.y + Math.Cos(p.direction * Math.PI / 180) * p.size / 2));
            }
            foreach (Trackpoint p in trackpoints)
            {
                e.Graphics.DrawString($"{p.pointNumber}", gameFont, brush, (float)((p.x + gameX) / Math.Pow(2, cars[player].z)), (float)((p.y + gameY - 10) / Math.Pow(2, cars[player].z)));
            }

            foreach (Car c in cars)
            {
                if (c == cars[player])
                {
                    e.Graphics.TranslateTransform((float)(c.width / Math.Pow(2, cars[player].z)) / 2 + Width / 2 - (float)(c.width / Math.Pow(2, cars[player].z)) / 2, (float)(c.height / Math.Pow(2, cars[player].z)) / 2 + Height / 2 - (float)(c.height / Math.Pow(2, cars[player].z)) / 2);
                }
                else
                {
                    e.Graphics.TranslateTransform((float)((c.width / 2 + (c.x + gameX) - c.width / 2) / Math.Pow(2, cars[player].z)), (float)((c.height / 2 + (c.y + gameY) - c.height / 2) / Math.Pow(2, cars[player].z)));
                }
                e.Graphics.RotateTransform((float)c.direction);
                e.Graphics.DrawImage(c.image, (float)(0 - c.width / 2 / Math.Pow(2, cars[player].z)), (float)(0 - c.height / 2 / Math.Pow(2, cars[player].z)), (float)(c.width / Math.Pow(2, cars[player].z)), (float)(c.height / Math.Pow(2, cars[player].z)));
                e.Graphics.ResetTransform();

                if (c == cars[player] && c.trackLocation != 0)
                {
                    e.Graphics.DrawLine(pen, Width / 2, Height / 2, (float)((trackpoints[c.trackLocation].x + gameX) / Math.Pow(2, cars[player].z)), (float)((trackpoints[c.trackLocation].y + gameY) / Math.Pow(2, cars[player].z)));
                    e.Graphics.DrawString($"{c.trackLocation}", gameFont, brush, 50, 75);
                    e.Graphics.DrawString($"{c.distToTrack}", gameFont, brush, 50, 100);
                }
            }

            e.Graphics.DrawString($"{size}", gameFont, brush, 50, 50);
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
                case Keys.W:
                    size++;
                    break;
                case Keys.S:
                    if (size > 0)
                    {
                        size--;
                    }
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
