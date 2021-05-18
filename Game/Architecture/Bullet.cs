using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Game {
    public class Bullet : PictureBox {
        public int ForceValue { get; set; }
        public ViewDirecton ShootingDirection { get; set; }
        public int Damage { get; set; }
        public WeaponType WeaponType { get; set; }
        public double Direction { get; set; }
        public double GRAVITY = 0.3;
        public Bullet(Point location, Size size, int damage, int speed, double direction, 
            WeaponType weaponType,ViewDirecton shootingDirection)  {
            Location = location;
            Size = size;
            Damage = damage;
            ForceValue = speed;
            Direction = direction;
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
                {WeaponType.platformMaker, "platformMakerBullet.png"},
            };
        readonly Dictionary<WeaponType, string> _weaponBulletIconLeft =
            new Dictionary<WeaponType, string>{
                {WeaponType.stone, "stone.png"},
                {WeaponType.shuriken, "shurikenIcon.png"},
                {WeaponType.kunai, "kunaiLeft.png"},
                {WeaponType.bow, "arrowLeft.png"},
                {WeaponType.platformMaker, "platformMakerBullet.png"},
            };

        public System.Windows.Vector MakeTotalForce()
        {
            return new System.Windows.Vector(
                Math.Cos(Direction) * ForceValue*2,
                Math.Sin(Direction) * ForceValue*2 + GRAVITY);
        }

        public void Move() {
            var totalForce = MakeTotalForce();
            var tForce = new Point(Convert.ToInt32(Math.Ceiling(totalForce.X)), 
                Convert.ToInt32(Math.Ceiling(totalForce.Y)));
            Location = new Point(Location.X + tForce.X, Location.Y + tForce.Y);
            var angle = Math.Asin(totalForce.Y /
                Math.Sqrt(totalForce.X * totalForce.X
                + totalForce.Y * totalForce.Y));
            if (totalForce.X > 0)
                Direction = angle;
            else
                Direction = Math.PI - angle;
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