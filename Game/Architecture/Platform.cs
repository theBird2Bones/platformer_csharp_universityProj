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