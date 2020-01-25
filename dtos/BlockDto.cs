using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.dtos
{
    class BlockDto
    {
        public int x;
        public int y;
        public Color color;
        public bool breaks;
        public int speed;

        public BlockDto(int x, int y, Color color, bool breaks, int speed)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            this.breaks = breaks;
            this.speed = speed;
        }
    }
}
