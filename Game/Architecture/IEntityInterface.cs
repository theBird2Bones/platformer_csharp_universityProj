using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game
{
    interface IEntityInterface
    {
        public string ImageName { get; }
        public int DrowingPriority { get; set; }
        public Vector Location { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public void OnConflict(Entity entity);
    }
}
