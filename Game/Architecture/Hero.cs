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
    public class Hero : PictureBox{
        
        public Hero(int health, int speed, int jumpHeight, Point location, Size size){
            Health = health;
            Speed = speed;
            JumpHeight = jumpHeight;
            Location = location;
            Size = size;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Tag = "hero";
            Image = new Bitmap(PathToImages + "hero.png");
            Visible = true;
        }
        public int DrawingPriority { get; set; }
        public int Health { get; set; }
        public int Speed { get; }
        public int JumpHeight { get; }
        public Weapon Weapon { get; set; }

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
        public void OnConflict(Entity entity) { }
        public void Action() { }
        public void OnDeath() { }

        public void Move() {
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
        private int _jumpLimit = 200;
        
        
        private string PathToImages = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.FullName +
            "\\Images\\";
    }
}
