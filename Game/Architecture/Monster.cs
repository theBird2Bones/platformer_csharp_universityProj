using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public class Monster : DynamicObject
    {
        public Monster(int health, int speed, int jumpHeight, Point location, Size size)
            : base(health, speed, jumpHeight, location, size)
        {
            Tag = "monster";
            Image = new Bitmap(PathToImages + "firstMonster.png");
        }
    }
}
