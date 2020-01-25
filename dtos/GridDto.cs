using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.dtos
{
    class GridDto
    {
        public List<BlockDto> blocks;
        public Color backColor;
        public int width;
        public int height;
        public int pxWidth;
        public int pxHeight;

        public GridDto(List<BlockDto> blocks, Color backColor, int width, int height, int pxWidth, int pxHeight)
        {
            this.blocks = blocks;
            this.backColor = backColor;
            this.width = width;
            this.height = height;
            this.pxWidth = pxWidth;
            this.pxHeight = pxHeight;
        }
    }
}
