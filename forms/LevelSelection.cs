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
        }

        private void LevelSelectedClick(object sender, EventArgs e)
        {
            Hide();
            var level = (int) ((Button) sender).Tag;
            var gameScreen = new Screen(this, LevelManager.Levels[level]);
            gameScreen.ShowDialog();
            gameScreen.Dispose();
        }

        private void AddButtonForEachLevel()
        {
            var levelAmount = LevelManager.Levels.Count;
            var x = 340;
            var width = 45;
            for (var levelNumber = 0; levelNumber < levelAmount; levelNumber++)
            {
                AddLevelSelectButton(x, 95, width, width, $"{levelNumber+1}", levelNumber);
                x += width + 8;
            }
        }

        private void AddLevelSelectButton(int x, int y, int width, int height, string text, int tag)
        {
            var button = new Button();
            button.Text = text;
            button.ForeColor = Color.White;
            button.Font = new Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button.Top = y;
            button.Left = x;
            button.Size = new Size(width, height);
            button.Tag = tag;
            button.Click += new EventHandler(LevelSelectedClick);
            button.BackColor = Color.Black;
            this.Controls.Add(button);
        }
    }
}
