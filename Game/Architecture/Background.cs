using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace Game {
    public class Background: StaticObject {
        public Background(Size size, Point location)
        :base( size, location){
            SizeMode = PictureBoxSizeMode.StretchImage;
            Tag = "background";
            Image = new Bitmap(PathToImages + "background.png");
        }
    }
}