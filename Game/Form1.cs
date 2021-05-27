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
        private int speedAdder = 0;
        public void UpdateControls(GameModel game) {
            foreach (var monster in game.Monsters) 
                if (!Controls.Contains(monster))
                    Controls.Add(monster);
            foreach (var environmentEl in game.EnvironmentObjects.Where(x => x is Platform))
                if (!Controls.Contains(environmentEl))
                    Controls.Add(environmentEl);
        }

        public Form1(GameModel game) {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            DoubleBuffered = true;
            
            Controls.Add(game.MenuButton);
            
            foreach (var environmentEl in game.EnvironmentObjects.Where(x => x is Platform)) 
                Controls.Add(environmentEl);
            Controls.Add(game.Background);
            game.SpawnLocation = new Point(-100,650);
            game.SpawnLocation2 = new Point(1550, 650);
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
            generalTimer.Interval = 10;
            var intervalCounter = 0;
            generalTimer.Start();
            generalTimer.Tick += (sender, args) => {
                intervalCounter += 1;
                if (intervalCounter % 1500 == 0) {
                    intervalCounter = 1;
                    speedAdder += 10;
                }
                if (game.IsOver)
                    return;
                game.SpawnMonster(speedAdder);
                game.CheckTemporalEnvironmentObjects(Controls);
                UpdateControls(game);
                game.MakeActionOfMonsters(Controls, game);
                if (game.Hero != null)
                    game.Hero.Action(game, Keys.None, ActionWithKey.None, generalTimer);
                else {
                    game.IsOver = true;
                    var res = MessageBox.Show("Поражение. Хотите полностью выйти из игры?",
                    "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                        Application.Exit();
                    else {
                        game.NewGameShouldBeAfterThat = true;
                        Application.ExitThread();
                        Application.Restart();
                    }
                    generalTimer.Stop();
                    return;
                }
                if (game.FiredBullets.Count > 0) {
                    foreach (var bullet in game.FiredBullets) {
                        bullet.Move();
                    }
                }
            };
            var drawingTimer = new Timer();
            drawingTimer.Interval = 30;
            drawingTimer.Tick += (s,a) => {
                Invalidate();
            };
            drawingTimer.Start();
            Paint += (sender, args) => {
                if (game.Hero != null) {
                    var g = args.Graphics;
                    
                    g.DrawImage(game.Background.Image, game.Background.Location);
                    foreach (var environmentObject in game.EnvironmentObjects.Where(x => !(x is Platform)))
                        g.DrawImage(new Bitmap(environmentObject.Image, environmentObject.Size),
                            environmentObject.Location);
                    foreach (var monster in game.Monsters)
                        g.DrawImage(new Bitmap(monster.Image, monster.Size), monster.Location);
                    if (game.FiredBullets.Count > 0) {
                        foreach (var bullet in game.FiredBullets) {
                            g.DrawImage(new Bitmap(bullet.Image, bullet.Size), bullet.Location);
                        }
                    }
                    g.DrawImage(new Bitmap(game.Hero.Image, game.Hero.Size), game.Hero.Location);
                    g.DrawImage(new Bitmap(game.Hero.Weapon.Image, game.Hero.Weapon.Size), game.Hero.Weapon.Location);
                    g.DrawImage(new Bitmap(game.Hero.Weapon.Aim.Image, game.Hero.Weapon.Aim.Size), game.Hero.Weapon.Aim.Location);
                    g.DrawImage(new Bitmap(game.BackgroundWeapon.Image, game.BackgroundWeapon.Size), game.BackgroundWeapon.Location);
                    
                    g.DrawImage(new Bitmap(game.WeaponIcon.Image, new Size(50, 50)), game.WeaponIcon.Location);
                    g.FillRectangle(new SolidBrush(Color.Maroon), game.Hero.HealthBar.Location.X, game.Hero.HealthBar.Location.Y ,
                        game.Hero.HealthBar.Size.Width * game.Hero.Health / game.Hero.HealthBar.MaxValue, game.Hero.HealthBar.Size.Height );
                    g.DrawString("ОчКи: " + game.Scores,
                        new Font("Arial",16),
                        Brushes.Black, new Point(game.MenuButton.Location.X,game.MenuButton.Location.Y + 70) );
                    var isStoneInHand = game.Hero.Weapon.WeaponType == WeaponType.stone;
                    g.DrawString( isStoneInHand ? "Патроны: целая куча" : "Патроны: " +  game.Hero.Weapon.BulletCount,
                        new Font("Arial",16),
                        Brushes.Black, new Point(game.MenuButton.Location.X,game.MenuButton.Location.Y + 100) );
                }
            };
        }
    }
}