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
        private int maxLeft;
        private int maxRight;

        public int Misses;

        private Form Form;

        public Player(Form form, int maxLeft, int maxRight, int distanceTop, int distanceLeft,
            Size size, Color color, bool breakable, int speedAfterCollision)
            : base(distanceTop, distanceLeft, size, color, breakable, speedAfterCollision)
        {
            Form = form;
            Form.KeyDown += new KeyEventHandler(this.KeyPressed);
            Form.Controls.Add(this);

            Form.MouseMove += new MouseEventHandler(this.SyncWithMouse);

            this.maxLeft = maxLeft;
            this.maxRight = maxRight;
        }

        public void EndGame()
        {
            Form.MouseMove -= new MouseEventHandler(this.SyncWithMouse);
            Form.KeyDown -= new KeyEventHandler(this.KeyPressed);
        }

        public void SyncWithMouse(object sender, MouseEventArgs e)
        {
            if (e.X < maxRight && e.X > maxLeft)
            {
                Left = e.X;
            }
        }

        public void KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left)
            {
                if (Left - 50 > maxLeft)
                {
                    Left -= 50;
                }
                else
                {
                    Left = maxLeft;
                }
            } else if (e.KeyData == Keys.Right)
            {
                if (Left + 50 < maxRight)
                {
                    Left += 50;
                }
                else
                {
                    Left = maxRight;
                }
            }
        }
    }
}
