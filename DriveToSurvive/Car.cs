﻿using System;
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
        public int z, speed, steer, trackLocation, distToTrack, placeNumber, targetLocation = 0;
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
                case 12:
                    playerColour = Color.FromArgb(255, 160, 160);
                    break;
                case 13:
                    playerColour = Color.FromArgb(255, 218, 160);
                    break;
                case 14:
                    playerColour = Color.FromArgb(255, 255, 160);
                    break;
                case 15:
                    playerColour = Color.FromArgb(200, 255, 160);
                    break;
                case 16:
                    playerColour = Color.FromArgb(100, 255, 100);
                    break;
                case 17:
                    playerColour = Color.FromArgb(150, 210, 210);
                    break;
                case 18:
                    playerColour = Color.FromArgb(160, 160, 255);
                    break;
                case 19:
                    playerColour = Color.FromArgb(210, 160, 253);
                    break;
                case 20:
                    playerColour = Color.FromArgb(255, 160, 234);
                    break;
                case 21:
                    playerColour = Color.FromArgb(150, 150, 150);
                    break;
                case 22:
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

            if (GameScreen.cars[GameScreen.player1] != this && GameScreen.cars[GameScreen.player2] != this && GameScreen.trackpoints.Count >= 5)
            {
                CarAI();
            }

            if (speed < 200)
            {
                direction += steer * speed / 150;
            }
            else
            {
                direction += steer * 4 / 3;
            }

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
                distance = Form1.GetDistance(GameScreen.trackpoints[i].x - x, GameScreen.trackpoints[i].y - y);
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
            if (GameScreen.trackpoints.Count >= 5)
            {
                if (trackLocation == targetLocation && distToTrack < GameScreen.trackpoints[trackLocation].size / 2)
                {
                    if (targetLocation == 0)
                    {
                        // car has completed a lap
                    }
                    targetLocation++;
                    if (targetLocation == GameScreen.trackpoints.Count)
                    {
                        targetLocation = 0;
                    }
                }
            }

            CheckCollisions();
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
            upArrow = true;
            downArrow = false;

            //if (distToTrack < GameScreen.trackpoints[trackLocation].size / 2) // Car is on the track
            //{
            //    if (CompareAngles(direction, Form1.GetDirection(GameScreen.trackpoints[targetLocation].x - x, y - GameScreen.trackpoints[targetLocation].y)) < 0)
            //    {
            //        leftArrow = false;
            //        rightArrow = true;
            //    }
            //    else if (CompareAngles(direction, Form1.GetDirection(GameScreen.trackpoints[targetLocation].x - x, y - GameScreen.trackpoints[targetLocation].y)) > 0)
            //    {
            //        leftArrow = true;
            //        rightArrow = false;
            //    }
            //    else
            //    {
            //        rightArrow = false;
            //        leftArrow = false;
            //    }
            //}
            //else // Car is trying to get to the trackpoint it's at
            //{
            //    if (CompareAngles(direction, Form1.GetDirection(GameScreen.trackpoints[trackLocation].x - x, y - GameScreen.trackpoints[trackLocation].y)) < 0)
            //    {
            //        leftArrow = false;
            //        rightArrow = true;
            //    }
            //    else if (CompareAngles(direction, Form1.GetDirection(GameScreen.trackpoints[trackLocation].x - x, y - GameScreen.trackpoints[trackLocation].y)) > 0)
            //    {
            //        leftArrow = true;
            //        rightArrow = false;
            //    }
            //    else
            //    {
            //        rightArrow = false;
            //        leftArrow = false;
            //    }
            //}
            if (CompareAngles(direction, Form1.GetDirection(GameScreen.trackpoints[targetLocation].x - x, y - GameScreen.trackpoints[targetLocation].y)) < 0)
            {
                leftArrow = false;
                rightArrow = true;
            }
            else if (CompareAngles(direction, Form1.GetDirection(GameScreen.trackpoints[targetLocation].x - x, y - GameScreen.trackpoints[targetLocation].y)) > 0)
            {
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
            b += 180;
            if (b - a < 180 && b - a > -180)
            {
                return 100 * Math.Sin((b - a) / 2 * Math.PI / 180);
            }
            else
            {
                return -100 * Math.Sin((b - a) / 2 * Math.PI / 180);
            }
        }

        public void CheckCollisions()
        {
            foreach (Car c in GameScreen.cars)
            {
                if (Form1.GetDistance(c.x - x, c.y - y) < 60 && c != this)
                {
                    c.speed /= 2;
                    speed /= 2;
                    c.x += (c.x - x) / 2;
                    c.y += (c.y - y) / 2;
                    x += (x - c.x) / 2;
                    y += (y - c.y) / 2;
                }
            }
        }
    }
}
