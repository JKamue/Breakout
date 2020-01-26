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

        public Player(Form form, int maxLeft, int maxRight, int distanceTop, int distanceLeft,
            Size size, Color color, bool breakable, int speedAfterCollision)
            : base(distanceTop, distanceLeft, size, color, breakable, speedAfterCollision)
        {
            form.KeyDown += new KeyEventHandler(this.KeyPressed);
            form.Controls.Add(this);

            form.MouseMove += new MouseEventHandler(this.syncWithMouse);

            this.maxLeft = maxLeft;
            this.maxRight = maxRight;
        }

        public void syncWithMouse(object sender, MouseEventArgs e)
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
                if (Left > maxLeft)
                {
                    Left -= 50;
                }
            } else if (e.KeyData == Keys.Right)
            {
                if (Left < maxRight)
                {
                    Left += 50;
                }
            }
        }
    }
}
