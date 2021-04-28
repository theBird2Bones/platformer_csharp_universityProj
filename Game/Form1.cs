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
    public partial class Form1 : Form
    {
        public Timer timer;

        public void UpdateControls(GameModel game)
        {
            foreach (var monster in game.Monsters)
            {
                if (!Controls.Contains(monster))
                    Controls.Add(monster);
            }
        }

        public Form1(GameModel game) {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            DoubleBuffered = true;

            Controls.Add(game.MenuButton);
            Controls.Add(game.Hero);
            Controls.Add(game.Hero.Weapon);
            Controls.Add(game.WeaponIcon);
            Controls.Add(game.BackgroundWeapon);
            foreach (var environmentEl in game.EnvironmentObjects) {
                Controls.Add(environmentEl);
            }
            Controls.Add(game.Background);
            timer = new Timer();

            game.MenuButton.Click += (sender, args) =>
            {
                MenuForm menuForm = new MenuForm(this, game);
                timer.Stop();
                menuForm.Show();
            };
            
            KeyDown += (sender, args) => {
                game.Hero.Action(game, args.KeyCode, ActionWithKey.Pressed,timer);
            };
            KeyUp += (sender, args) => {
                game.Hero.Action(game, args.KeyCode, ActionWithKey.Unpressed,timer);
            };
            timer.Interval = 1;
            timer.Tick += (sender, args) => {
                game.SpawnMonster();
                UpdateControls(game);
                game.MakeActionOfMonsters();
                game.Hero.Action(game, Keys.None, ActionWithKey.None,timer);
                Invalidate();
            };
            game.SpawnLocation = new Point(100,500);
            timer.Start();
            Paint += (sender, args) => {
                var g = args.Graphics;

                g.DrawImage(game.Background.Image, game.Background.Location);
                foreach (var environmentObject in game.EnvironmentObjects.Where(x => ! (x is Platform))) {
                    g.DrawImage(environmentObject.Image, environmentObject.Location);
                }

                foreach (var monster in game.Monsters) {
                    g.DrawImage(monster.Image, monster.Location);
                }
                g.DrawImage(game.Hero.Image, game.Hero.Location);
            };
            FormClosing += (sender, eventArgs) => {
                var res = MessageBox.Show("Уверен, что хочешь закрыть?",
                    "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res != DialogResult.Yes)
                    eventArgs.Cancel = true;
            };
        }
    }
}