using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveToSurvive
{
    public class Trackpoint
    {
        public int x, y, size, pointNumber;
        public double direction;
        public Trackpoint(int _x, int _y, double _direction, int _size, int _pointNumber)
        {
            x = _x;
            y = _y;
            size = _size;
            pointNumber = _pointNumber;
            direction = _direction;
        }
    }
}
