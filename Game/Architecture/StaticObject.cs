using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game
{
    public class StaticObject : Entity
    {
        public StaticObject() { }
        public StaticObject(string name, string imageName, int drawingPriority, 
            Point location, Size size) 
            : base(name, imageName, drawingPriority, location, size)
        {
        }

        public StaticObject WithName(string name)
        {
            Name = name;
            return this;
        }

        public StaticObject WithImageName(string name)
        {
            ImageName = name;
            return this;
        }

        public StaticObject WithDrowingPriority(int drawingPriority)
        {
            DrawingPriority = drawingPriority;
            return this;
        }

        public StaticObject WithLocation(Point location)
        {
            Location = location;
            return this;
        }

        public StaticObject WithSize(Size size)
        {
            Size = size;
            return this;
        }

        public override void OnConflict(Entity entity)
        {
        }
    }
}
