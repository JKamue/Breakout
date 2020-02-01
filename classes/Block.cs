using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout.classes
{

    public class Block : System.Windows.Forms.Label
    {
        public bool Breakable;
        public bool Broken = false;
        public int Score;
        public int SpeedAfterCollision;

        public Block(int distanceTop, int distanceLeft, Size size, Color color, bool breakable, int speedAfterCollision)
        {
            AssignVars(distanceTop, distanceLeft, size, color, breakable, speedAfterCollision, 1);
        }

        public Block(int distanceTop, int distanceLeft, Size size, Color color, bool breakable, int speedAfterCollision, int score)
        {
            AssignVars(distanceTop, distanceLeft, size, color, breakable, speedAfterCollision, score);
        }

        private void AssignVars(int distanceTop, int distanceLeft, Size size, Color color, bool breakable, int speedAfterCollision, int score)
        {
            this.Top = distanceTop;
            this.Left = distanceLeft;
            this.Size = size;
            this.BackColor = color;
            this.Margin = new Padding(0);
            this.BorderStyle = BorderStyle.None;

            this.Breakable = breakable;
            this.SpeedAfterCollision = speedAfterCollision;
            this.Score = score;
        }
    }
}
