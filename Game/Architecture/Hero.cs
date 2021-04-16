using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Game{
    public enum Movement {
        goLeft,
        goRight,
        Jump,
    }

    public enum ActionWithKey {
        Unpressed,
        Pressed,
        None,
    }
    public class Hero : DynamicObject
    {
        public Hero(int health, int speed, int jumpHeight, Point location, Size size)
            : base(health, speed, jumpHeight, location, size)
        {
            Tag = "hero";
            Image = new Bitmap(PathToImages + "hero.png");
        }

        public bool IsMoving {
            get {
                return IsGoingLeft || IsGoingRight || IsJumping;
            }
        }

        public bool IsGoingLeft { get; set; }
        public bool IsGoingRight { get; set; }
        public bool IsJumping { get; set; } = false;
        public bool IsLanded { get; set; }
        
        public int CurrentJumpHeight { get; set; }

        public new void Move() {
            if (IsGoingLeft) 
                this.Left -= this.Speed;
            if (IsGoingRight)
                this.Left += this.Speed;
            if (IsJumping && CurrentJumpHeight <= _jumpLimit) {
                this.Top -= this.JumpHeight;
                CurrentJumpHeight += this.JumpHeight;
            }
            else if (CurrentJumpHeight > _jumpLimit) {
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

        public void Action(GameModel game, Keys key, ActionWithKey actionWithKey) {
            ProcessKeys(game, key, actionWithKey);
            if (game.Hero.IsMoving)
            {
                game.Hero.Move();
                game.Hero.Refresh();
            }

            if (!game.Hero.IsJumping)
            {
                game.Hero.Top += game.Hero.JumpHeight;
                game.Hero.Refresh();
            }
            foreach (Control obj in game.EnvironmentObjects)
            {
                if (obj is Platform && game.Hero.Bounds.IntersectsWith(obj.Bounds))
                {
                    if (game.Hero.Bottom <= obj.Top + game.Hero.Height / 3d)
                    {
                        game.Hero.Top = obj.Top - game.Hero.Height;
                        game.Hero.Refresh();
                    }
                    game.Hero.Refresh();
                    game.Hero.IsLanded = true;
                    game.Hero.CurrentJumpHeight = 0;
                }
            }
        }

        private int _jumpLimit = 200;
    }
}
