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
            Visible = true;
            BackColor = Color.Transparent;
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
