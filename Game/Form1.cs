using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1 {
    public partial class Form1 : Form {
        public Form1(GameModel game) {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            DoubleBuffered = true;
            foreach (var environmentEl in game.EnvironmentObjects) {
                Controls.Add(environmentEl);
            }
            Controls.Add(game.Hero);
            Controls.Add(game.Background);

            KeyDown += (sender, args) => {
                switch (args.KeyCode)
                {
                    case Keys.Left:
                        game.Hero.IsGoingLeft = true;
                        break;
                    case Keys.Right:
                        game.Hero.IsGoingRight = true;
                        break;
                    case Keys.Space:
                        if (game.Hero.IsLanded) {
                            game.Hero.IsJumping = true;
                            game.Hero.IsLanded = false;
                        }
                        break;
                }
            };
            KeyUp += (sender, args) => {
                switch (args.KeyCode)
                {
                    case Keys.Left:
                        game.Hero.IsGoingLeft = false;
                        break;
                    case Keys.Right:
                        game.Hero.IsGoingRight = false;
                        break;
                    case Keys.Space:
                        if (game.Hero.IsJumping)
                            game.Hero.IsJumping = false;
                        break;
                }
            };
            var timer = new Timer();
            timer.Interval = 1;
            timer.Tick += (sender, args) => {
                if (game.Hero.IsMoving) {
                    game.Hero.Move();
                    game.Hero.Refresh();
                }

                if (!game.Hero.IsJumping) {
                    game.Hero.Top += game.Hero.JumpHeight;
                    game.Hero.Refresh();
                }
                foreach (Control obj in game.EnvironmentObjects) {
                    if (obj is Platform && game.Hero.Bounds.IntersectsWith(obj.Bounds)) {
                        if (game.Hero.Bottom <= obj.Top + game.Hero.Height/3d) {
                                game.Hero.Top = obj.Top - game.Hero.Height;
                                game.Hero.Refresh();
                        }
                        game.Hero.Refresh();
                        game.Hero.IsLanded = true;
                        game.Hero.CurrentJumpHeight = 0;
                    }
                }
            };
            timer.Start();

            FormClosing += (sender, eventArgs) => {
                var res = MessageBox.Show("Уверен, что хочешь закрыть?",
                    "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res != DialogResult.Yes)
                    eventArgs.Cancel = true;
            };
        }
    }
}