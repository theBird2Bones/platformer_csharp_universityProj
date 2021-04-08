using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game
{
    interface IEntityInterface
    {
        string ImageName { get; }
        int DrawingPriority { get; set; }
        Point Location { get; set; }
        Size Size { get; set; }
        void OnConflict(Entity entity);
    }
}
