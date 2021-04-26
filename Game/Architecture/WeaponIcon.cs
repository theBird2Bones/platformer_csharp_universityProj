using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public enum  WeaponTypeIcon{
        stone,
        shuriken,
        kunai,
        bow
    }

    public class WeaponIcon : StaticObject
    {
        private readonly Dictionary<WeaponTypeIcon, string> _weaponTypeIcon = new Dictionary<WeaponTypeIcon, string>() {
            {WeaponTypeIcon.stone, "stone.png"},
            {WeaponTypeIcon.shuriken, "shurikenIcon.png"},
            {WeaponTypeIcon.kunai, "kunaiIcon.png"},
            {WeaponTypeIcon.bow, "bow.png"},
        };

        public WeaponIcon(Size size, Point location, WeaponTypeIcon weaponIcon) : base(size, location)
        {
            SizeMode = PictureBoxSizeMode.StretchImage;
            Tag = "weaponIcon";
            Image = new Bitmap(PathToImages + _weaponTypeIcon[weaponIcon]);
            Visible = true;
        }
    }
}