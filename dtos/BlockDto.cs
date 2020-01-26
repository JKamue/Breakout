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
        public int colspan;
        public int rowspan;

        public BlockDto(int x, int y, Color color, bool breaks, int speed, int colspan, int rowspan)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            this.breaks = breaks;
            this.speed = speed;
            this.colspan = colspan;
            this.rowspan = rowspan;
        }
    }
}
