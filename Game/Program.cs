using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Game;

namespace WinFormsApp1{
    public static class Helpers{
        static class Program{
            /// <summary>
            ///  The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main(){
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var game = new GameModel(new Size(1500, 900));
                var player = new Hero(100, 6, 12,
                    new Point(400,400), 
                    new Size(30, 40));
                game.Hero = player;
                game.EnvironmentObjects.Add(
                    new Platform(new Point(0, game.MapSize.Height - 100),
                    new Size(2000, 60)));
                game.EnvironmentObjects.Add(
                    new Platform(new Point(60, game.MapSize.Height - 240),
                    new Size(120, 50)));
                game.EnvironmentObjects.Add(
                    new Plant(new Point(600, game.MapSize.Height - 300),
                    new Size(150, 300),
                    PlantsType.fir));
                game.Background = new Background(game.MapSize);
                Application.Run(new Form1(game){Size = game.MapSize});
            }

            
        }
    }
}