using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Breakout.classes;
using Breakout.dtos;
using Newtonsoft.Json;

namespace Breakout
{
    public partial class Screen : Form
    {
        public Screen()
        {
            InitializeComponent();
        }

        private void Screen_Load(object sender, EventArgs e)
        {
            var gameSettings = "{ \r\nwidth: 21,\r\nheight: 21,\r\npxWidth: 750,\r\npxHeight: 500,\r\nbackColor: \"#000000\",\r\nblocks: [\r\n    {\"x\": 0,\"y\": 0,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 0,\"y\": 1,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 0,\"y\": 2,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 0,\"y\": 3,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 0,\"y\": 4,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 0,\"y\": 5,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 0,\"y\": 6,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 0,\"y\": 7,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 0,\"y\": 8,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 0,\"y\": 9,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 0,\"y\": 10,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 0,\"y\": 11,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 0,\"y\": 12,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 0,\"y\": 13,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 0,\"y\": 14,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 0,\"y\": 15,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 0,\"y\": 16,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 0,\"y\": 17,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 0,\"y\": 18,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 0,\"y\": 19,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n\t\r\n\t{\"x\": 20,\"y\": 1,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 20,\"y\": 2,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 20,\"y\": 3,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 20,\"y\": 4,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 20,\"y\": 5,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 20,\"y\": 6,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 20,\"y\": 7,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 20,\"y\": 8,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 20,\"y\": 9,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 20,\"y\": 10,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 20,\"y\": 11,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 20,\"y\": 12,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 20,\"y\": 13,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 20,\"y\": 14,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 20,\"y\": 15,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 20,\"y\": 16,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 20,\"y\": 17,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 20,\"y\": 18,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 20,\"y\": 19,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n\t\r\n    {\"x\": 1,\"y\": 0,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 2,\"y\": 0,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 3,\"y\": 0,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 4,\"y\": 0,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 5,\"y\": 0,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 6,\"y\": 0,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 7,\"y\": 0,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 8,\"y\": 0,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 9,\"y\": 0,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 10,\"y\": 0,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 11,\"y\": 0,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 12,\"y\": 0,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 13,\"y\": 0,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 14,\"y\": 0,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 15,\"y\": 0,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 16,\"y\": 0,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 17,\"y\": 0,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 18,\"y\": 0,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 19,\"y\": 0,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n    {\"x\": 20,\"y\": 0,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 1},\r\n\t\r\n    {\"x\": 1,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 5},\r\n    {\"x\": 2,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 5},\r\n    {\"x\": 3,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 5},\r\n    {\"x\": 4,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 5},\r\n    {\"x\": 5,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 5},\r\n    {\"x\": 6,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 5},\r\n    {\"x\": 7,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 5},\r\n    {\"x\": 8,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 5},\r\n    {\"x\": 9,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 5},\r\n    {\"x\": 10,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 5},\r\n    {\"x\": 11,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 5},\r\n    {\"x\": 12,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 5},\r\n    {\"x\": 13,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 5},\r\n    {\"x\": 14,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 5},\r\n    {\"x\": 15,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 5},\r\n    {\"x\": 16,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 5},\r\n    {\"x\": 17,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 5},\r\n    {\"x\": 18,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 5},\r\n    {\"x\": 19,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 5},\r\n\t\r\n    {\"x\": 1,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 4},\r\n    {\"x\": 2,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 4},\r\n    {\"x\": 3,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 4},\r\n    {\"x\": 4,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 4},\r\n    {\"x\": 5,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 4},\r\n    {\"x\": 6,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 4},\r\n    {\"x\": 7,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 4},\r\n    {\"x\": 8,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 4},\r\n    {\"x\": 9,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 4},\r\n    {\"x\": 10,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 4},\r\n    {\"x\": 11,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 4},\r\n    {\"x\": 12,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 4},\r\n    {\"x\": 13,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 4},\r\n    {\"x\": 14,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 4},\r\n    {\"x\": 15,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 4},\r\n    {\"x\": 16,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 4},\r\n    {\"x\": 17,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 4},\r\n    {\"x\": 18,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 4},\r\n    {\"x\": 19,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 4},\r\n\t\r\n    {\"x\": 1,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 3},\r\n    {\"x\": 2,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 3},\r\n    {\"x\": 3,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 3},\r\n    {\"x\": 4,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 3},\r\n    {\"x\": 5,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 3},\r\n    {\"x\": 6,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 3},\r\n    {\"x\": 7,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 3},\r\n    {\"x\": 8,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 3},\r\n    {\"x\": 9,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 3},\r\n    {\"x\": 10,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 3},\r\n    {\"x\": 11,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 3},\r\n    {\"x\": 12,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 3},\r\n    {\"x\": 13,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 3},\r\n    {\"x\": 14,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 3},\r\n    {\"x\": 15,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 3},\r\n    {\"x\": 16,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 3},\r\n    {\"x\": 17,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 3},\r\n    {\"x\": 18,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 3},\r\n    {\"x\": 19,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 3},\r\n\t\r\n    {\"x\": 1,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 2},\r\n    {\"x\": 2,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 2},\r\n    {\"x\": 3,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 2},\r\n    {\"x\": 4,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 2},\r\n    {\"x\": 5,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 2},\r\n    {\"x\": 6,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 2},\r\n    {\"x\": 7,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 2},\r\n    {\"x\": 8,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 2},\r\n    {\"x\": 9,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 2},\r\n    {\"x\": 10,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 2},\r\n    {\"x\": 11,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 2},\r\n    {\"x\": 12,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 2},\r\n    {\"x\": 13,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 2},\r\n    {\"x\": 14,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 2},\r\n    {\"x\": 15,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 2},\r\n    {\"x\": 16,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 2},\r\n    {\"x\": 17,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 2},\r\n    {\"x\": 18,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 2},\r\n    {\"x\": 19,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 2},\r\n\t\r\n    {\"x\": 1,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 1},\r\n    {\"x\": 2,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 1},\r\n    {\"x\": 3,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 1},\r\n    {\"x\": 4,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 1},\r\n    {\"x\": 5,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 1},\r\n    {\"x\": 6,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 1},\r\n    {\"x\": 7,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 1},\r\n    {\"x\": 8,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 1},\r\n    {\"x\": 9,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 1},\r\n    {\"x\": 10,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 1},\r\n    {\"x\": 11,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 1},\r\n    {\"x\": 12,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 1},\r\n    {\"x\": 13,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 1},\r\n    {\"x\": 14,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 1},\r\n    {\"x\": 15,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 1},\r\n    {\"x\": 16,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 1},\r\n    {\"x\": 17,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 1},\r\n    {\"x\": 18,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 1},\r\n    {\"x\": 19,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 1},\r\n]}";
            var grid = JsonConvert.DeserializeObject<GridDto>(gameSettings);

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.BackColor = grid.backColor;
            this.Width = grid.pxWidth;
            this.Height = grid.pxHeight;

            this.gridController = new GridController(this, grid.pxWidth, grid.pxHeight, 0, 0, grid.height, grid.width);

            foreach (var block in grid.blocks)
            {
                this.gridController.AddBlock(
                    new GridCoordinate(block.x, block.y),
                    block.color,
                    block.breaks,
                    block.speed);
            }

            this.timer = new Timer();
            this.timer.Tick += new System.EventHandler(this.UpdateBallPosition);
            this.timer.Interval = 10;
            this.timer.Enabled = true;

            ball = new Block(0,0, new Size(15,15), Color.Red, false, 1);
            //other = new Block(200,250, new Size(150, 80), Color.Blue,false, 1);
            this.Controls.Add(ball);
            this.Controls.Add(other);
        }

