using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveToSurvive
{
    public class Car
    {
        int x, y, direction;
        int z, speed, trackLocation, placeNumber = 0;

        public Car(int _x, int _y, int _dirction)
        {
            x = _x;
            y = _y;
            direction = _dirction;
        }

        public void Move()
        {

        }
    }
}
