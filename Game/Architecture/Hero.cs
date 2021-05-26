using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
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
        public Timer FrameRateTimer = new Timer();
        private int _currentFrame = 0;
        private Dictionary<int,string> _framesRight = new Dictionary<int, string> {
            {0,"heroRight1.png"},
            {1,"heroRight2.png"},
            {2,"heroRight3.png"},
            {3,"heroRight4.png"},
            {4,"heroRight5.png"},
            {5,"heroRight6.png"},
            {6,"heroRight7.png"},
            {7,"heroRight8.png"},
            {8,"heroRight9.png"},
            {9, "heroRight10.png"},
            {10,"heroRight11.png"},
            {11,"heroRight12.png"},
            {12,"heroRight13.png"},
            {13,"heroRight14.png"},
            {14,"heroRight15.png"},
            {15,"heroRight16.png"},
            {16,"heroRight17.png"},
        };
        private Dictionary<int,string> _framesLeft = new Dictionary<int, string> {
            {0,"heroLeft1.png"},
            {1,"heroLeft2.png"},
            {2,"heroLeft3.png"},
            {3,"heroLeft4.png"},
            {4,"heroLeft5.png"},
            {5,"heroLeft6.png"},
            {6,"heroLeft7.png"},
            {7,"heroLeft8.png"},
            {8,"heroLeft9.png"},
            {9,"heroLeft10.png"},
            {10,"heroLeft11.png"},
            {11,"heroLeft12.png"},
            {12,"heroLeft13.png"},
            {13,"heroLeft14.png"},
            {14,"heroLeft15.png"},
            {15,"heroLeft16.png"},
            {16,"heroLeft17.png"},
        };
        
        public Hero(int health, int speed, int jumpHeight, Point location, Size size)
            : base(health, speed, jumpHeight, location, size) {
            Tag = "hero";
            Image = new Bitmap(PathToImages + "heroRight.png");
            Visible = false;
            Weapon = new Weapon(new Size(26, 26), new Point(Location.X + 10, Location.Y+15), 
                WeaponType.stone, 10, 0.2, 1.5, 30,5, new Vector(), this); // уточнить по векторам
        }

        public bool ActInConflict(Hero hero, Monster monster) {
            hero.Health -= monster.Damage;
            return hero.Health > 0;
          
        }
        public bool IsGoingLeft {
            get { return _isGoingLeft; }
            set { _isGoingLeft = value; }
        }
        private bool _isGoingLeft;
        public bool IsGoingRight {
            get { return _isGoingRight; }
            set { _isGoingRight = value; }
        }
        private bool _isGoingRight;
        public bool IsJumping { get; set; }
        public bool IsLanded { get; set; }
        public int CurrentJumpHeight { get; set; }
        public HealthBar HealthBar;
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
                if (value == true)
                    this.ViewDirecton = ViewDirecton.LookingRight;
                else
                    this.ViewDirecton = ViewDirecton.LookingLeft;
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
                if (value == true)
                    this.ViewDirecton = ViewDirecton.LookingLeft;
                else
                    this.ViewDirecton = ViewDirecton.LookingRight;
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
                    bulletSize = new Size(30,15);
                    break;
                case WeaponType.kunai: 
                    bulletSize = new Size(30,30);
                    break;
                case WeaponType.shuriken: 
                    bulletSize = new Size(30,30);
                    break;
                case WeaponType.stone: 
                    bulletSize = new Size(26, 26);
                    break;
                case WeaponType.platformMaker:
                    bulletSize = new Size(30, 30);
                    break;
            }

            var aimState = IsLookingRight ? -Weapon.AimState : Weapon.AimState;
            var bullet = new Bullet(new Point(game.Hero.Location.X, game.Hero.Location.Y + 30), 
                bulletSize,Weapon.Damage, Weapon.BulletSpeed,
                aimState,
                typeOfWeapon, this.ViewDirecton);
            Weapon.Bullets.Add(bullet);
            
            game.FiredBullets.Add(bullet);
            if (shouldChangeWeapon && Weapon.WeaponType != WeaponType.platformMaker) {
                var oldAimState = Weapon.AimState;
                Weapon = new Weapon(
                    new Size(26, 26), new Point(Location.X, Location.Y + 35),
                    WeaponType.stone, 10, 0.2, 1.5, 30, 5,
                    new Vector(), this);
                Weapon.ChangeAim(oldAimState);
                game.WeaponIcon.UpdateWeapon(game.Hero.Weapon.WeaponType);
            }
        }

        public void ChangeFrame() {
            _currentFrame = (_currentFrame + 1) % (_framesRight.Count - 1);
            if(_isLookingRight)
                Image = new Bitmap(PathToImages + _framesRight[_currentFrame]);
            else 
                Image = new Bitmap(PathToImages + _framesLeft[_currentFrame]);
        }

        public void MakeActionWithBullet(GameModel game)
        {
            if (game.Hero.Weapon.WeaponType == WeaponType.platformMaker
                && game.Hero.Weapon.Bullets.Count != 0) {
                var bullet = game.Hero.Weapon.Bullets.First();
                var platform = new Platform(
                    new Point(bullet.Location.X - 50, bullet.Location.Y + 30),
                        new Size(150, 40));
                game.TemporalEnvironmentObjects.Add(platform);
                game.EnvironmentObjects.Add(platform);
                game.FiredBullets.Remove(bullet);
                if (game.Hero.Weapon.Bullets.Contains(bullet))
                    game.Hero.Weapon.Bullets.Remove(bullet);
                if (game.Hero.Weapon.BulletCount == 0)
                {
                    var oldAimState = Weapon.AimState;
                    Weapon = new Weapon(
                        new Size(26, 26), new Point(Location.X + 10, Location.Y + 15),
                        WeaponType.stone, 10, 0.2, 1.5, 30, 5,
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
