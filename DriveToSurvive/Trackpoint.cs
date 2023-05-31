using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveToSurvive
{
    public class Trackpoint
    {
        public int x, y, size;
        public double direction;
        public Trackpoint(int _x, int _y, double _direction, int _size)
        {
            x = _x;
            y = _y;
            direction = _direction;
            size = _size;
        }
    }
}
