using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public class BackgroundWeapon : StaticObject
    {
        public BackgroundWeapon(Size size, Point location) : base(size, location)
        {
            SizeMode = PictureBoxSizeMode.StretchImage;
            Tag = "backgroundWeapon";
            Image = new Bitmap(PathToImages + "backgroundWeapon.png");
            Visible = true;
        }
    }
}