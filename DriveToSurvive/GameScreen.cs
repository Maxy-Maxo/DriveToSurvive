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
        SolidBrush trackEdge = new SolidBrush(Color.Red);
        SolidBrush playerBrush = new SolidBrush(Color.White);
        Pen playerPen = new Pen(Color.White);
        Pen pen = new Pen(Color.Red, 2);
        Font gameFont = new Font("Squada One", 20, FontStyle.Regular);
        public static Bitmap[] images = { Properties.Resources.redCar, Properties.Resources.orangeCar, Properties.Resources.yellowCar, Properties.Resources.limeCar,
        Properties.Resources.greenCar, Properties.Resources.tealCar, Properties.Resources.blueCar, Properties.Resources.purpleCar, Properties.Resources. pinkCar,
        Properties.Resources.blackCar, Properties.Resources.greyCar, Properties.Resources.whiteCar, Properties.Resources.redHatch, Properties.Resources.orangeHatch, Properties.Resources.yellowHatch, Properties.Resources.limeHatch,
        Properties.Resources.greenHatch, Properties.Resources.tealHatch, Properties.Resources.blueHatch, Properties.Resources.purpleHatch, Properties.Resources. pinkHatch,
        Properties.Resources.blackHatch, Properties.Resources.greyHatch, Properties.Resources.whiteHatch };

        public static string[] name1 = { "speedy", "rapid", "angry", "happy", "intelligent", "powerful", "competitive", "fearless", "silly", "extreme", "savage", "mad", "spicy", "lonely", "social", "baby", "old", "high-strung", "reckless", "superior", "awesome", "flaming-hot", "ice-cold", "awakened", "suspicious", "lovely", "sporty", "chill" };
        public static string[] name2 = { "cat", "dog", "racer", "cheetah", "eagle", "fish", "unicorn", "driver", "sandwich", "cheese", "pineapple", "guy", "girl", "bee", "pickle", "chili-pepper", "wolf", "racoon", "dodo-bird", "dinosaur", "turtle", "man", "woman", "fella", "caterpillar", "marshmallow", "salamander" };
        public static List<Car> cars = new List<Car>();
        public static List<Trackpoint> trackpoints = new List<Trackpoint>();
        double mouseX, mouseY;
        double scale = 1;
        int trackSize = 100;
        public const int player1 = 0, player2 = 1;
        public static int elevation = 0;
        int circle = 0;
        int cameraX, cameraY = 0;

        public GameScreen()
        {
            InitializeComponent();
            cars.Add(new Car(0, 0, 90, 0, "Player1"));
            cars.Add(new Car(-100, 0, 315, 2, "Player2"));
            cars.Add(new Car(100, 0, 45, random.Next(0, 24), ""));
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
            cameraX = (int)((cars[player1].x + cars[player2].x) / 2);
            cameraY = (int)((cars[player1].y + cars[player2].y) / 2);

            Refresh();
        }

        private void GameScreen_MouseClick(object sender, MouseEventArgs e)
        {
            trackpoints.Add(new Trackpoint((int)(mouseX * scale + cameraX), (int)(mouseY * scale + cameraY), 90, Convert.ToInt16(trackSize * 2), trackpoints.Count));
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
            e.Graphics.DrawEllipse(pen, (float)((mouseX + Width / 2) - trackSize / scale), (float)((mouseY + Height / 2) - trackSize / scale), (float)(trackSize * 2 / scale), (float)(trackSize * 2 / scale));
            foreach (Trackpoint p in trackpoints)
            {
                Trackpoint p2 = trackpoints[0];
                if (p != trackpoints[trackpoints.Count - 1])
                {
                    for (int i = 0; i < trackpoints.Count; i++)
                    {
                        if (p == trackpoints[i])
                        {
                            p2 = trackpoints[i + 1];
                        }
                    }
                }
                Point point1 = new Point((int)((p.x - cameraX + Math.Sin((p.direction - 90) * Math.PI / 180) * p.size / 2) / scale) + Width / 2, (int)((p.y - cameraY + Math.Cos((p.direction - 90) * Math.PI / 180) * p.size / 2) / scale) + Height / 2);
                Point point2 = new Point((int)((p2.x - cameraX + Math.Sin((p.direction - 90) * Math.PI / 180) * p2.size / 2) / scale) + Width / 2, (int)((p2.y - cameraY + Math.Cos((p.direction - 90) * Math.PI / 180) * p2.size / 2) / scale) + Height / 2);
                Point point3 = new Point((int)((p2.x - cameraX + Math.Sin((p.direction - 90) * Math.PI / 180) * 11 * p2.size / 20) / scale) + Width / 2, (int)((p2.y - cameraY + Math.Cos((p.direction - 90) * Math.PI / 180) * 11 * p2.size / 20) / scale) + Height / 2);
                Point point4 = new Point((int)((p.x - cameraX + Math.Sin((p.direction - 90) * Math.PI / 180) * 11 * p.size / 20) / scale) + Width / 2, (int)((p.y - cameraY + Math.Cos((p.direction - 90) * Math.PI / 180) * 11 * p.size / 20) / scale) + Height / 2);

                Point point5 = new Point((int)((p.x - cameraX + Math.Sin((p.direction + 90) * Math.PI / 180) * p.size / 2) / scale) + Width / 2, (int)((p.y - cameraY + Math.Cos((p.direction + 90) * Math.PI / 180) * p.size / 2) / scale) + Height / 2);
                Point point6 = new Point((int)((p2.x - cameraX + Math.Sin((p.direction + 90) * Math.PI / 180) * p2.size / 2) / scale) + Width / 2, (int)((p2.y - cameraY + Math.Cos((p.direction + 90) * Math.PI / 180) * p2.size / 2) / scale) + Height / 2);
                Point point7 = new Point((int)((p2.x - cameraX + Math.Sin((p.direction + 90) * Math.PI / 180) * 11 * p2.size / 20) / scale) + Width / 2, (int)((p2.y - cameraY + Math.Cos((p.direction + 90) * Math.PI / 180) * 11 * p2.size / 20) / scale) + Height / 2);
                Point point8 = new Point((int)((p.x - cameraX + Math.Sin((p.direction + 90) * Math.PI / 180) * 11 * p.size / 20) / scale) + Width / 2, (int)((p.y - cameraY + Math.Cos((p.direction + 90) * Math.PI / 180) * 11 * p.size / 20) / scale) + Height / 2);

                Point[] points1 = { point1, point2, point3, point4 };
                Point[] points2 = { point5, point6, point7, point8 };

                e.Graphics.FillPolygon(trackEdge, points1);
                e.Graphics.FillPolygon(trackEdge, points2);

                //double edgeLength = Form1.GetDistance(p2.x - p.x, p2.y - p2.y);
                //double edgeWidth = (p.size + p2.size) / 30;
                //Point location = new Point((int)(((p.x + p2.x) / 2 - cameraX + Math.Sin((p.direction - 90) * Math.PI / 180) * p.size / 2) / scale) + Width / 2, (int)(((p.y + p2.y) / 2 - cameraY + Math.Cos((p.direction - 90) * Math.PI / 180) * p.size / 2) / scale) + Height / 2);

                //e.Graphics.TranslateTransform(location.X, location.Y);
                //e.Graphics.RotateTransform((float)(Form1.GetDirection(p2.x - p.x, p2.y - p.y)));
                //e.Graphics.DrawImage(Properties.Resources.Edge2, location.X, location.Y, (float)edgeLength, (float)edgeWidth);
                //e.Graphics.ResetTransform();

                e.Graphics.DrawImage(Properties.Resources.Edge, (float)((p.x - cameraX - 11 * p.size / 20) / scale) + Width / 2, (float)((p.y - cameraY - 11 * p.size / 20) / scale) + Height / 2, (float)((p.size + p.size / 10) / scale), (float)((p.size + p.size / 10) / scale));
            }
            foreach (Trackpoint p in trackpoints)
            {
                e.Graphics.FillEllipse(trackColour, (float)((p.x - p.size / 2 - cameraX) / scale) + Width / 2, (float)((p.y - p.size / 2 - cameraY) / scale) + Height / 2, (float)(p.size / scale), (float)(p.size / scale));
                Trackpoint p2 = trackpoints[0];
                if (p != trackpoints[trackpoints.Count - 1])
                {
                    for (int i = 0; i < trackpoints.Count; i++)
                    {
                        if (p == trackpoints[i])
                        {
                            p2 = trackpoints[i + 1];
                        }
                    }
                }
                //e.Graphics.DrawLine(pen, (float)((p.x - cameraX) / scale) + Width / 2, (float)((p.y - cameraY) / scale) + Height / 2, (float)((p.x - cameraX + Math.Sin(p.direction * Math.PI / 180) * p.size / 2) / scale) + Width / 2, (float)((p.y - cameraY + Math.Cos(p.direction * Math.PI / 180) * p.size / 2) / scale) + Height / 2);
                Point point1 = new Point((int)((p.x - cameraX + Math.Sin((p.direction - 90) * Math.PI / 180) * p.size / 2) / scale) + Width / 2, (int)((p.y - cameraY + Math.Cos((p.direction - 90) * Math.PI / 180) * p.size / 2) / scale) + Height / 2);
                Point point2 = new Point((int)((p.x - cameraX + Math.Sin((p.direction + 90) * Math.PI / 180) * p.size / 2) / scale) + Width / 2, (int)((p.y - cameraY + Math.Cos((p.direction + 90) * Math.PI / 180) * p.size / 2) / scale) + Height / 2);
                Point point3 = new Point((int)((p2.x - cameraX + Math.Sin((p.direction + 90) * Math.PI / 180) * p2.size / 2) / scale) + Width / 2, (int)((p2.y - cameraY + Math.Cos((p.direction + 90) * Math.PI / 180) * p2.size / 2) / scale) + Height / 2);
                Point point4 = new Point((int)((p2.x - cameraX + Math.Sin((p.direction - 90) * Math.PI / 180) * p2.size / 2) / scale) + Width / 2, (int)((p2.y - cameraY + Math.Cos((p.direction - 90) * Math.PI / 180) * p2.size / 2) / scale) + Height / 2);
                Point[] points = { point1, point2, point3, point4 };
                e.Graphics.FillPolygon(trackColour, points);
            }
            foreach (Trackpoint p in trackpoints)
            {
                e.Graphics.DrawString($"{p.pointNumber}", gameFont, brush, (float)((p.x - cameraX) / scale) + Width / 2, (float)((p.y - cameraY - 10) / scale) + Height / 2);
            }

            foreach (Car c in cars)
            {
                // Player labels
                StringFormat stringFormat = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Far
                };
                playerBrush.Color = c.playerColour;
                playerPen.Color = c.playerColour;
                playerPen.Width = Math.Abs(circle) / (float)(2 * scale);
                if (elevation < 30)
                {
                    e.Graphics.DrawEllipse(playerPen, (float)((c.x - cameraX - (20 + Math.Abs(circle) / 4)) / scale) + Width / 2, (float)((c.y - cameraY - (20 + Math.Abs(circle) / 4)) / scale) + Height / 2, (float)((40 + Math.Abs(circle) / 2) / scale), (float)((40 + Math.Abs(circle) / 2) / scale));
                }
                e.Graphics.DrawString($"{c.playerName}", gameFont, playerBrush, (float)((c.x - cameraX) / scale) + Width / 2, (float)((c.y - cameraY - 30) / scale) + Height / 2, stringFormat);

                e.Graphics.TranslateTransform((float)((c.x - cameraX) / scale) + Width / 2, (float)((c.y - cameraY) / scale) + Height / 2);
                e.Graphics.RotateTransform((float)c.direction);
                e.Graphics.DrawImage(c.image, (float)(0 - c.width / 2 / scale), (float)(0 - c.height / 2 / scale), (float)(c.width / scale), (float)(c.height / scale));
                e.Graphics.ResetTransform();

                //if (trackpoints.Count > 0)
                //{
                //    //e.Graphics.DrawLine(pen, Width / 2, Height / 2, (float)((trackpoints[c.trackLocation].x - cameraX) / scale) + Width / 2, (float)((trackpoints[c.trackLocation].y - cameraY) / scale) + Height / 2); // Draws line to nearest point on track
                //    e.Graphics.DrawString($"{c.trackLocation}", gameFont, brush, 50, 75);
                //    e.Graphics.DrawString($"{c.distToTrack}", gameFont, brush, 50, 100);
                //}
            }

            e.Graphics.DrawString($"Track Size: {trackSize}", gameFont, brush, 50, 50);
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            if (helpText.Visible)
            {
                helpText.Visible = false;
                helpButton.BackColor = Color.DimGray;
            }
            else
            {
                helpText.Visible = true;
                helpButton.BackColor = Color.FromArgb(50, 50, 50);
            }
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
                    trackSize += 5;
                    break;
                case Keys.K:
                    if (trackSize > 0)
                    {
                        trackSize -= 5;
                    }
                    break;
                case Keys.O:
                    elevation--;
                    break;
                case Keys.L:
                    elevation++;
                    break;
                case Keys.Space:
                    cars.Add(new Car(cars[player1].x, cars[player1].y, cars[player1].direction, random.Next(0, 24), ""));
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
