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
    public class StaticObject : PictureBox {
        public StaticObject() { }
        
        public StaticObject(Size size, Point location){
            Location = location;
            Size = size;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Visible = false;
            BackColor = Color.Transparent;
        }

        public void Move(Hero hero,int speed) {
            if (hero.IsGoingLeft) 
                this.Left += speed;
            if(hero.IsGoingRight)
                this.Left -= speed;
        }
        
        protected static string PathToImages = GetGameDirectoryRoot().FullName.ToString() + "\\Images\\";
        private static DirectoryInfo GetGameDirectoryRoot() {
            var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            while (!dir.ToString().EndsWith("GameOfTheCentury")) {
                dir = dir.Parent;
            }
            return dir;
        }
    }
}
