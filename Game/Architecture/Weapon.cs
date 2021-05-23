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
        public Hero Owner { get; set; }
        public int Damage { get; set; }
        public int BulletCount { get; set; }
        public double ReloadingTime { get; set; }
        public WeaponIcons WeaponIcons { get; set; }
        public double SplashRadius { get; set; }
        public int BulletSpeed { get; set; }
        public Vector BulletGravity { get; set; }
        public List<Bullet> Bullets { get; set; }
        public double AimState { get; set; }
        public PictureBox Aim { get; set; }
        public Weapon(System.Drawing.Size size, System.Drawing.Point location, 
            WeaponType weaponType, int bulletCount, double reloadingTime, double splashRadius, int damage , 
            int bulletSpeed, Vector bulletGravity, Hero owner) : base(size, location, weaponType) {
            Aim = new PictureBox();
            Aim.Size = new System.Drawing.Size(20,20);
            Aim.Image = new Bitmap(PathToImages + "aim.png");
            ChangeAim(0);
            BulletCount = bulletCount;
            ReloadingTime = reloadingTime;
            SplashRadius = splashRadius;
            Bullets = new List<Bullet>();
            BulletSpeed = bulletSpeed;
            BulletGravity = bulletGravity;
            Damage = damage;
            Owner = owner;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Visible = false;
            WeaponType = weaponType;
        }

        public void ChangeAim(double aimState)
        {
            if (Math.Abs(aimState-Math.PI/2) >= 0.1)
            {
                AimState = aimState;
                double sin = Math.Sin(aimState);
                if (Math.Cos(aimState) > 0)
                    sin = -sin;

                Aim.Location = new System.Drawing.Point(
                   Convert.ToInt32(Math.Ceiling(Location.X + Math.Cos(aimState)*50)),
                   Convert.ToInt32(Math.Ceiling(Location.Y + sin*50)));
            }
        }

        public void ChangeWeapon(Weapon weapon)
        {
            Aim = new PictureBox();
            Aim.Size = new System.Drawing.Size(20, 20);
            Aim.Image = new Bitmap(PathToImages + "aim.png");
            ChangeAim(0);
            Bullets = new List<Bullet>();
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

        public void UpdateWeapon() {
            WeaponType weaponType = Owner.Weapon.WeaponType;
            switch (this.WeaponType) {
                case WeaponType.bow:
                    if(Owner.IsLookingRight) {
                        Location = new System.Drawing.Point(
                            Owner.Location.X + 30, Owner.Location.Y + 25);
                        weaponType = WeaponType.bowRight;
                    }
                    else {
                        Location = new System.Drawing.Point(
                            Owner.Location.X - 15, Owner.Location.Y + 25);
                        weaponType = WeaponType.bowLeft;
                    }
                    break;
                case WeaponType.kunai:
                    if(Owner.IsLookingRight) {
                        Location = new System.Drawing.Point(
                            Owner.Location.X + 45, Owner.Location.Y + 35);
                        weaponType = WeaponType.kunaiRight;
                    }
                    else {
                        Location = new System.Drawing.Point(
                            Owner.Location.X - 20, Owner.Location.Y + 35);
                        weaponType = WeaponType.kunaiLeft;
                        
                    }
                    break;
                case WeaponType.shuriken:
                    if (Owner.IsLookingRight)
                        Location = new System.Drawing.Point(
                            Owner.Location.X + 40, Owner.Location.Y + 35);
                    else
                        Location = new System.Drawing.Point(
                            Owner.Location.X - 15, Owner.Location.Y + 35);
                    weaponType = WeaponType.shuriken;
                    break;
                case WeaponType.stone:
                    if (Owner.IsLookingRight)
                        Location = new System.Drawing.Point(
                            Owner.Location.X + 40, Owner.Location.Y + 35);
                    else
                        Location = new System.Drawing.Point(
                            Owner.Location.X-5, Owner.Location.Y + 35);
                    break;
                case WeaponType.platformMaker:
                    if (Owner.IsLookingRight)
                    {
                        Location = new System.Drawing.Point(
                            Owner.Location.X + 40, Owner.Location.Y + 10);
                        weaponType = WeaponType.platformMakerRight;
                    }
                    else
                    {
                        Location = new System.Drawing.Point(
                            Owner.Location.X - 40, Owner.Location.Y + 10);
                        weaponType = WeaponType.platformMakerLeft;
                    }
                    break;
            }
            if (Owner.IsLookingRight)
            {
                if (Math.Cos(AimState) <= 0)
                    AimState = -(Math.PI - AimState);
            }
            else
            {
                if (Math.Cos(AimState) > 0)
                    AimState = -(Math.PI - AimState);
            }
            ChangeAim(AimState);
            Image = new Bitmap(PathToImages + _weaponTypeIcons[weaponType]);
        }
        
        public Vector GetTotalBulletVector() {
            throw new NotImplementedException();
        }
    }
}
