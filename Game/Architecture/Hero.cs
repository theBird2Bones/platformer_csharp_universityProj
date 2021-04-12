using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Game{
    public class Hero : PictureBox{
        
        public Hero(int health, int speed, int jumpHeight, Point location, Size size){
            Health = health;
            Speed = speed;
            JumpHeight = jumpHeight;
            Location = location;
            Size = size;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Tag = "hero";
            Image = new Bitmap(PathToImages + "hero.png");
            Visible = true;
        }
        public int DrawingPriority { get; set; }
        public int Health { get; set; }
        public int Speed { get; }
        public int JumpHeight { get; }
        public Weapon Weapon { get; set; }
        public void OnConflict(Entity entity) { }
        public void Action() { }
        public void OnDeath() { }
        
        private string PathToImages = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.FullName +
            "\\Images\\";
    }
}
