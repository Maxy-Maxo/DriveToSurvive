using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveToSurvive
{
    public class Trackpoint
    {
        public int x, y, direction, size;
        public Trackpoint(int _x, int _y, int _direction, int _size)
        {
            x = _x;
            y = _y;
            direction = _direction;
            size = _size;
        }
    }
}
