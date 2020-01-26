using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout.classes
{
    class Ball : Block
    {
        private int Velocity;
        private double VecX;
        private double VecY;
        private int DirX;
        private int DirY;

        private Form Form;
        private GridController GridController;
        private Timer Clock;

        private Player Player;

        public Ball(Form form, GridController grid, Player player, int startVelocity, double vecX, double vecY, int dirX, int dirY,
            int distanceTop, int distanceLeft,
            Size size, Color color, bool breakable, int speedAfterCollision)
            : base(distanceTop, distanceLeft, size, color, breakable, speedAfterCollision)
        {
            this.Velocity = startVelocity;
            this.VecX = vecX;
            this.VecY = vecY;
            this.DirX = dirX;
            this.DirY = dirY;

            this.Form = form;
            this.GridController = grid;
            this.Player = player;

            createTimer();
            Form.Controls.Add(this);
        }

        private void createTimer()
        {
            Clock = new Timer();
            Clock.Tick += new System.EventHandler(this.CheckIfBallLeavingScreen);
            Clock.Tick += new System.EventHandler(this.DetectCollisions);
            Clock.Tick += new System.EventHandler(this.UpdatePosition);
            Clock.Interval = 10;
            Clock.Enabled = true;
        }

        private void CheckIfBallLeavingScreen(object sender, EventArgs e)
        {
            if (Top + Height + 30 > this.Form.Height)
            {
                DirY = -1;
            }

            if (Left + Width + 10 > this.Form.Width)
            {
                DirX = -1;
            }

            if (Top < 0)
            {
                DirY = 1;
            }

            if (Left < 0)
            {
                DirX = 1;
            }
        }

        private void UpdatePosition(object sender, EventArgs e)
        {
            Top += (int)Math.Round(VecY * Velocity * DirY);
            Left += (int) Math.Round(VecX * Velocity * DirX);
        }

        private void CheckObjectForCollision(Block other)
        {
            var bounds = this.Bounds;
            if (bounds.IntersectsWith(other.Bounds))
            {
                if (other.Broken)
                {
                    return;
                }
                if (other.Breakable)
                {
                    this.Form.Controls.Remove(other);
                    other.Broken = true;
                    if (this.Velocity < other.SpeedAfterCollision)
                    {
                        this.Velocity = other.SpeedAfterCollision;
                    }
                }

                int dist1, dist2, dist3, dist4;
                dist1 = dist2 = dist3 = dist4 = 100;

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
                    DirY = -1;
                } else if (dist2 <= dist3 && dist2 <= dist1 && dist2 < dist4)
                {
                    DirX = -1;
                } else if (dist1 < dist3 && dist1 < dist2 && dist1 < dist4)
                {
                    DirY = 1;
                } else if (dist4 <= dist3 && dist4 < dist2 && dist4 <= dist1)
                {
                    DirX = 1;
                }
            }
        }

        private void DetectCollisions(object sender, EventArgs e)
        {
            foreach (var other in this.GridController.Grid)
            {
                if (other != null)
                {
                    this.CheckObjectForCollision(other);
                }
            }
            this.CheckObjectForCollision(Player);
        }
    }
}
