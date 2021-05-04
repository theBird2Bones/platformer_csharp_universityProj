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
                game.Scores = 500;
                var player = new Hero(100, 4, 12,
                    new Point(400,400), 
                    new Size(30, 40));
                game.Hero = player;
                game.EnvironmentObjects.Add(
                    new Platform(new Point(-100, game.MapSize.Height - 100),
                        new Size(8000, 60)));
//left side
                game.EnvironmentObjects.Add(
                    new Plant(new Point(120, game.MapSize.Height - 300),
                        new Size(180, 250),
                        PlantsType.thirdTree));
                
                game.EnvironmentObjects.Add(
                    new Plant(new Point(-10, game.MapSize.Height - 400),
                        new Size(210, 300),
                        PlantsType.secondTree));

                game.EnvironmentObjects.Add(
                    new Plant(new Point(0, game.MapSize.Height - 170),
                        new Size(100, 70),
                        PlantsType.firstBush));
                game.EnvironmentObjects.Add(
                    new Plant(new Point(140, game.MapSize.Height - 170),
                        new Size(100, 70),
                        PlantsType.firstBush));
//right side         
                game.EnvironmentObjects.Add(
                    new Plant(new Point(1800, game.MapSize.Height - 300),
                        new Size(180, 250),
                        PlantsType.thirdTree));
                
                game.EnvironmentObjects.Add(
                    new Plant(new Point(1830, game.MapSize.Height - 350),
                        new Size(210, 260),
                        PlantsType.secondTree));
                game.EnvironmentObjects.Add(
                    new Plant(new Point(1700, game.MapSize.Height - 400),
                        new Size(210, 300),
                        PlantsType.secondTree));

                game.EnvironmentObjects.Add(
                    new Plant(new Point(1830, game.MapSize.Height - 170),
                        new Size(100, 70),
                        PlantsType.firstBush));
                game.EnvironmentObjects.Add(
                    new Plant(new Point(1700, game.MapSize.Height - 170),
                        new Size(100, 70),
                        PlantsType.firstBush));
                
                game.Background = new Background(
                    game.MapSize,
                    new Point(0,-120));
                game.MenuButton = new MenuButton(
                    new Size(90, 60),
                    new Point(0, 0));
                game.BackgroundWeapon = new BackgroundWeapon(
                    new Size(75, 75),
                    new Point(game.MapSize.Width - 64, 0));
                game.WeaponIcon = new WeaponIcons(
                    new Size(game.BackgroundWeapon.Size.Height-20, game.BackgroundWeapon.Size.Width - 20), 
                    new Point(game.BackgroundWeapon.Location.X+13, game.BackgroundWeapon.Location.Y+13), 
                    game.Hero.Weapon.WeaponTypeIcons);
                
                Application.Run(new Form1(game){Size = game.MapSize});
            }
        }
    }
}