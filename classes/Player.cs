using System;
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

        private Form Form;

        private bool KeyLeftPressed = false;
        private bool KeyRightPressed = false;

        private Keys KeyLeft;
        private Keys KeyRight;

        private Timer PlayerUpdateTimer;

        public Player(Form form, int maxLeft, int maxRight, bool mouse, Keys keyLeft, Keys keyRight, int distanceTop, int distanceLeft,
            Size size, Color color, bool breakable, int speedAfterCollision)
            : base(distanceTop, distanceLeft, size, color, breakable, speedAfterCollision)
        {
            Form = form;
            Form.Controls.Add(this);
            
            this.MaxLeft = maxLeft;
            this.MaxRight = maxRight;

            PlayerUpdateTimer = new Timer();
            PlayerUpdateTimer.Interval = 10;

            if (mouse)
            {
                PlayerUpdateTimer.Tick += new EventHandler(SyncWithMouse);
            }
            else
            {
                KeyLeft = keyLeft;
                KeyRight = keyRight;

                Form.KeyDown += new KeyEventHandler(this.KeyPressed);
                Form.KeyUp += new KeyEventHandler(this.KeyReleased);

                PlayerUpdateTimer.Tick += new EventHandler(SyncWithKeys);
            }

            PlayerUpdateTimer.Start();
        }

        public void EndGame()
        {
            Form.KeyDown -= new KeyEventHandler(this.KeyPressed);
            Form.KeyUp -= new KeyEventHandler(this.KeyReleased);
            PlayerUpdateTimer.Stop();
        }

        public void SyncWithMouse(object sender, EventArgs e)
        {
            var relativeCursorPos = Form.PointToClient(Cursor.Position);
            var realPos = (int) Math.Round(relativeCursorPos.X - Width * 0.5);
            if (realPos < MaxRight && realPos > MaxLeft)
            {
                Left = realPos;
            }
            else if (realPos > MaxRight)
            {
                Left = MaxRight;
            }
            else if (realPos < MaxLeft)
            {
                Left = MaxLeft;
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
            if (e.KeyCode == KeyLeft)
            {
                KeyLeftPressed = true;
            }
            else if (e.KeyCode == KeyRight)
            {
                KeyRightPressed = true;
            }
        }

        public void KeyReleased(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == KeyLeft)
            {
                KeyLeftPressed = false;
            }
            else if (e.KeyCode == KeyRight)
            {
                KeyRightPressed = false;
            }
        }


    }
}
