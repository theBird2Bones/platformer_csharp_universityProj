using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Game;

namespace WinFormsApp1{
    public static class Helpers
    {
        public static GameClass MakeEnteries(GameClass game)
        {
            var platform = new StaticObjectBuilder()
                .SetName("platform")
                .SetImageName("onlyGround.png")
                .SetDrowingPriority(1)
                .SetLocation(new Point(0, game.MapSize.Y - 60))
                .SetSize(new Size(2000, 60));

            var platform2 = new StaticObjectBuilder()
                .SetName("platform2")
                .SetImageName("onlyGround.png")
                .SetDrowingPriority(2)
                .SetLocation(new Point(400, game.MapSize.Y-240))
                .SetSize(new Size(120, 60));

            var backGround = new StaticObjectBuilder()
                .SetName("background")
                .SetImageName("background.png")
                .SetDrowingPriority(3)
                .SetLocation(new Point(0, 0))
                .SetSize(new Size(2000, 500));

            var player = new StaticObjectBuilder()
                .SetName("player")
                .SetImageName("mushroom.png")
                .SetDrowingPriority(1)
                .SetLocation(new Point(300, platform.StaticObject.Location.Y - 40))
                .SetSize(new Size(30, 40));

            var tree = new StaticObjectBuilder()
                .SetName("tree")
                .SetImageName("thirdTree.png")
                .SetDrowingPriority(2)
                .SetLocation(new Point(600, platform.StaticObject.Location.Y - 300))
                .SetSize(new Size(150, 300));

            game.StaticObjectBuilders.Add(platform.BuildEntity().Name, platform);
            game.StaticObjectBuilders.Add(platform2.BuildEntity().Name, platform2);
            game.StaticObjectBuilders.Add(backGround.BuildEntity().Name, backGround);
            game.StaticObjectBuilders.Add(player.BuildEntity().Name, player);
            game.StaticObjectBuilders.Add(tree.BuildEntity().Name, tree);

            return game;
        }
    }
    static class Program{
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(){
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var game = new GameClass(new Point(600, 500));
            game = Helpers.MakeEnteries(game);
            Application.Run(new Form1(game));
        }
    }
}