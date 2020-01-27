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
using Breakout.dtos;
using Newtonsoft.Json;

namespace Breakout
{
    public partial class Screen : Form
    {
        private readonly Form MainMenu;
        public Screen(Form mainMenu, string levelSettings)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MainMenu = mainMenu;
            this.Closed += new EventHandler(OnRageQuit);
            StartGame(levelSettings);
        }

        private void OnRageQuit(object sender, EventArgs e)
        {
            BackToMainMenu();
        }

        public void BackToMainMenu()
        {
            MainMenu.Show();
            Cursor.Show();
        }

        public void StartGame(string levelSettings)
        {
            Cursor.Hide();
            new Game(levelSettings, this);
        }
    }
}
