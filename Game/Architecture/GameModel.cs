using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public class GameModel {
        public GameModel(Size mapSize, int scores = 0) {
            Scores = scores;
            IsOver = false;
            MapSize = mapSize;
            EnvironmentObjects = new List<PictureBox>();
        }
        public Hero Hero { get; set; }
        public List<PictureBox> EnvironmentObjects { get; set; }
        public Background Background { get; set; }
        public int Scores { get; set; }
        public bool IsOver { get; set; }
        public Size MapSize { get; }
        
        
    }
}
