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
        public void RefreshWorld(GameModel game)
        {
            foreach (var environmentEl in game.EnvironmentObjects)
            {
                Controls.Add(environmentEl);
            }
            Controls.Add(game.Hero);
            Controls.Add(game.Background);
        }
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
                game.Hero.Action(game, args.KeyCode, "Down");
            };
            KeyUp += (sender, args) => {
                game.Hero.Action(game, args.KeyCode, "Up");
            };
            var timer = new Timer();
            timer.Interval = 1;
            timer.Tick += (sender, args) => {
                game.SpawnMonster();
                game.MakeActionOfDynamicObjects();
                game.Hero.Action(game, Keys.None, "None");
                RefreshWorld(game);
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