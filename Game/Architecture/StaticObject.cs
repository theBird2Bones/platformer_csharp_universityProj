using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game
{
    class StaticObject : IStaticObjectInterface
    {
        public StaticObject(string imageName, int drowingPriority, Vector location,
            int width, int height)
        {
            ImageName = imageName;
            DrowingPriority = drowingPriority;
            Location = location;
            Width = width;
            Height = height;
        }
        public string ImageName { get; }
        public int DrowingPriority { get; set; }
        public Vector Location { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public void Action()
        {
            throw new NotImplementedException();
        }

        public void OnConflict(Entity entity)
        {
        }
    }
}
