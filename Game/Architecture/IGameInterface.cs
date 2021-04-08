using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    interface IGameInterface
    {
        int Scores { get; set; }
        bool IsOver { get; set; }
        Point MapSize { get; set; }
        Keys KeyPressed { get; set; }
        Dictionary<string, StaticObjectBuilder> StaticObjectBuilders { get; set; }
    }
}
