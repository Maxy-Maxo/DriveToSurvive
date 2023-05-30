using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DriveToSurvive
{
    public class Car
    {
        public int z, speed, steer, trackLocation, placeNumber = 0;
        public double xSpeed, ySpeed, direction, x, y = 0;
        public int width = 30;
        public int height = 50;

        public Car(double _x, double _y, double _dirction)
        {
            x = _x;
            y = _y;
            direction = _dirction;
        }

        public void Move()
        {
            if (speed > 0)
            {
                direction += steer;
            }
            else if (speed < 0)
            {
                direction -= steer;
            }

            if (direction >= 360)
            {
                direction -= 360;
            }
            if (direction < 0)
            {
                direction += 360;
            }
            SetSpeed(direction);
            direction = GetDirection(xSpeed, ySpeed);

            x += xSpeed * speed / 10;
            y -= ySpeed * speed / 10;
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

                //if (ySpeed < 0)
                //{
                //    direction += 180;
                //}

                return direction;
            }
        }

        public void SetSpeed()
        {
            double direction = GetDirection(xSpeed, ySpeed);
            xSpeed = Math.Sin(direction * Math.PI / 180);
            ySpeed = Math.Cos(direction * Math.PI / 180);
        }

        public void SetSpeed(double direction)
        {
            xSpeed = Math.Sin(direction * Math.PI / 180);
            ySpeed = Math.Cos(direction * Math.PI / 180);
        }
    }
}
