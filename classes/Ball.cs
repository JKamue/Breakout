using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Breakout.classes
{
    class Ball : Block
    {
        private int Velocity;
        private int InitialVelocity;
        private double VecX;
        private double VecY;
        private int DirX;
        private int DirY;

        private double RealPositionX;
        private double RealPositionY;

        private int SpawnX;
        private int SpawnY;

        private Form Form;
        private GridController GridController;
        private Timer Clock;

        private Player Player;

        private bool Running;

        public Ball(Form form, GridController grid, Player player, int startVelocity, double vecX, double vecY, int dirX, int dirY,
            int distanceTop, int distanceLeft,
            Size size, Color color, bool breakable, int speedAfterCollision)
            : base(distanceTop, distanceLeft, size, color, breakable, speedAfterCollision)
        {
            this.Velocity = startVelocity;
            this.InitialVelocity = startVelocity;
            this.VecX = vecX;
            this.VecY = vecY;
            this.DirX = dirX;
            this.DirY = dirY;

            this.SpawnY = distanceTop;
            this.SpawnX = distanceLeft;

            this.RealPositionY = Top;
            this.RealPositionX = Left;

            this.Form = form;
            this.GridController = grid;
            this.Player = player;

            createTimer();
            Form.Controls.Add(this);
            Start();
        }

        private void createTimer()
        {
            Clock = new Timer();
            Clock.Tick += new System.EventHandler(this.CheckIfBallLeavingScreen);
            Clock.Tick += new System.EventHandler(this.DetectCollisions);
            Clock.Tick += new System.EventHandler(this.UpdatePosition);
            Clock.Interval = 10;
        }

        public void restartIn(int miliseconds)
        {
            var startGameTimer = new Timer();
            startGameTimer.Tick += (s, e) =>
            {
                ((Timer)s).Stop();
                if (Running)
                {
                    Start();
                }
            };
            startGameTimer.Interval = miliseconds;
            startGameTimer.Enabled = true;
        }

        private void Start()
        {
            if (Clock == null)
            {
                createTimer();
            }
            Clock.Start();
            this.Running = true;
        }

        private void Stop()
        {
            Clock.Stop();
        }

        public void StopGame()
        {
            Stop();
            Running = false;
        }

        private void CheckIfBallLeavingScreen(object sender, EventArgs e)
        {
            if (Top + Height + 30 > this.Form.Height)
            {
                DirY = -1;
                Player.Misses++;
                Top = SpawnY;
                Left = SpawnX;
                RealPositionY = Top;
                RealPositionX = Left;
                Velocity = InitialVelocity;
                Stop();
                restartIn(1000);
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
            RealPositionY += VecY * (Velocity + 2) * DirY;
            RealPositionX += VecX * (Velocity + 2) * DirX;
            Top = (int)Math.Round(RealPositionY);
            Left = (int) Math.Round(RealPositionX);
        }

        private bool CheckObjectForCollision(Block other)
        {
            var bounds = this.Bounds;
            if (bounds.IntersectsWith(other.Bounds))
            {
                if (other.Broken)
                {
                    return false;
                }
                if (other.Breakable)
                {
                    new Thread(() => Console.Beep(300, 150)).Start();
                    GridController.BreakBlock(other);
                    if (this.Velocity < other.SpeedAfterCollision)
                    {
                        this.Velocity = other.SpeedAfterCollision;
                    }
                }
                else
                {
                    new Thread(() => Console.Beep(1200, 150)).Start();
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

                return true;
            }

            return false;
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

            if (this.Bounds.IntersectsWith(Player.Bounds))
            {
                new Thread(() => Console.Beep(600, 150)).Start();
                // Check if ball hit side
                if (Top + Height > Player.Top + 8)
                {
                    CheckObjectForCollision(Player);
                    return;
                }

                var bleft = Left + 0.5 * Width;

                var leftDiff = bleft - Player.Left;
                var point = Math.Round(leftDiff - 0.5 * Player.Width);

                var direction = point / Player.Width;
                //var forceX = 2 * Math.Abs(point / Player.Width); old equation with f(x) = 2|x|
                var forceX = 0.2 * point / Player.Width + 0.6; // new equation = f(x) = 0.2 x^2 + 0.6
                var forceY = Math.Sqrt(1 - Math.Pow(forceX, 2));

                VecX = forceX;
                VecY = forceY;

                if (direction < 0)
                {
                    this.DirX = -1;
                }
                else
                {
                    this.DirX = 1;
                }

                this.DirY = -1;
            }
        }
    }
}
