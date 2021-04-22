using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Game;
using System.IO;

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
                    new Plant(new Point(-55, game.MapSize.Height - 350),
                    new Size(150, 300),
                    PlantsType.fir));
                game.EnvironmentObjects.Add(
                    new Plant(new Point(700, game.MapSize.Height - 300),
                        new Size(150, 200),
                        PlantsType.secondTree));
                game.EnvironmentObjects.Add(
                    new Plant(new Point(640, game.MapSize.Height - 170),
                        new Size(120, 70),
                        PlantsType.firstBush));
                game.Background = new Background(game.MapSize,new Point(0,0));
                game.MenuButton = new MenuButton(new Size(90, 60), new Point(0, 0));
                Application.Run(new Form1(game){Size = game.MapSize});
            }
        }
    }
}