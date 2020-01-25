using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.classes
{
    class GridCoordinate
    {
        public int X;
        public int Y;

        public GridCoordinate(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                throw new CoordinatesOutOfBoundsException("Grid Coordinates have to be bigger or equal to zero!");
            }

            this.X = x;
            this.Y = y;
        }
    }
}
