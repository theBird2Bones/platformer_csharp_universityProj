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
    
    public class Hero : DynamicObject {
        public Hero(int health, int speed, int jumpHeight, Point location, Size size)
            : base(health, speed, jumpHeight, location, size) {
            Tag = "hero";
            Image = new Bitmap(PathToImages + "heroRight.png");
            Visible = false;
            IsLookingRight = true;
            Weapon = new Weapon(new Size(13, 13), new Point(Location.X+10, Location.Y+15), 
                WeaponTypeIcons.stone, 1, 12, 1.5, 1 ,new Vector(), new Vector(), this); // уточнить по векторам
        }

        public bool ActInConflict(Hero hero, Monster monster) {
            //if (hero.Bounds.IntersectsWith(monster.Bounds))
            hero.Health -= monster.Damage;
            return hero.Health > 0;
          
        }
        public bool IsGoingLeft { get; set; }
        public bool IsGoingRight { get; set; }
        public bool IsJumping { get; set; }
        public bool IsLanded { get; set; }
        public int CurrentJumpHeight { get; set; }
        public bool IsMoving => IsGoingLeft || IsGoingRight || IsJumping;

        public bool IsLookingRight {
            get {
                if(_isLookingLeft && _isLookingRight)
                    throw new ArgumentException("why hero looking right and left simultaneously???");
                return _isLookingRight;
            }
            set {
                _isLookingRight = value;
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
                _isLookingRight = !value;
            }
        }
        public const int JumpLimit = 200;
        public int TempJumpLimit = JumpLimit;
        private bool _isLookingRight;
        private bool _isLookingLeft;
        public new void Move() {
            if (IsGoingLeft) {
                this.Left -= this.Speed;
                Image = new Bitmap(PathToImages + "heroLeft.png");
            }
            if (IsGoingRight) {
                this.Left += this.Speed;
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
            Weapon.UpdateWeapon(this);
        }
    }
}
