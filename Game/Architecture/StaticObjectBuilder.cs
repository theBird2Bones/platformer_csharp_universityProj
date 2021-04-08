using Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public class StaticObjectBuilder : IStaticObjectBuilderInterface
    {
        public string PATH_TO_IMAGES = new DirectoryInfo(Directory.GetCurrentDirectory())
            .Parent.Parent.Parent.Parent.FullName + "\\Images\\";
        public StaticObject staticObject = new StaticObject();
        public PictureBox pictureBox = new PictureBox();
        public StaticObjectBuilder() 
        { 
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox.Visible = true;
        }
        public Entity BuildEntity()
        {
            return staticObject;
        }

        public PictureBox BuildPictureBox()
        {
            return pictureBox;
        }

        public StaticObjectBuilder SetName(string name)
        {
            staticObject = staticObject.WithName(name);
            pictureBox.Tag = name;
            return this;
        }

        public StaticObjectBuilder SetImageName(string imageName)
        {
            staticObject = staticObject.WithImageName(imageName);
            pictureBox.BackgroundImage = Image.FromFile(PATH_TO_IMAGES + imageName);
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
            pictureBox.Location = location;
            return this;
        }

        public StaticObjectBuilder SetSize(Size size)
        {
            staticObject = staticObject.WithSize(size);
            pictureBox.Size = size;
            return this;
        }
    }
}
