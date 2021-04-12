using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public class GameClass : IGameInterface
    {
        public GameClass(Point mapSize, int scores = 0)
        {
            Scores = scores;
            IsOver = false;
            MapSize = mapSize;
            KeyPressed = Keys.None;
            StaticObjectBuilders = new Dictionary<string, StaticObjectBuilder>();
        }
        public int Scores { get; set; }
        public bool IsOver { get; set; }
        public Point MapSize { get; set; }
        public Keys KeyPressed { get; set; }
        public Dictionary<string, StaticObjectBuilder> StaticObjectBuilders { get; set; }
    }
}
