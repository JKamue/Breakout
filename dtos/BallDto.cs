using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.dtos
{
    class BallDto
    {
        public int startVelocity;
        public int size;
        public int spawnXmin;
        public int spawnXmax;
        public int spawnYmin;
        public int spawnYmax;
        public Color color;

        public BallDto(int startVelocity, int size, int spawnXmin, int spawnXmax, int spawnYmin, int spawnYmax, Color color)
        {
            this.startVelocity = startVelocity;
            this.size = size;
            this.spawnXmin = spawnXmin;
            this.spawnXmax = spawnXmax;
            this.spawnYmin = spawnYmin;
            this.spawnYmax = spawnYmax;
            this.color = color;
        }
    }
}
