using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game
{
    public class Ground : Entity
    {
        public Ground(string name, string imageName, Vector location, int width, int height)
            : base(name, imageName, location, width, height)
        {
        }
        public override void OnConflict(Entity entity)
        {
        }
    }
}