        private GridController gridController;

        private Block ball;
        private Block other;

        private Timer timer;

        private int vecX = -1;
        private int vecY = -1;

        private int posY = 260;
        private int posX = 360;
        /**private int posY = 260;
        private int posX = 360;**/

        private void UpdateBallPosition(object sender, EventArgs e)
        {
            this.posY += this.vecX;
            this.posX += this.vecY;
            ball.Top = posY;
            ball.Left = posX;

            if (ball.Top + ball.Height + 30 > this.Height)
            {
                this.vecX *= -1;
            }
            if (ball.Left + ball.Width + 10 > this.Width)
            {
                this.vecY *= -1;
            }
            if (ball.Top < 0)
            {
                this.vecX *= -1;
            }
            if (ball.Left < 0)
            {
                this.vecY *= -1;
            }

           foreach (var other in this.gridController.Grid)
            {
                if (other == null)
                {
                    continue;
                }
                if (ball.Bounds.IntersectsWith(other.Bounds))
                {
                    if (other.Broken)
                    {
                        continue;
                    }
                    if (other.Breakable)
                    {
                        this.Controls.Remove(other);
                        other.Broken = true;
                    }


                    // Calculate
                    var dist1 = 100;
                    var dist2 = 100;
                    var dist3 = 100;
                    var dist4 = 100;

                    var bounds = ball.Bounds;

                    var rect1 = new Rectangle(bounds.X, bounds.Y, bounds.Width, 1);
                    var rect2 = new Rectangle(bounds.X + bounds.Width, bounds.Y, 1, bounds.Height);
                    var rect3 = new Rectangle(bounds.X, bounds.Y + bounds.Height, bounds.Width, 1);
                    var rect4 = new Rectangle(bounds.X, bounds.Y, 1, bounds.Height);

                    if (rect1.IntersectsWith(other.Bounds))
                    {
                        dist1 = other.Bounds.Y + other.Bounds.Height - bounds.Y;
                    }

                    if (rect2.IntersectsWith(other.Bounds))
                    {
                        dist2 = bounds.X + bounds.Width - other.Bounds.X;
                    }

                    if (rect3.IntersectsWith(other.Bounds))
                    {
                        dist3 = bounds.Y + bounds.Height - other.Bounds.Y;
                    }

                    if (rect4.IntersectsWith(other.Bounds))
                    {
                        dist4 = other.Bounds.X + other.Bounds.Width - bounds.X;
                    }

                    if (dist3 < dist2 && dist3 < dist1 && dist3 < dist4)
                    {
                        this.vecX *= -1;
                    }

                    if (dist2 < dist3 && dist2 < dist1 && dist2 < dist4)
                    {
                        this.vecY *= -1;
                    }

                    if (dist1 < dist3 && dist1 < dist2 && dist1 < dist4)
                    {
                        this.vecX *= -1;
                    }

                    if (dist4 < dist3 && dist4 < dist2 && dist4 < dist1)
                    {
                        this.vecY *= -1;
                    }

                    break;
                }
            }
        }
    }
}
