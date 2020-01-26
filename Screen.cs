﻿using System;
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

        private GridController gridController;

        public Screen()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Screen_Load(object sender, EventArgs e)
        {
            StartGame();
        }

        public void StartGame()
        {
            var gameSettings =
                "{ \r\nwidth: 21,\r\nheight: 21,\r\npxWidth: 1000,\r\npxHeight: 500,\r\nlives: 3,\r\nbackColor: \"#000000\",\r\nballs: [\r\n\t{\"startVelocity\": 2, \"size\": 15, \"spawnXmin\": 200, \"spawnXmax\": 800, \"spawnYmin\": 240, \"spawnYmax\": 280, \"color\": \"#ffffff\"}\r\n],\r\nplayer: {\r\n\t\"maxLeft\": 50, \"maxRight\": 850, \"distanceTop\": 400, \"distanceLeft\": 450, \"width\": 100, \"height\": 20, \"color\": \"#ffff00\"\r\n},\r\nblocks: [\r\n    {\"x\": 0,\"y\": 0,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 0, \"colspan\": 1, \"rowspan\":21},\r\n\t\r\n\t{\"x\": 20,\"y\": 1,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 0, \"colspan\": 1, \"rowspan\":21},\r\n\t\r\n    {\"x\": 1,\"y\": 0,\"color\": \"#8e8e8e\",\"breaks\": false,\"speed\": 0, \"colspan\": 20, \"rowspan\":1},\r\n\t\r\n    {\"x\": 1,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 6, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 2,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 6, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 3,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 6, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 4,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 6, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 5,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 6, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 6,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 6, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 7,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 6, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 8,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 6, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 9,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 6, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 10,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 6, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 11,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 6, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 12,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 6, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 13,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 6, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 14,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 6, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 15,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 6, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 16,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 6, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 17,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 6, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 18,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 6, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 19,\"y\": 4,\"color\": \"#c84848\",\"breaks\": true,\"speed\": 6, \"colspan\": 1, \"rowspan\":1},\r\n\t\r\n    {\"x\": 1,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 5, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 2,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 5, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 3,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 5, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 4,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 5, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 5,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 5, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 6,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 5, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 7,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 5, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 8,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 5, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 9,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 5, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 10,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 5, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 11,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 5, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 12,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 5, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 13,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 5, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 14,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 5, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 15,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 5, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 16,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 5, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 17,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 5, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 18,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 5, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 19,\"y\": 5,\"color\": \"#c66c3a\",\"breaks\": true,\"speed\": 5, \"colspan\": 1, \"rowspan\":1},\r\n\t\r\n    {\"x\": 1,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 4, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 2,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 4, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 3,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 4, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 4,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 4, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 5,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 4, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 6,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 4, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 7,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 4, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 8,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 4, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 9,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 4, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 10,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 4, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 11,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 4, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 12,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 4, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 13,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 4, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 14,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 4, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 15,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 4, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 16,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 4, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 17,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 4, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 18,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 4, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 19,\"y\": 6,\"color\": \"#a2a22a\",\"breaks\": true,\"speed\": 4, \"colspan\": 1, \"rowspan\":1},\r\n\t\r\n    {\"x\": 1,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 3, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 2,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 3, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 3,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 3, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 4,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 3, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 5,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 3, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 6,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 3, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 7,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 3, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 8,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 3, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 9,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 3, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 10,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 3, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 11,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 3, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 12,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 3, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 13,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 3, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 14,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 3, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 15,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 3, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 16,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 3, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 17,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 3, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 18,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 3, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 19,\"y\": 7,\"color\": \"#48a048\",\"breaks\": true,\"speed\": 3, \"colspan\": 1, \"rowspan\":1},\r\n\t\r\n    {\"x\": 1,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 2, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 2,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 2, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 3,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 2, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 4,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 2, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 5,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 2, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 6,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 2, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 7,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 2, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 8,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 2, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 9,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 2, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 10,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 2, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 11,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 2, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 12,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 2, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 13,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 2, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 14,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 2, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 15,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 2, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 16,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 2, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 17,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 2, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 18,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 2, \"colspan\": 1, \"rowspan\":1},\r\n    {\"x\": 19,\"y\": 8,\"color\": \"#4248c8\",\"breaks\": true,\"speed\": 2, \"colspan\": 1, \"rowspan\":1},\r\n]}";
            new Game(gameSettings, this);
        }
    }
}
