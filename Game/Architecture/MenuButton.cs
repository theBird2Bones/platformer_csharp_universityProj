using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace Game
{
    public class MenuButton : StaticObject
    {
        public MenuButton(Size size, Point location)
            :base( size, location){
            SizeMode = PictureBoxSizeMode.StretchImage;
            Tag = "menuButton";
            Image = new Bitmap(PathToImages + "menuIcon.png");
            Visible = true;
        }
    }
}