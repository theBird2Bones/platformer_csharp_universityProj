using Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    class StaticObjectBuilder : IStaticObjectBuilderInterface
    {
        public StaticObject staticObject = new StaticObject();
        public StaticObjectBuilder() { }
        public Entity Build()
        {
            return staticObject;
        }

        public StaticObjectBuilder SetName(string name)
        {
            staticObject = staticObject.WithName(name);
            return this;
        }

        public StaticObjectBuilder SetImageName(string imageName)
        {
            staticObject = staticObject.WithImageName(imageName);
            return this;
        }

        public StaticObjectBuilder SetDrowingPriority(int drawingPriority)
        {
            staticObject = staticObject.WithDrowingPriority(drawingPriority);
            return this;
        }

        public StaticObjectBuilder SetLocation(Point location)
        {
            staticObject = staticObject.WithLocation(location);
            return this;
        }

        public StaticObjectBuilder SetSize(Size size)
        {
            staticObject = staticObject.WithSize(size);
            return this;
        }
    }
}
