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
    public enum WeaponType
    {
        stone,
        shuriken,
        kunai,
        kunaiRight,
        kunaiLeft,
        bow,
        bowRight,
        bowLeft,
        platformMaker,
        platformMakerLeft,
        platformMakerRight,
    }
    
    public class WeaponIcons : StaticObject
    {
        protected readonly Dictionary<WeaponType, string> _weaponTypeIcons =
            new Dictionary<WeaponType, string>{
                {WeaponType.stone, "stone.png"},
                {WeaponType.shuriken, "shurikenIcon.png"},
                {WeaponType.kunai, "kunaiRight.png"},
                {WeaponType.kunaiRight, "kunaiRight.png"},
                {WeaponType.kunaiLeft, "kunaiLeft.png"},
                {WeaponType.bow, "bowRight.png"},
                {WeaponType.bowRight, "bowRight.png"},
                {WeaponType.bowLeft, "bowLeft.png"},
                {WeaponType.platformMaker, "platformMakerSmallRight.png"},
                {WeaponType.platformMakerLeft, "platformMakerSmallLeft.png"},
                {WeaponType.platformMakerRight, "platformMakerSmallRight.png"},
            };

        public WeaponIcons(Size size, Point location, WeaponType weaponType) : base(size, location) {
            SizeMode = PictureBoxSizeMode.StretchImage;
            Tag = "weaponIcon";
            Image = new Bitmap(PathToImages + _weaponTypeIcons[weaponType]);
            Visible = true;
        }

        public void UpdateWeapon(WeaponType weaponType) {
            Image = new Bitmap(PathToImages + _weaponTypeIcons[weaponType]);
        }
    }
}