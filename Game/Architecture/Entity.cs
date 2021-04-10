using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game
{
    public abstract class Entity : IEntityInterface
    {
        private Point _zeroLocation = new Point(0, 0);
        private Size _defaultSize = new Size(100, 100);
        private string _defaultName = "entity";
        private string _defaultImageName = "nothing";
        private int _drawingPriority = 3;
        public Entity()
        {
            Name = _defaultName;
            ImageName = _defaultImageName;
            DrawingPriority = _drawingPriority;
            Location = _zeroLocation;
            Size = _defaultSize;
        }
        public Entity(string name, string imageName, int drawingPriority, Point location, Size size)
        {
            Name = name;
            ImageName = imageName;
            DrawingPriority = drawingPriority;
            Location = location;
            Size = size;
        }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public int DrawingPriority { get; set; }
        public Point Location { get; set; }
        public Size Size { get; set; }
        public abstract void OnConflict(Entity entity);
    }
}
