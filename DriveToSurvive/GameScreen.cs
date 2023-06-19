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
        public static Random random = new Random();
        SolidBrush brush = new SolidBrush(Color.White);
        SolidBrush trackColour = new SolidBrush(Color.FromArgb(50, 50, 50));
        SolidBrush playerBrush = new SolidBrush(Color.White);
        Pen playerPen = new Pen(Color.White);
        Pen pen = new Pen(Color.Red, 2);
        Font gameFont = new Font("Squada One", 20, FontStyle.Regular);
        public static Bitmap[] images = { Properties.Resources.redCar, Properties.Resources.orangeCar, Properties.Resources.yellowCar, Properties.Resources.limeCar,
        Properties.Resources.greenCar, Properties.Resources.tealCar, Properties.Resources.blueCar, Properties.Resources.purpleCar, Properties.Resources. pinkCar,
        Properties.Resources.blackCar, Properties.Resources.greyCar, Properties.Resources.whiteCar };

        public static string[] name1 = { "speedy", "rapid", "angry", "happy", "intelligent", "powerful", "competitive", "fearless", "silly", "extreme", "savage", "mad", "spicy", "lonely", "social", "baby", "old", "high-strung", "reckless" };
        public static string[] name2 = { "cat", "dog", "racer", "cheetah", "eagle", "fish", "unicorn", "driver", "sandwich", "cheese", "pineapple", "guy", "girl", "bee", "pickle", "chili-pepper", "wolf", "racoon", "dodo-bird", "dinosaur", };
        public static List<Car> cars = new List<Car>();
        public static List<Trackpoint> trackpoints = new List<Trackpoint>();
        double mouseX, mouseY;
        double scale = 1;
        int trackSize = 100;
        public const int player1 = 0, player2 = 1;
        public static int elevation = 0;
        int circle = 0;

        public GameScreen()
        {
            InitializeComponent();
            cars.Add(new Car(0, 0, 90, 0, "Max"));
            cars.Add(new Car(-100, 0, 315, random.Next(0, 12), ""));
            cars.Add(new Car(100, 0, 45, random.Next(0, 12), ""));
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            foreach (Car c in cars)
            {
                c.Move();
            }

            scale = Math.Pow(1.1, elevation);

            circle++;
            if (circle >= 20)
            {
                circle = -20;
            }

            Refresh();
        }

        private void GameScreen_MouseClick(object sender, MouseEventArgs e)
        {
            trackpoints.Add(new Trackpoint((int)(mouseX * scale + cars[player1].x), (int)(mouseY * scale + cars[player1].y), 90, Convert.ToInt16(trackSize * 2), trackpoints.Count));
            if (trackpoints.Count > 1)
            {
                trackpoints[trackpoints.Count - 2].direction = Form1.GetDirection(trackpoints[trackpoints.Count - 1].x - trackpoints[trackpoints.Count - 2].x, trackpoints[trackpoints.Count - 1].y - trackpoints[trackpoints.Count - 2].y);
                trackpoints[trackpoints.Count - 1].direction = Form1.GetDirection(trackpoints[0].x - trackpoints[trackpoints.Count - 1].x, trackpoints[0].y - trackpoints[trackpoints.Count - 1].y);

            }
        }

        private void GameScreen_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X - Width / 2;
            mouseY = e.Y - Height / 2;
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            foreach (Trackpoint p in trackpoints)
            {
                e.Graphics.DrawImage(Properties.Resources.Edge, (float)((p.x - cars[player1].x - 11 * p.size / 20) / scale) + Width / 2, (float)((p.y - cars[player1].y - 11 * p.size / 20) / scale) + Height / 2, (float)((p.size + p.size / 10) / scale), (float)((p.size + p.size / 10) / scale));
            }
            foreach (Trackpoint p in trackpoints)
            {
                e.Graphics.FillEllipse(trackColour, (float)((p.x - p.size / 2 - cars[player1].x) / scale) + Width / 2, (float)((p.y - p.size / 2 - cars[player1].y) / scale) + Height / 2, (float)(p.size / scale), (float)(p.size / scale));
                //e.Graphics.DrawLine(pen, p.x, p.y, (float)((p.x - cars[player].x + Math.Sin(p.direction * Math.PI / 180) * p.size / 2) / scale), (float)((p.y - cars[player].y + Math.Cos(p.direction * Math.PI / 180) * p.size / 2) / scale));
            }
            foreach (Trackpoint p in trackpoints)
            {
                e.Graphics.DrawString($"{p.pointNumber}", gameFont, brush, (float)((p.x - cars[player1].x) / scale) + Width / 2, (float)((p.y - cars[player1].y - 10) / scale) + Height / 2);
            }

            foreach (Car c in cars)
            {
                // Player labels
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Far;
                playerBrush.Color = c.playerColour;
                playerPen.Color = c.playerColour;
                playerPen.Width = Math.Abs(circle) / (float)(2 * scale);
                e.Graphics.DrawEllipse(playerPen, (float)((c.x - cars[player1].x - (20 + Math.Abs(circle) / 4)) / scale) + Width / 2, (float)((c.y - cars[player1].y - (20 + Math.Abs(circle) / 4)) / scale) + Height / 2, (float)((40 + Math.Abs(circle) / 2) / scale), (float)((40 + Math.Abs(circle) / 2) / scale));
                e.Graphics.DrawString($"{c.playerName}", gameFont, playerBrush, (float)((c.x - cars[player1].x) / scale) + Width / 2, (float)((c.y - cars[player1].y - 30) / scale) + Height / 2, stringFormat);

                if (c == cars[player1])
                {
                    e.Graphics.TranslateTransform(Width / 2, Height / 2);
                }
                else
                {
                    e.Graphics.TranslateTransform((float)((c.x - cars[player1].x) / scale) + Width / 2, (float)((c.y - cars[player1].y) / scale) + Height / 2);
                }
                e.Graphics.RotateTransform((float)c.direction);
                e.Graphics.DrawImage(c.image, (float)(0 - c.width / 2 / scale), (float)(0 - c.height / 2 / scale), (float)(c.width / scale), (float)(c.height / scale));
                e.Graphics.ResetTransform();

                if (trackpoints.Count > 0)
                {
                    e.Graphics.DrawLine(pen, Width / 2, Height / 2, (float)((trackpoints[c.trackLocation].x - cars[player1].x) / scale) + Width / 2, (float)((trackpoints[c.trackLocation].y - cars[player1].y) / scale) + Height / 2);
                    e.Graphics.DrawString($"{c.trackLocation}", gameFont, brush, 50, 75);
                    e.Graphics.DrawString($"{c.distToTrack}", gameFont, brush, 50, 100);
                }
            }

            e.Graphics.DrawString($"{trackSize}", gameFont, brush, 50, 50);
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    cars[player1].upArrow = true;
                    break;
                case Keys.Down:
                    cars[player1].downArrow = true;
                    break;
                case Keys.Left:
                    cars[player1].leftArrow = true;
                    break;
                case Keys.Right:
                    cars[player1].rightArrow = true;
                    break;
                case Keys.W:
                    cars[player2].upArrow = true;
                    break;
                case Keys.S:
                    cars[player2].downArrow = true;
                    break;
                case Keys.A:
                    cars[player2].leftArrow = true;
                    break;
                case Keys.D:
                    cars[player2].rightArrow = true;
                    break;
                case Keys.I:
                    trackSize++;
                    break;
                case Keys.K:
                    if (trackSize > 0)
                    {
                        trackSize--;
                    }
                    break;
                case Keys.O:
                    elevation++;
                    break;
                case Keys.L:
                    elevation--;
                    break;
                case Keys.Space:
                    cars.Add(new Car(cars[player1].x, cars[player1].y, cars[player1].direction, random.Next(0, 12), ""));
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    cars[player1].upArrow = false;
                    break;
                case Keys.Down:
                    cars[player1].downArrow = false;
                    break;
                case Keys.Left:
                    cars[player1].leftArrow = false;
                    break;
                case Keys.Right:
                    cars[player1].rightArrow = false;
                    break;
                case Keys.W:
                    cars[player2].upArrow = false;
                    break;
                case Keys.S:
                    cars[player2].downArrow = false;
                    break;
                case Keys.A:
                    cars[player2].leftArrow = false;
                    break;
                case Keys.D:
                    cars[player2].rightArrow = false;
                    break;
            }
        }
    }
}
