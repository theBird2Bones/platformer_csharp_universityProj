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
                Controls.Add(monster);
            }
        }

        public Form1(GameModel game) {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            DoubleBuffered = true;

            Controls.Add(game.MenuButton);
            Controls.Add(game.Hero);
            foreach (var environmentEl in game.EnvironmentObjects) {
                Controls.Add(environmentEl);
                //environmentEl.Parent = game.Background;
            }
            Controls.Add(game.Background);
            //game.Hero.Parent = game.Background;
            //game.MenuButton.Parent = game.Background;
            timer = new Timer();

            game.MenuButton.Click += (sender, args) =>
            {
                MenuForm menuForm = new MenuForm(this);
                timer.Stop();
                menuForm.Show();
            };
            
            KeyDown += (sender, args) => { game.Hero.Action(game, args.KeyCode, ActionWithKey.Pressed,timer); };
            KeyUp += (sender, args) => { game.Hero.Action(game, args.KeyCode, ActionWithKey.Unpressed,timer); };
            timer.Interval = 1;
            timer.Tick += (sender, args) => {
                game.SpawnMonster();
                UpdateControls(game);
                game.MakeActionOfMonsters();
                game.Hero.Action(game, Keys.None, ActionWithKey.None,timer);
            };
            timer.Start();
            Paint += (sender, args) => {
                var g = args.Graphics;
                foreach (var monster in game.Monsters){
                    g.DrawImage(monster.Image, monster.Location);
                }
                g.DrawImage(game.Background.Image, game.Background.Location);
                foreach (var environmentObject in game.EnvironmentObjects.Where(x => ! (x is Platform))) {
                    g.DrawImage(environmentObject.Image, environmentObject.Location);
                }
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