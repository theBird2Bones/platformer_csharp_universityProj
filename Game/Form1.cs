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
        public Timer generalTimer;
        
        public void UpdateControls(GameModel game) {
            foreach (var monster in game.Monsters) 
                if (!Controls.Contains(monster))
                    Controls.Add(monster);
        }

        public Form1(GameModel game) {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            DoubleBuffered = true;
            
            Controls.Add(game.MenuButton);
            foreach (var environmentEl in game.EnvironmentObjects.Where(x => x is Platform)) 
                Controls.Add(environmentEl);
            Controls.Add(game.Background);
            game.SpawnLocation = new Point(-50,700);
            KeyDown += (sender, args) => {
                game.Hero.Action(game, args.KeyCode, ActionWithKey.Pressed,generalTimer);
            };
            KeyUp += (sender, args) => {
                game.Hero.Action(game, args.KeyCode, ActionWithKey.Unpressed,generalTimer);
            };
            
            game.MenuButton.Click += (sender, args) => {
                MenuForm menuForm = new MenuForm(this, game);
                generalTimer.Stop();
                menuForm.Show();
            };

            generalTimer = new Timer();
            generalTimer.Interval = 25;
            generalTimer.Start();
            generalTimer.Tick += (sender, args) => {
                game.SpawnMonster();
                UpdateControls(game);
                game.MakeActionOfMonsters(Controls, game);
                game.Hero.Action(game, Keys.None, ActionWithKey.None,generalTimer);
                if (game.FiredBullets.Count > 0) {
                    foreach (var bullet in game.FiredBullets) {
                        bullet.Move();
                    }
                }
                Invalidate();
            };
            
            Paint += (sender, args) => {
                var g = args.Graphics;
                g.DrawImage(game.Background.Image, game.Background.Location);
                foreach (var environmentObject in game.EnvironmentObjects.Where(x => ! (x is Platform))) 
                    g.DrawImage(new Bitmap(environmentObject.Image, environmentObject.Size), environmentObject.Location);

                foreach (var monster in game.Monsters) 
                    g.DrawImage(new Bitmap(monster.Image,monster.Size), monster.Location);
                if (game.FiredBullets.Count > 0) {
                    foreach (var bullet in game.FiredBullets) {
                        g.DrawImage(new Bitmap(bullet.Image, bullet.Size),bullet.Location );
                    }
                }
                g.DrawImage(new Bitmap(game.Hero.Image, game.Hero.Size), game.Hero.Location);
                g.DrawImage(new Bitmap(game.Hero.Weapon.Image,game.Hero.Weapon.Size), game.Hero.Weapon.Location);
                g.DrawImage(new Bitmap(game.BackgroundWeapon.Image,game.BackgroundWeapon.Size), game.BackgroundWeapon.Location);
                g.DrawImage(new Bitmap(game.WeaponIcon.Image,new Size(50,50)), game.WeaponIcon.Location);
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