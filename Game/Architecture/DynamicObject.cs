using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Game
{
    public class DynamicObject : PictureBox
    {

        public DynamicObject(int health, int speed, int jumpHeight, Point location, Size size)
        {
            Health = health;
            Speed = speed;
            JumpHeight = jumpHeight;
            Location = location;
            Size = size;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Visible = true;
        }
        public int DrawingPriority { get; set; }
        public int Health { get; set; }
        public int Speed { get; protected set; }
        public int JumpHeight { get; protected set; }
        public Weapon Weapon { get; set; }
        public void OnConflict(Entity entity) { }
        public DynamicObject Action()
        {
            //Location = new Point(Location.X, Location.Y+10);
            return this;
        }
        public void OnDeath() { }

        protected string PathToImages = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.FullName +
            "\\Images\\";
    }
}
