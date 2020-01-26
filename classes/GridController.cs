using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Breakout.classes;

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

        public Block[,] Grid { get; private set; }

        private Size BlockSize;

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

        public void AddBlock(GridCoordinate coord, Color color, bool breakable, int speedAfterCollision)
        {
            if (!CoordinateInGrid(coord))
            {
                throw new CoordinatesOutOfBoundsException($"Coordinate {coord.X}/{coord.Y} is not in Grid {this.Cols - 1}/{this.Rows - 1}");
            }

            var distanceTop = this.Top + coord.Y * this.BlockSize.Height;
            var distanceLeft = this.Left + coord.X * this.BlockSize.Width;

            if (this.Grid[coord.X, coord.Y] != null)
            {
                this.Screen.Controls.Remove(this.Grid[coord.X, coord.Y]);
            }
            var block = new Block(distanceTop, distanceLeft, this.BlockSize, color, breakable, speedAfterCollision);
            this.Grid[coord.X, coord.Y] = block;
            this.Screen.Controls.Add(block);
        }

        public bool CoordinateInGrid(GridCoordinate coord)
        {
            return coord.X < this.Cols && coord.Y < this.Rows;
        }
    }
}
