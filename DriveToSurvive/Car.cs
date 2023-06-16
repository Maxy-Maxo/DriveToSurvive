using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace DriveToSurvive
{
    public class Car
    {
        public int z, speed, steer, trackLocation, distToTrack, placeNumber = 0;
        public double xSpeed, ySpeed, direction, x, y, prevXSpeed, prevYSpeed = 0;
        public int width = 30, height = 50;
        public bool upArrow, downArrow, leftArrow, rightArrow;
        public string playerName;
        public Bitmap image;
        public Color playerColour;

        public Car(double _x, double _y, double _dirction, int _image, string _nickname)
        {
            x = _x;
            y = _y;
            direction = _dirction;
            image = GameScreen.images[_image];

            if (_nickname != "")
            {
                playerName = _nickname;
            }
            else
            {
                playerName = $"{GameScreen.name1[GameScreen.random.Next(0, GameScreen.name1.Length)]}_{GameScreen.name2[GameScreen.random.Next(0, GameScreen.name2.Length)]}{GameScreen.random.Next(10, 100)}";
            }

            switch (_image)
            {
                case 0:
                    playerColour = Color.FromArgb(255, 160, 160);
                    break;
                case 1:
                    playerColour = Color.FromArgb(255, 218, 160);
                    break;
                case 2:
                    playerColour = Color.FromArgb(255, 255, 160);
                    break;
                case 3:
                    playerColour = Color.FromArgb(200, 255, 160);
                    break;
                case 4:
                    playerColour = Color.FromArgb(100, 255, 100);
                    break;
                case 5:
                    playerColour = Color.FromArgb(150, 210, 210);
                    break;
                case 6:
                    playerColour = Color.FromArgb(160, 160, 255);
                    break;
                case 7:
                    playerColour = Color.FromArgb(210, 160, 253);
                    break;
                case 8:
                    playerColour = Color.FromArgb(255, 160, 234);
                    break;
                case 9:
                    playerColour = Color.FromArgb(150, 150, 150);
                    break;
                case 10:
                    playerColour = Color.FromArgb(200, 200, 200);
                    break;
                default:
                    playerColour = Color.White;
                    break;
            }
        }

        public void Move()
        {
            if (upArrow && !downArrow)
            {
                speed++;
            }
            else if (!upArrow && downArrow)
            {
                speed--;
            }

            if (leftArrow && !rightArrow && steer >= -4)
            {
                steer--;
            }
            else if (!leftArrow && rightArrow && steer <= 4)
            {
                steer++;
            }

            if (speed != 0 && (!upArrow && !downArrow || (upArrow && downArrow)))
            {
                if (speed > 0)
                {
                    speed--;
                }
                else
                {
                    speed++;
                }
            }

            if (steer != 0 && (!leftArrow && !rightArrow || (leftArrow && rightArrow)))
            {
                if (steer > 0)
                {
                    steer--;
                }
                else
                {
                    steer++;
                }
            }

            if (GameScreen.cars[GameScreen.player] != this && GameScreen.trackpoints.Count >= 5)
            {
                CarAI();
            }

            direction += steer * speed / 150;

            if (direction >= 360)
            {
                direction -= 360;
            }
            if (direction < 0)
            {
                direction += 360;
            }
            prevXSpeed = xSpeed * 10;
            prevYSpeed = ySpeed * 10;
            SetSpeed(direction);
            direction = Form1.GetDirection(xSpeed, ySpeed);

            x += xSpeed * speed / 20;
            y -= ySpeed * speed / 20;

            //double n = Math.Sqrt(((GameScreen.trackpoints[30].x - x) * (GameScreen.trackpoints[30].x - x)) + ((GameScreen.trackpoints[30].y - y) * (GameScreen.trackpoints[30].y - y)));

            distToTrack = 0;
            double distance;
            for (int i = 0; i < GameScreen.trackpoints.Count; i++)
            {
                distance = Math.Sqrt(((GameScreen.trackpoints[i].x - x) * (GameScreen.trackpoints[i].x - x)) + ((GameScreen.trackpoints[i].y - y) * (GameScreen.trackpoints[i].y - y)));
                if (distance < distToTrack || distToTrack == 0)
                {
                    distToTrack = (int)distance;

                    if (distToTrack == 0)
                    {
                        distToTrack = 1;
                    }
                    trackLocation = i;
                }
            }
        }

        public void SetSpeed()
        {
            double direction = Form1.GetDirection(xSpeed, ySpeed);
            xSpeed = Math.Sin(direction * Math.PI / 180);
            ySpeed = Math.Cos(direction * Math.PI / 180);
        }

        public void SetSpeed(double direction)
        {
            xSpeed = Math.Sin(direction * Math.PI / 180);
            ySpeed = Math.Cos(direction * Math.PI / 180);
        }

        public void CarAI()
        {
            if (Math.Abs(CompareAngles(direction, GameScreen.trackpoints[trackLocation + 1].direction)) >= 70 || Math.Abs(CompareAngles(direction, GameScreen.trackpoints[trackLocation + 2].direction)) >= 86)
            {
                if (speed > 90)
                {
                    upArrow = false;
                    downArrow = true;
                }
                else
                {
                    upArrow = true;
                    downArrow = false;
                }
            }
            else
            {
                upArrow = true;
                downArrow = false;
            }

            if (CompareAngles(direction, GameScreen.trackpoints[trackLocation].direction) < 0)
            {
                leftArrow = false;
                rightArrow = true;
            }
            else if (CompareAngles(direction, GameScreen.trackpoints[trackLocation].direction) > 0)
            {
                Console.WriteLine(">0 " + direction);
                leftArrow = true;
                rightArrow = false;
            }
            else
            {
                rightArrow = false;
                leftArrow = false;
            }
        }

        public double CompareAngles(double a, double b)
        {
            if (a + b < 180 && a + b > -180)
            {
                return -100 * Math.Sin((a + b) / 2 * Math.PI / 180);
            }
            else
            {
                return 100 * Math.Sin((a + b) / 2 * Math.PI / 180);
            }
        }
    }
}
