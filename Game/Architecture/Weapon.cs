using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Game
{
    public class Weapon : WeaponIcons, IWeaponInterface
    { // поясни за базар
        public Weapon(System.Drawing.Size size, System.Drawing.Point location, 
            WeaponTypeIcons weaponTypeIcons, int bulletCount, int reloadingTime, double splashRadius, 
            Vector bulletSpeed, Vector bulletGravity, DynamicObject owner) : base(size, location, weaponTypeIcons)
        {
            BulletCount = bulletCount;
            ReloadingTime = reloadingTime;
            SplashRadius = splashRadius;
            BulletSpeed = bulletSpeed;
            BulletGravity = bulletGravity;
            Owner = owner;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Visible = true;
            BackColor = Color.Transparent;
            WeaponTypeIcons = weaponTypeIcons;
        }

        public void ChangeWeapon(Weapon weapon)
        {
            BulletCount = weapon.BulletCount;
            ReloadingTime = weapon.ReloadingTime;
            SplashRadius = weapon.SplashRadius;
            BulletSpeed = weapon.BulletSpeed;
            BulletGravity = weapon.BulletGravity;
            Owner = weapon.Owner;
            SizeMode = weapon.SizeMode;
            Visible = weapon.Visible;
            BackColor = weapon.BackColor;
            SizeMode = weapon.SizeMode;
            Location = weapon.Location;
            Size = weapon.Size;
            Tag = weapon.Tag;
            Image = weapon.Image;
            Visible = weapon.Visible;
            WeaponTypeIcons = weapon.WeaponTypeIcons;
        }

        public void UpdateWeapon()
        {
            Location = new System.Drawing.Point(
                Owner.Location.X + 15, Owner.Location.Y + 15);
        }

        public WeaponTypeIcons WeaponTypeIcons { get; set; }
        public DynamicObject Owner { get; set; }
        public int BulletCount { get; set; }
        public int ReloadingTime { get; set; }
        public WeaponIcons WeaponIcons { get; set; }
        public double SplashRadius { get; set; }
        public Vector BulletSpeed { get; set; }
        public Vector BulletGravity { get; set; }

        public Vector GetTotalBulletVector()
        {
            throw new NotImplementedException();
        }
    }
}
