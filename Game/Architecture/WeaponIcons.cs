using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public enum WeaponTypeIcons
    {
        stone,
        shuriken,
        kunai,
        bow
    }
    
    public class WeaponIcons : StaticObject
    {
        private readonly Dictionary<WeaponTypeIcons, string> _weaponTypeIcons =
            new Dictionary<WeaponTypeIcons, string>()
            {
                {WeaponTypeIcons.stone, "stone.png"},
                {WeaponTypeIcons.shuriken, "shurikenIcon.png"},
                {WeaponTypeIcons.kunai, "kunaiIcon.png"},
                {WeaponTypeIcons.bow, "bow.png"}
            };

        public WeaponIcons(Size size, Point location, WeaponTypeIcons weaponTypeIcons) : base(size, location)
        {
            SizeMode = PictureBoxSizeMode.StretchImage;
            Tag = "weaponIcon";
            Image = new Bitmap(PathToImages + _weaponTypeIcons[weaponTypeIcons]);
            Visible = true;
        }

        public void UpdateWeapon(WeaponTypeIcons weaponTypeIcons)
        {
            Image = new Bitmap(PathToImages + _weaponTypeIcons[weaponTypeIcons]);
        }
    }
}