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
    public class Weapon : WeaponIcons { 
        public WeaponType WeaponType { get; set; }
        public DynamicObject Owner { get; set; }
        public int Damage { get; set; }
        public int BulletCount { get; set; }
        public int ReloadingTime { get; set; }
        public WeaponIcons WeaponIcons { get; set; }
        public double SplashRadius { get; set; }
        public int BulletSpeed { get; set; }
        public Vector BulletGravity { get; set; }
        public Weapon(System.Drawing.Size size, System.Drawing.Point location, 
            WeaponType weaponType, int bulletCount, int reloadingTime, double splashRadius, int damage , 
            int bulletSpeed, Vector bulletGravity, DynamicObject owner) : base(size, location, weaponType) {
            BulletCount = bulletCount;
            ReloadingTime = reloadingTime;
            SplashRadius = splashRadius;
            BulletSpeed = bulletSpeed;
            BulletGravity = bulletGravity;
            Damage = damage;
            Owner = owner;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Visible = false;
            WeaponType = weaponType;
        }

        public void ChangeWeapon(Weapon weapon)
        {
            BulletCount = weapon.BulletCount;
            ReloadingTime = weapon.ReloadingTime;
            SplashRadius = weapon.SplashRadius;
            Damage = weapon.Damage;
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
            WeaponType = weapon.WeaponType;
        }

        public void UpdateWeapon(Hero hero) {
            WeaponType weaponType = hero.Weapon.WeaponType;
            switch (this.WeaponType) {
                case WeaponType.bow:
                    if(hero.IsGoingLeft) {
                        Location = new System.Drawing.Point(
                            Owner.Location.X, Owner.Location.Y + 15);
                        weaponType = WeaponType.bowLeft;
                    }
                    if(hero.IsGoingRight) {
                        Location = new System.Drawing.Point(
                            Owner.Location.X + 15, Owner.Location.Y + 15);
                        weaponType = WeaponType.bowRight;
                    }
                    break;
                case WeaponType.kunai:
                    if(hero.IsGoingLeft) {
                        Location = new System.Drawing.Point(
                            Owner.Location.X-9, Owner.Location.Y + 20);
                        weaponType = WeaponType.kunaiLeft;
                    }
                    if (hero.IsGoingRight) {
                        Location = new System.Drawing.Point(
                            Owner.Location.X + 20, Owner.Location.Y + 20);
                        weaponType = WeaponType.kunaiRight;
                    }
                    break;
                case WeaponType.shuriken: 
                    if(hero.IsGoingLeft)
                        Location = new System.Drawing.Point(
                            Owner.Location.X-8, Owner.Location.Y + 21);
                    
                    if (hero.IsGoingRight)
                        Location = new System.Drawing.Point(
                            Owner.Location.X + 21, Owner.Location.Y + 21);
                    weaponType = WeaponType.shuriken;
                    break;
                case WeaponType.stone:
                    Location = new System.Drawing.Point(
                        Owner.Location.X + 20, Owner.Location.Y + 20);
                    break;
            }
            Image = new Bitmap(PathToImages + _weaponTypeIcons[weaponType]);
        }
        
        public Vector GetTotalBulletVector() {
            throw new NotImplementedException();
        }
    }
}
