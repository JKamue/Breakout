using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout.forms
{
    public partial class GameEndScreen : Form
    {
        public static GameEndButtons _buttonResult;

        public GameEndScreen()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "";
        }

        public void ShowGameStats(int score, int lives, Stopwatch time, bool won)
        {
            lblText.Text = $"Score:   {score}";
            if (won)
            {
                lblHeader.Text = "You Won!";
                var timeString = time.Elapsed.ToString("mm':'ss");
                lblText.Text += $"\n\nTime:    {timeString}";
            }
            else
            {
                lblHeader.Text = "You Lost!";
            }

        }

        public static GameEndButtons ShowGameEnd(int score, int lives, Stopwatch time, bool won)
        {
            Cursor.Show();
            var mBox = new GameEndScreen();
            mBox.ShowGameStats(score, lives, time, won);
            mBox.ShowDialog();
            return _buttonResult;
        }

        static void ButtonClick(GameEndButtons btn)
        {
            _buttonResult = btn;
        }

        private void PbxHome_Click(object sender, EventArgs e)
        {
            ButtonClick(GameEndButtons.Home);
            this.Dispose();
        }

        private void PbxReload_Click(object sender, EventArgs e)
        {
            ButtonClick(GameEndButtons.Restart);
            this.Dispose();
        }

        public enum GameEndButtons
        {
            Home = 1,
            Restart = 2
        }

    }
}
