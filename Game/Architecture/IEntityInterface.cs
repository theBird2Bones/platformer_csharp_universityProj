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
        string ImageName { get; }
        int DrowingPriority { get; set; }
        Vector Location { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        void OnConflict(Entity entity);
    }
}
