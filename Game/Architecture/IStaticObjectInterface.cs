using Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    interface IStaticObjectBuilderInterface
    {
        StaticObjectBuilder SetName(string name);
        StaticObjectBuilder SetImageName(string name);
        StaticObjectBuilder SetDrowingPriority(int drawingPriority);
        StaticObjectBuilder SetLocation(Point location);
        StaticObjectBuilder SetSize(Size size);
        Entity Build();
    }
}
