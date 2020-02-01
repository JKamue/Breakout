using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Net.Mime;
using System.Runtime.InteropServices;
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

        private List<Player> Players;
        private List<Ball> Balls = new List<Ball>();

        private Label ScoreLabel;
        private Label TimeLabel;
        private Label LivesLabel;

        private Stopwatch Stopwatch;

        private int Lives;
        private int LivesLost = 0;
        private int Score = 0;

        private PrivateFontCollection FontCollection;

        private bool GameOver => Lives == LivesLost;

        public Game(string gameSettings, Screen form)
        {
            Form = form;

            Stopwatch = new Stopwatch();
            Stopwatch.Start();

            var grid = JsonConvert.DeserializeObject<GridDto>(gameSettings);
            GenerateField(grid);
            GeneratePlayers(grid.players);
            GenerateBalls(grid.balls);
            GenerateInfoLabels();

            GridController.OnAllBlocksDestroyed += new AllBlocksDestroyedEventHandler(AllBlocksDestroyed);

            var timer = new Timer();
            timer.Tick += new EventHandler(UpdateTime);
            timer.Interval = 900;
            timer.Start();

            Lives = grid.lives;
            UpdateLives();
        }

        private void UpdateScore(int add)
        {
            Score += add;
            ScoreLabel.Text = Score.ToString();
        }

        private void UpdateTime(object source, EventArgs e)
        {
            var timespan = Stopwatch.Elapsed;
            var time = timespan.ToString(@"mm\:ss");
            TimeLabel.Text = time;
        }

        private void UpdateLives()
        {
            LivesLabel.Text = $@"Lives: {Lives - LivesLost}";
        }

        private void GenerateInfoLabels()
        {
            FontCollection = new PrivateFontCollection();
            var fontData = Properties.Resources.PixelMiners_KKal;
            var frontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            Marshal.Copy(fontData, 0, frontPtr, fontData.Length);
            FontCollection.AddMemoryFont(frontPtr, Properties.Resources.PixelMiners_KKal.Length);

            var borderGrey = (Color) (new ColorConverter()).ConvertFrom("#8e8e8e");

            ScoreLabel = new Label
            {
                Top = 0,
                Height = 30,
                Width = 140,
                Left = Form.Width - 150,
                TextAlign = ContentAlignment.MiddleRight,
                Text = Score.ToString(),
                Font = new Font(FontCollection.Families[0], 20, FontStyle.Regular),
                ForeColor = borderGrey
            };

            TimeLabel = new Label
            {
                Top = 0,
                Height = 30,
                Width = Form.Width,
                Left = 0,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(FontCollection.Families[0], 20, FontStyle.Regular),
                ForeColor = borderGrey
            };

            LivesLabel = new Label
            {
                Top = 0,
                Left = 20,
                Width = 400,
                Height = 30,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font(FontCollection.Families[0], 20, FontStyle.Regular),
                ForeColor = borderGrey
            };

            UpdateTime(this, new EventArgs());
            
            Form.Controls.Add(LivesLabel);
            Form.Controls.Add(ScoreLabel);
            Form.Controls.Add(TimeLabel);
        }


        private void AllBlocksDestroyed(object sender, AllBlocksDestroyedEventArgs e)
        {
            StopGame();
            var sec = Stopwatch.Elapsed.Seconds;
            var min = Stopwatch.Elapsed.Minutes;
            MessageBox.Show($"You won after only {min} minutes and {sec} seconds!",
                    "Congrats!");
        }

        private void PlayerMissedBall(object sender, PlayerMissedEventArgs e)
        {
            LivesLost += 1;
            UpdateLives();

            if (!GameOver)
            {
                ((Ball) sender).RestartIn(1000);
            }
            else
            {
                StopGame();
                MessageBox.Show("You did not manage to win this Level! Maybe next time...", "You Lost!");
            }
        }

        private void BallHitBlock(object sender, BlockHitEventArgs e)
        {
            var block = e.hitBlock;
            if (block.Breakable)
            {
                new Thread(() => Console.Beep(300, 150)).Start();
                UpdateScore(block.Score);
                GridController.BreakBlock(block);
                if (((Ball)sender).Velocity < block.SpeedAfterCollision)
                {
                    ((Ball)sender).Velocity = block.SpeedAfterCollision;
                }
            }
            else
            {
                new Thread(() => Console.Beep(1200, 150)).Start();
            }
        }

        public void StopGame()
        {
            Stopwatch.Stop();
            foreach (var player in Players)
            {
                player.EndGame();
            }

            foreach (var ball in Balls)
            {
                ball.StopGame();
            }
            Form.Close();

            FontCollection.Dispose();
        }

        private void GenerateField(GridDto grid)
        {
            Form.BackColor = grid.backColor;
            Form.Width = grid.pxWidth;
            Form.Height = grid.pxHeight + 30;

            GridController = new GridController(Form, grid.pxWidth, grid.pxHeight, 30, 0, grid.height, grid.width);

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
                    block.mType,
                    block.score);
            }
        }

        private void GeneratePlayers(List<PlayerDto> players)
        {
            Players = new List<Player>();
            foreach (var playerDto in players)
            {
                Players.Add(new Player(Form, playerDto.maxLeft, playerDto.maxRight, playerDto.mouse, playerDto.keyLeft, playerDto.keyRight, playerDto.distanceTop, playerDto.distanceLeft, new Size(playerDto.width, playerDto.height), playerDto.color,
                    false, 10));
            }
            
        }

        private void GenerateBalls(List<BallDto> balls)
        {
            var rand = new Random();
            foreach (var ballDto in balls)
            {
                var distanceTop = rand.Next(ballDto.spawnYmin, ballDto.spawnYmax);
                var distanceLeft = rand.Next(ballDto.spawnXmin, ballDto.spawnXmax);

                var ball = new Ball(Form, GridController, Players, ballDto.startVelocity, 0.7, 0.7, -1, -1,
                    distanceTop, distanceLeft, new Size(ballDto.size, ballDto.size), ballDto.color, false, 1);
                Balls.Add(ball);

                ball.OnBlockHit += new BlockHitEventHandler(BallHitBlock);
                ball.OnPlayerMissed += new PlayerMissedEventHandler(PlayerMissedBall);
            }
        }
    }
}
