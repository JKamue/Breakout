using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Breakout.classes;

namespace Breakout
{
    public partial class LevelSelection : Form
    {
        private LevelManager LevelManager = new LevelManager();
        public LevelSelection()
        {
            InitializeComponent();
            AddButtonForEachLevel();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Click += new EventHandler(DoubleClick);
        }

        private void LevelSelectedClick(object sender, EventArgs e)
        {
            PlayGame((int) ((Button) sender).Tag);
        }

        private void PlayGame(int number)
        {
            Hide();
            var gameScreen = new Screen(this, LevelManager.SingelPlayerLevels[number]);
            gameScreen.ShowDialog();
            gameScreen.Dispose();
        }

        private void AddButtonForEachLevel()
        {
            var levelAmount = LevelManager.SingelPlayerLevels.Count;
            var x = 340;
            const int width = 45;
            for (var levelNumber = 1; levelNumber < levelAmount; levelNumber++)
            {
                AddLevelSelectButton(x, 95, width, width, levelNumber.ToString(), levelNumber);
                x += width + 8;
            }
        }

        private void AddLevelSelectButton(int x, int y, int width, int height, string text, int tag)
        {
            var button = new Button
            {
                Text = text,
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Top = y,
                Left = x,
                Size = new Size(width, height),
                Tag = tag
            };
            button.Click += new EventHandler(LevelSelectedClick);
            button.BackColor = Color.Black;
            this.Controls.Add(button);
        }

        private void DoubleClick(object sender, EventArgs e)
        {
            var relativePoint = this.PointToClient(Cursor.Position);
            if (relativePoint.X > 160 && relativePoint.Y > 190 && relativePoint.X < 190 && relativePoint.Y < 215)
            {
                PlayGame(0);
            }
        } 
    }
}
