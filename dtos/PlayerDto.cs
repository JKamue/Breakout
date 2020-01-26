using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.dtos
{
    class PlayerDto
    {
        public int maxLeft;
        public int maxRight;
        public int distanceTop;
        public int distanceLeft;
        public int width;
        public int height;
        public Color color;

        public PlayerDto(int maxLeft, int maxRight, int distanceTop, int distanceLeft, int width, int height, Color color)
        {
            this.maxLeft = maxLeft;
            this.maxRight = maxRight;
            this.distanceTop = distanceTop;
            this.distanceLeft = distanceLeft;
            this.width = width;
            this.height = height;
            this.color = color;
        }
    }
}
