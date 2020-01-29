using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Breakout.classes;
using Breakout.events;

namespace Breakout
{
    class GridController
    {
        private Form Screen;

        private int Width;
        private int Height;
        private int Top;
        private int Left;

        private int Rows;
        private int Cols;

        private int BreakableBlocks;
        private int BrokenBlocks;

        public bool GameOver() => BrokenBlocks == BreakableBlocks;

        public Block[,] Grid { get; private set; }

        private Size BlockSize;

        public event AllBlocksDestroyedEventHandler OnAllBlocksDestroyed;

        public GridController(Form screen, int width, int height, int top, int left, int rows, int cols)
        {
            this.Screen = screen;

            this.Width = width;
            this.Height = height;
            this.Top = top;
            this.Left = left;

            this.Rows = rows;
            this.Cols = cols;

            this.BlockSize = new Size(width / cols, height / rows);

            this.Grid = new Block[cols,rows];
        }

        public void SelfDestruct()
        {
            foreach (var block in Grid)
            {
                if (block == null)
                {
                    continue;
                }
                Screen.Controls.Remove(block);
            }
        }

        public void AddBlock(GridCoordinate coord, Color color, bool breakable, int speedAfterCollision, int colspan,
            int rowspan, int margin, int marginType)
        {
            if (!CoordinateInGrid(coord))
            {
                throw new CoordinatesOutOfBoundsException($"Coordinate {coord.X}/{coord.Y} is not in Grid {this.Cols - 1}/{this.Rows - 1}");
            }

            var mHeight = 0;
            var mWidth = 0;
            switch (marginType)
            {
                case 1:
                    mHeight = margin;
                    mWidth = margin;
                    break;
                case 2:
                    mHeight = margin;
                    break;
                case 3:
                    mWidth = margin;
                    break;
            }

            var distanceTop = this.Top + coord.Y * this.BlockSize.Height + mHeight;
            var distanceLeft = this.Left + coord.X * this.BlockSize.Width + mWidth;

            if (this.Grid[coord.X, coord.Y] != null)
            {
                this.Screen.Controls.Remove(this.Grid[coord.X, coord.Y]);
            }
            
            var realBlockSize = new Size(
                this.BlockSize.Width * colspan - mWidth,
                this.BlockSize.Height * rowspan - mHeight);

            var block = new Block(distanceTop, distanceLeft, realBlockSize, color, breakable, speedAfterCollision);
            this.Grid[coord.X, coord.Y] = block;
            this.Screen.Controls.Add(block);

            if (breakable)
            {
                BreakableBlocks++;
            }
        }

        public void BreakBlock(Block block)
        {
            Screen.Controls.Remove(block);
            block.Broken = true;
            BrokenBlocks++;

            if (BrokenBlocks == BreakableBlocks)
            {
                OnAllBlocksDestroyed?.Invoke(this, new AllBlocksDestroyedEventArgs());
            }
        }

        public bool CoordinateInGrid(GridCoordinate coord)
        {
            return coord.X < this.Cols && coord.Y < this.Rows;
        }
    }
}
