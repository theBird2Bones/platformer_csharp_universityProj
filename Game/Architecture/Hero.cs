using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using WinFormsApp1;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace Game{
    public enum ActionWithKey {
        Unpressed,
        Pressed,
        None,
    }

    public enum ViewDirecton {
        LookingRight,
        LookingLeft,
    }
    
    public class Hero : DynamicObject {
        public Hero(int health, int speed, int jumpHeight, Point location, Size size)
            : base(health, speed, jumpHeight, location, size) {
            Tag = "hero";
            Image = new Bitmap(PathToImages + "heroRight.png");
            Visible = false;
            Weapon = new Weapon(new Size(13, 13), new Point(Location.X+10, Location.Y+15), 
                WeaponType.stone, 1, 0.295d, 1.5, 30,4, new Vector(), this); // уточнить по векторам
        }

        public bool ActInConflict(Hero hero, Monster monster) {
            hero.Health -= monster.Damage;
            return hero.Health > 0;
          
        }
        public bool IsGoingLeft
        {
            get { return _isGoingLeft; }
            set {
                _isGoingLeft = value;
            }
        }
        private bool _isGoingLeft;
        public bool IsGoingRight
        {
            get { return _isGoingRight; }
            set
            {
                _isGoingRight = value;
                
            }
        }
        private bool _isGoingRight;
        public bool IsJumping { get; set; }
        public bool IsLanded { get; set; }
        public int CurrentJumpHeight { get; set; }
        public bool IsMoving => IsGoingLeft || IsGoingRight || IsJumping;
        public ViewDirecton ViewDirecton { get; set; }

        public new bool IsLookingRight {
            get {
                if(_isLookingLeft && _isLookingRight)
                    throw new ArgumentException("why hero looking right and left simultaneously???");
                return _isLookingRight;
            }
            set {
                _isLookingRight = value;
                this.ViewDirecton = ViewDirecton.LookingRight;
                _isLookingLeft = !value;
            }
        }

        public bool IsLookingLeft {
            get {
                if(_isLookingLeft && _isLookingRight)
                    throw new ArgumentException("why hero looking right and left simultaneously???");
                return _isLookingLeft;
            }
            set {
                _isLookingLeft = value;
                this.ViewDirecton = ViewDirecton.LookingLeft;
                _isLookingRight = !value;
            }
        }
        public const int JumpLimit = 200;
        public int TempJumpLimit = JumpLimit;
        private bool _isLookingRight;
        private bool _isLookingLeft;
        private DateTime timeOfLastShoot = DateTime.Now;
        public new void Move() {
            if (IsGoingLeft) {
                this.Left -= this.Speed;
                IsLookingLeft = true;
                Image = new Bitmap(PathToImages + "heroLeft.png");
            }
            if (IsGoingRight) {
                this.Left += this.Speed;
                IsLookingRight = true;
                Image = new Bitmap(PathToImages + "heroRight.png");
            }
            if (IsJumping && CurrentJumpHeight <= TempJumpLimit) {
                this.Top -= this.JumpHeight;
                CurrentJumpHeight += this.JumpHeight;
            }
            else if (CurrentJumpHeight > TempJumpLimit) {
                IsJumping = false;
            }
        }

        public void Shoot(GameModel game) {
            var typeOfWeapon = Weapon.WeaponType;
            var shouldChangeWeapon = false;
            if (--Weapon.BulletCount <= 0) {
                shouldChangeWeapon = true;
            }
            Size bulletSize = Size.Empty;
            switch (typeOfWeapon) {
                case WeaponType.bow: 
                    bulletSize = new Size(17,10);
                    break;
                case WeaponType.kunai: 
                    bulletSize = new Size(15,15);
                    break;
                case WeaponType.shuriken: 
                    bulletSize = new Size(15,15);
                    break;
                case WeaponType.stone: 
                    bulletSize = new Size(16,16);
                    break;
                case WeaponType.platformMaker:
                    bulletSize = new Size(30, 30);
                    break;
            }

            Bullet bullet = null;
            if (IsLookingRight || !IsLookingLeft) {
                bullet = new Bullet(game.Hero.Location,
                   bulletSize, Weapon.Damage, Weapon.BulletSpeed,
                   -Weapon.AimState,
                   typeOfWeapon, ViewDirecton.LookingRight) ;
                Weapon.Bullets.Add(bullet);
            }

            if (IsLookingLeft || !IsLookingRight) {
                 bullet = new Bullet(game.Hero.Location,
                    bulletSize,Weapon.Damage, Weapon.BulletSpeed,
                    Weapon.AimState,
                    typeOfWeapon, ViewDirecton.LookingLeft);
                Weapon.Bullets.Add(bullet);
            }
            game.FiredBullets.Add(bullet);
            if (shouldChangeWeapon && 
                Weapon.WeaponType != WeaponType.platformMaker)
            {
                var oldAimState = Weapon.AimState;
                Weapon = new Weapon(
                    new Size(13, 13), new Point(Location.X + 10, Location.Y + 15),
                    WeaponType.stone, 1, 0.295, 1.5, 30, 4,
                    new Vector(), this);
                Weapon.ChangeAim(oldAimState);
                game.WeaponIcon.UpdateWeapon(game.Hero.Weapon.WeaponType);
            }
        }

        public void MakeActionWithBullet(GameModel game)
        {
            if (game.Hero.Weapon.WeaponType
                == WeaponType.platformMaker
                && game.Hero.Weapon.Bullets.Count != 0)
            {
                var bullet = game.Hero.Weapon.Bullets.First();
                var platform = new Platform(
                    new Point(bullet.Location.X - 50, bullet.Location.Y + 30),
                        new Size(150, 40));
                game.EnvironmentObjects.Add(platform);
                game.FiredBullets.Remove(bullet);
                if (game.Hero.Weapon.Bullets.Contains(bullet))
                    game.Hero.Weapon.Bullets.Remove(bullet);
                if (game.Hero.Weapon.BulletCount == 0)
                {
                    var oldAimState = Weapon.AimState;
                    Weapon = new Weapon(
                        new Size(13, 13), new Point(Location.X + 10, Location.Y + 15),
                        WeaponType.stone, 1, 0.295, 1.5, 30, 4,
                        new Vector(), this);
                    Weapon.ChangeAim(oldAimState);
                    game.WeaponIcon.UpdateWeapon(game.Hero.Weapon.WeaponType);
                }
            }
        }
        
        public void ProcessKeys(GameModel game, Keys key, ActionWithKey ActionWithKey) {
            switch (ActionWithKey) {
                case ActionWithKey.Pressed:
                    switch (key) {
                        case Keys.Left:
                            game.Hero.IsGoingLeft = true;
                            break;
                        case Keys.Right:
                            game.Hero.IsGoingRight = true;
                            break;
                        case Keys.Space:
                            if (game.Hero.IsLanded) {
                                game.Hero.IsJumping = true;
                                game.Hero.IsLanded = false;
                            }
                            break;
                        case Keys.F:
                            if(DateTime.Now.Subtract(timeOfLastShoot).TotalSeconds > Weapon.ReloadingTime) {
                                Shoot(game);
                                timeOfLastShoot = DateTime.Now;
                            }
                            break;
                        case Keys.Up:
                            game.Hero.Weapon.ChangeAim(
                                game.Hero.Weapon.AimState + 0.1);
                            break;
                        case Keys.Down:
                            game.Hero.Weapon.ChangeAim(
                                game.Hero.Weapon.AimState - 0.1);
                            break;
                        case Keys.Enter:
                            MakeActionWithBullet(game);
                            break;
                    }
                    break;
                case ActionWithKey.Unpressed:
                    switch (key) {
                        case Keys.Left:
                            game.Hero.IsGoingLeft = false;
                            break;
                        case Keys.Right:
                            game.Hero.IsGoingRight = false;
                            break;
                        case Keys.Space:
                            if (game.Hero.IsJumping)
                                game.Hero.IsJumping = false;
                            break;
                    }
                    break;
            }
        }
        
        public void Action(GameModel game, Keys key, ActionWithKey actionWithKey,Timer timer) {
            if(!timer.Enabled) return;
            ProcessKeys(game, key, actionWithKey);
            // подхожу к краю карты, чтобы ее подвигать
            if (this.Left > 0 && this.IsGoingLeft && this.Left - this.Speed*2 < 0) {
                if(game.Background.Left < 0) {
                    game.Background.Move(this, 1);
                    game.SpawnLocation = new Point(game.SpawnLocation.X + game.Hero.Speed,game.SpawnLocation.Y);
                    foreach (var obj in game.EnvironmentObjects) {
                        ((StaticObject)obj).Move(this, game.Hero.Speed);
                    }

                    foreach (var monster in game.Monsters) {
                        monster.Left += game.Hero.Speed;
                    }

                    foreach (var firedBullet in game.FiredBullets) {
                        firedBullet.Left += game.Hero.Speed;
                    }
                }
                this.IsGoingLeft = false;
            }
            if (this.Right < game.MapSize.Width && this.IsGoingRight && this.Right + this.Speed*2 > game.MapSize.Width-26) {
                game.Background.Move(this,1);
                game.SpawnLocation = new Point(game.SpawnLocation.X - game.Hero.Speed,game.SpawnLocation.Y);
                foreach (var obj in game.EnvironmentObjects) {
                    ((StaticObject)obj).Move(this,game.Hero.Speed);
                }
                
                foreach (var monster in game.Monsters) {
                    monster.Left -= game.Hero.Speed;
                }
                foreach (var firedBullet in game.FiredBullets) {
                    firedBullet.Left -= game.Hero.Speed;
                }
                this.IsGoingRight = false;
            }
            if (game.Hero.IsMoving) {
                game.Hero.Move();
            }

            if (!game.Hero.IsJumping && !game.Hero.IsLanded) {
                game.Hero.Top += game.Hero.JumpHeight;
                game.Hero.Refresh();
            }
            game.Hero.IsLanded = false;
            foreach (Control obj in game.EnvironmentObjects.Where(x => x is Platform)) {
                if (obj is Platform && game.Hero.Bounds.IntersectsWith(obj.Bounds)) {
                    if (game.Hero.Bottom <= obj.Top + game.Hero.Height / 3d) {
                        game.Hero.Top = obj.Top - game.Hero.Height + 1;
                        game.Hero.IsLanded = true;
                        game.Hero.CurrentJumpHeight = 0;
                    }
                }

                if (obj is Platform && (game.Hero.Left <= obj.Right && game.Hero.Left >= obj.Left ||
                        game.Hero.Right >= obj.Left && game.Hero.Right <= obj.Right) &&
                    game.Hero.Top >= obj.Bottom) {
                    game.Hero.TempJumpLimit = game.Hero.Top - obj.Bottom > game.Hero.TempJumpLimit ?
                        Hero.JumpLimit :
                        game.Hero.Top - obj.Bottom + 35;
                    break;
                }
                game.Hero.TempJumpLimit = JumpLimit;
            }
            Weapon.UpdateWeapon();
        }
    }
}
