using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game
{
    class Character : ICharacterInterface
    {
        public Character(string imageName, int drowingPriority, Vector location, int width, 
            int height, int health, int speed, int jumpHeight, Weapon weapon)
        {
            ImageName = imageName;
            DrowingPriority = drowingPriority;
            Location = location;
            Width = width;
            Height = height;
            Health = health;
            Speed = speed;
            JumpHeight = jumpHeight;
            Weapon = weapon;
        }
        public string ImageName { get; }
        public int DrowingPriority { get; set; }
        public Vector Location { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Health { get; set; }
        public int Speed { get; }
        public int JumpHeight { get; }
        public Weapon Weapon { get; set; }
        public void OnConflict(Entity entity) { }
        public void Action() { }
        public void OnDeath() { }
    }
}
