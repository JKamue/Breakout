using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Breakout.classes;
using Breakout.dtos;
using Newtonsoft.Json;

namespace Breakout
{
    public partial class Screen : Form
    {
        private readonly Form MainMenu;
        private Game Game;
        public Screen(Form mainMenu, string levelSettings)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MainMenu = mainMenu;
            this.FormClosed += new FormClosedEventHandler(OnRageQuit);
            StartGame(levelSettings);
        }

        private void OnRageQuit(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Game.StopGame();
                BackToMainMenu();
            }
        }

        public void BackToMainMenu()
        {
            MainMenu.Show();
            Cursor.Show();
        }

        public void StartGame(string levelSettings)
        {
            Cursor.Hide();
            Game = new Game(levelSettings, this);
        }
    }
}
