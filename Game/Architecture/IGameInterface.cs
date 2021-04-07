using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Game
{
    interface IGameInterface
    {
        public int Scores { get; set; }
        public bool IsOver { get; set; }
        public Point MapSize { get; set; }
        public Keys KeyPressed { get; set; }
        public Dictionary<string, Entity> Entities { get; set; }
    }
}
