using System.Drawing;
using System.Drawing.Imaging;
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
        protected string PathToImages = GetGameDirectoryRoot().FullName.ToString() + "\\Images\\";
        private static DirectoryInfo GetGameDirectoryRoot() {
            var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            while (!dir.ToString().EndsWith("GameOfTheCentury")) {
                dir = dir.Parent;
            }

            return dir;
        }
    }
}