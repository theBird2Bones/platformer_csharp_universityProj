using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Game {
    public class Platform : StaticObject  {
        public Platform(Point location, Size size)
            :base( size, location){
            SizeMode = PictureBoxSizeMode.StretchImage;
            Tag = "platform";
            Image = new Bitmap(PathToImages + "onlyGround.png");
        }
    }
}