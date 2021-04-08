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
        private Point ZIROLOCATION = new Point(0, 0);
        private Size DEFAULTSIZE = new Size(100, 100);
        private string DEFAULTNAME = "entity";
        private string DEFAULTIMAGENAME = "nothing";
        private int DRAWINGPRIORITY = 3;
        public Entity()
        {
            Name = DEFAULTNAME;
            ImageName = DEFAULTIMAGENAME;
            DrawingPriority = DRAWINGPRIORITY;
            Location = ZIROLOCATION;
            Size = DEFAULTSIZE;
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
