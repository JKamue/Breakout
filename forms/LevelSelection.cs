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

namespace Breakout
{
    public partial class LevelSelection : Form
    {
        private LevelManager LevelManager = new LevelManager();

        public LevelSelection()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Hide();
            Screen gameScreen = new Screen(this, LevelManager.Levels.First());
            gameScreen.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Hide();
            Screen gameScreen = new Screen(this, LevelManager.Levels[1]);
            gameScreen.ShowDialog();
        }
    }
}
