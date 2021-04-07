using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game
{
    public abstract class Entity : IEntityInterface
    {
        public Entity(string name, string imageName, Vector location, int width, int height)
        {
            Name = name;
            ImageName = imageName;
            Location = location;
            Width = width;
            Height = height;
        }
        public string Name { get; }
        public string ImageName { get; private set; }
        public int DrowingPriority { get; set; }
        public Vector Location { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public abstract void OnConflict(Entity entity);
    }
}
