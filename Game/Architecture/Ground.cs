using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game
{
    public class Ground : Entity
    {
        public Ground(string name, string imageName, int drowingPriority, Point location, Size size)
            : base(name, imageName, drowingPriority, location, size)
        {
        }
        public override void OnConflict(Entity entity)
        {
        }
    }
}
