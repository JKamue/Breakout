﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout.classes
{
    class Player: Block
    {
        private int MaxLeft;
        private int MaxRight;

        public int Misses;

        private Form Form;

        private bool KeyLeftPressed = false;
        private bool KeyRightPressed = false;

        private Timer PlayerUpdateTimer;

        public Player(Form form, int maxLeft, int maxRight, int distanceTop, int distanceLeft,
            Size size, Color color, bool breakable, int speedAfterCollision)
            : base(distanceTop, distanceLeft, size, color, breakable, speedAfterCollision)
        {
            Form = form;
            Form.KeyDown += new KeyEventHandler(this.KeyPressed);
            Form.KeyUp += new KeyEventHandler(this.KeyReleased);
            Form.Controls.Add(this);

            Form.MouseMove += new MouseEventHandler(this.SyncWithMouse);

            this.MaxLeft = maxLeft;
            this.MaxRight = maxRight;

            PlayerUpdateTimer = new Timer();
            PlayerUpdateTimer.Interval = 10;
            PlayerUpdateTimer.Tick += new EventHandler(SyncWithKeys);
            PlayerUpdateTimer.Start();
        }

        public void EndGame()
        {
            Form.KeyDown -= new KeyEventHandler(this.KeyPressed);
            Form.KeyUp -= new KeyEventHandler(this.KeyReleased);
            PlayerUpdateTimer.Stop();
        }

        public void SyncWithMouse(object sender, MouseEventArgs e)
        {
            if (e.X < MaxRight && e.X > MaxLeft)
            {
                Left = e.X;
            }
        }

        public void SyncWithKeys(object sender, EventArgs e)
        {
            if (KeyRightPressed && !KeyLeftPressed)
            {
                Left += Left < MaxRight ? 12 : 0;
            }
            else if (KeyLeftPressed && !KeyRightPressed)
            {
                Left -= Left > MaxLeft ? 12 : 0;
            }
        }

        public void KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                KeyLeftPressed = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                KeyRightPressed = true;
            }
        }

        public void KeyReleased(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                KeyLeftPressed = false;
            }
            else if (e.KeyCode == Keys.Right)
            {
                KeyRightPressed = false;
            }
        }


    }
}
