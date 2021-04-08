using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game
{
    class Character : ICharacterInterface
    {
        public Character(string imageName, int drowingPriority, Point location, 
            Size size, int health, int speed, int jumpHeight, Weapon weapon)
        {
            ImageName = imageName;
            DrawingPriority = drowingPriority;
            Location = location;
            Size = size;
            Health = health;
            Speed = speed;
            JumpHeight = jumpHeight;
            Weapon = weapon;
        }
        public string ImageName { get; }
        public int DrawingPriority { get; set; }
        public Point Location { get; set; }
        public Size Size { get; set; }
        public int Health { get; set; }
        public int Speed { get; }
        public int JumpHeight { get; }
        public Weapon Weapon { get; set; }
        public void OnConflict(Entity entity) { }
        public void Action() { }
        public void OnDeath() { }
    }
}
