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
    public class Weapon : WeaponIcons, IWeaponInterface { 
        public WeaponTypeIcons WeaponTypeIcons { get; set; }
        public DynamicObject Owner { get; set; }
        public int BulletCount { get; set; }
        public int ReloadingTime { get; set; }
        public WeaponIcons WeaponIcons { get; set; }
        public double SplashRadius { get; set; }
        public Vector BulletSpeed { get; set; }
        public Vector BulletGravity { get; set; }
        public Weapon(System.Drawing.Size size, System.Drawing.Point location, 
            WeaponTypeIcons weaponTypeIcons, int bulletCount, int reloadingTime, double splashRadius, 
            Vector bulletSpeed, Vector bulletGravity, DynamicObject owner) : base(size, location, weaponTypeIcons) {
            BulletCount = bulletCount;
            ReloadingTime = reloadingTime;
            SplashRadius = splashRadius;
            BulletSpeed = bulletSpeed;
            BulletGravity = bulletGravity;
            Owner = owner;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Visible = false;
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

        public void UpdateWeapon(Hero hero) {
            WeaponTypeIcons weaponTypeIcons = hero.Weapon.WeaponTypeIcons;
            switch (this.WeaponTypeIcons) {
                case WeaponTypeIcons.bow:
                    if(hero.IsGoingLeft) {
                        Location = new System.Drawing.Point(
                            Owner.Location.X, Owner.Location.Y + 15);
                        weaponTypeIcons = WeaponTypeIcons.bowLeft;
                    }
                    if(hero.IsGoingRight) {
                        Location = new System.Drawing.Point(
                            Owner.Location.X + 15, Owner.Location.Y + 15);
                        weaponTypeIcons = WeaponTypeIcons.bowRight;
                    }
                    break;
                case WeaponTypeIcons.kunai:
                    if(hero.IsGoingLeft) {
                        Location = new System.Drawing.Point(
                            Owner.Location.X-9, Owner.Location.Y + 20);
                        weaponTypeIcons = WeaponTypeIcons.kunaiLeft;
                    }
                    if (hero.IsGoingRight) {
                        Location = new System.Drawing.Point(
                            Owner.Location.X + 20, Owner.Location.Y + 20);
                        weaponTypeIcons = WeaponTypeIcons.kunaiRight;
                    }
                    break;
                case WeaponTypeIcons.shuriken: 
                    if(hero.IsGoingLeft)
                        Location = new System.Drawing.Point(
                            Owner.Location.X-8, Owner.Location.Y + 21);
                    
                    if (hero.IsGoingRight)
                        Location = new System.Drawing.Point(
                            Owner.Location.X + 21, Owner.Location.Y + 21);
                    weaponTypeIcons = WeaponTypeIcons.shuriken;
                    break;
                case WeaponTypeIcons.stone:
                    Location = new System.Drawing.Point(
                        Owner.Location.X + 20, Owner.Location.Y + 20);
                    break;
            }
            Image = new Bitmap(PathToImages + _weaponTypeIcons[weaponTypeIcons]);
        }
        
        public Vector GetTotalBulletVector() {
            throw new NotImplementedException();
        }
    }
}
