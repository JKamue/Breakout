﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.Remoting.Channels;
using System.Threading;
using System.Windows.Forms;
using Breakout.dtos;
using Breakout.events;
using Newtonsoft.Json;
using Timer = System.Windows.Forms.Timer;

namespace Breakout.classes
{
    class Game
    {
        private GridController GridController;
        private Screen Form;

        private Player Player;
        private List<Ball> Balls = new List<Ball>();

        private Stopwatch Stopwatch;

        private int Lives;

        public Game(string gameSettings, Screen form)
        {
            Form = form;

            var grid = JsonConvert.DeserializeObject<GridDto>(gameSettings);
            GenerateField(grid);
            GeneratePlayer(grid.player);
            GenerateBalls(grid.balls);

            Stopwatch = new Stopwatch();
            Stopwatch.Start();

            Lives = grid.lives;
        }

        private void BallHitBlock(object sender, BlockHitEventArgs e)
        {
            var block = e.hitBlock;
            if (block.Breakable)
            {
                new Thread(() => Console.Beep(300, 150)).Start();
                GridController.BreakBlock(block);
                if (((Ball)sender).Velocity < block.SpeedAfterCollision)
                {
                    ((Ball)sender).Velocity = block.SpeedAfterCollision;
                }

                CheckIfGameOver();
            }
            else
            {
                new Thread(() => Console.Beep(1200, 150)).Start();
            }
        }

        private void CheckIfGameOver()
        {
            if (GridController.GameOver() || Player.Misses == Lives)
            {
                Form.Close();
            }
        }

        public void StopGame()
        {
            foreach (var ball in Balls)
            {
                ball.StopGame();
            }
            Player.EndGame();
            Stopwatch.Stop();

            var sec = Stopwatch.Elapsed.Seconds;
            var min = Stopwatch.Elapsed.Minutes;

            if (GridController.GameOver())
            {
                MessageBox.Show($"Sie haben gewonnen! Sie haven {min} Minuten {sec} Sekunden gespielt!",
                    "Herzlichen Glückwunsch!");
            }
            else if(Player.Misses == Lives)
            {
                MessageBox.Show($"Sie haben verloren!",
                    "Nächstes Mal vielleicht!");
            }

            Form.Controls.Remove(Player);

            foreach (var ball in Balls)
            {
                Form.Controls.Remove(ball);
            }

            GridController.SelfDestruct();
            Form.BackToMainMenu();
        }

        private void GenerateField(GridDto grid)
        {
            Form.BackColor = grid.backColor;
            Form.Width = grid.pxWidth;
            Form.Height = grid.pxHeight;

            GridController = new GridController(Form, grid.pxWidth, grid.pxHeight, 0, 0, grid.height, grid.width);

            foreach (var block in grid.blocks)
            {
                GridController.AddBlock(
                    new GridCoordinate(block.x, block.y),
                    block.color,
                    block.breaks,
                    block.speed,
                    block.colspan,
                    block.rowspan,
                    block.margin,
                    block.mType);
            }
        }

        private void GeneratePlayer(PlayerDto playerDto)
        {
            Player = new Player(Form, playerDto.maxLeft, playerDto.maxRight, playerDto.distanceTop, playerDto.distanceLeft, new Size(playerDto.width, playerDto.height), playerDto.color,
                false, 10);
        }

        private void GenerateBalls(List<BallDto> balls)
        {
            var rand = new Random();
            foreach (var ballDto in balls)
            {
                var distanceTop = rand.Next(ballDto.spawnYmin, ballDto.spawnYmax);
                var distanceLeft = rand.Next(ballDto.spawnXmin, ballDto.spawnXmax);

                var ball = new Ball(Form, GridController, Player, ballDto.startVelocity, 0.7, 0.7, -1, -1,
                    distanceTop, distanceLeft, new Size(ballDto.size, ballDto.size), ballDto.color, false, 1);
                Balls.Add(ball);

                ball.OnBlockHit += new BlockHitEventHandler(BallHitBlock);
            }
        }
    }
}
