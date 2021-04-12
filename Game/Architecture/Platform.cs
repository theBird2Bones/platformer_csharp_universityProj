using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Game {
    public class Platform : PictureBox  {
        public Platform(Point location, Size size){
            Location = location;
            Size = size;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Tag = "platform";
            Image = new Bitmap(PathToImages + "onlyGround.png");
            Visible = true;
        }
        protected string PathToImages = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.FullName +
            "\\Images\\";
    }
}