using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.dtos
{
    class GridDto
    {
        public List<BlockDto> blocks;
        public int width;
        public int height;

        public GridDto(List<BlockDto> blocks, int width, int height)
        {
            this.blocks = blocks;
            this.width = width;
            this.height = height;   
        }
    }
}
