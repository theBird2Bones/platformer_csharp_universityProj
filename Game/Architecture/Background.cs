using System.Drawing;
using System.IO;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace Game {
    public class Background: PictureBox {
        public Background(Size size){
            Location = new Point(0,0);
            Size = size;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Tag = "background";
            Image = new Bitmap(PathToImages + "background.png");
            Visible = true;
        }
        protected string PathToImages = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.FullName +
            "\\Images\\";
    }
}