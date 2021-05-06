using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Game {
    public class Bullet : PictureBox {
        public int Speed { get; set; }
        public ViewDirecton ShootingDirection { get; set; }
        public int Damage { get; set; }
        public WeaponType WeaponType { get; set; }
        public Bullet(Point location, Size size, int damage, int speed, WeaponType weaponType,ViewDirecton shootingDirection)  {
            Speed = speed;
            Location = location;
            Size = size;
            Damage = damage;
            WeaponType = weaponType;
            ShootingDirection = shootingDirection;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Visible = false;
            if (ShootingDirection == ViewDirecton.LookingLeft) {
                Image = new Bitmap(PathToImages + _weaponBulletIconLeft[weaponType]);
            }

            if (ShootingDirection == ViewDirecton.LookingRight) {
                Image = new Bitmap(PathToImages + _weaponBulletIconRight[weaponType]);
            }
        }

        readonly Dictionary<WeaponType, string> _weaponBulletIconRight =
            new Dictionary<WeaponType, string>{
                {WeaponType.stone, "stone.png"},
                {WeaponType.shuriken, "shurikenIcon.png"},
                {WeaponType.kunai, "kunaiRight.png"},
                {WeaponType.bow, "arrowRight.png"},
            };
        readonly Dictionary<WeaponType, string> _weaponBulletIconLeft =
            new Dictionary<WeaponType, string>{
                {WeaponType.stone, "stone.png"},
                {WeaponType.shuriken, "shurikenIcon.png"},
                {WeaponType.kunai, "kunaiLeft.png"},
                {WeaponType.bow, "arrowLeft.png"},
            };

        public void Move() {
            Left += Speed;
        }
        private static string PathToImages = GetGameDirectoryRoot().FullName.ToString() + "\\Images\\";
        private static DirectoryInfo GetGameDirectoryRoot() {
            var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            while (!dir.ToString().EndsWith("GameOfTheCentury")) {
                dir = dir.Parent;
            }
            return dir;
        }
    }
}