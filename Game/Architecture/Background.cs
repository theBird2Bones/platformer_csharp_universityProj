using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace Game {
    public class Background: StaticObject {
        public Timer FrameRateTimer = new Timer();
        private int _currentFrame = 0;
        private Dictionary<int,string> _frames = new Dictionary<int, string> {
            {0,"background.png"},
            {1,"background.png"},
            {2,"background.png"},
            {3,"background.png"},
            {4,"background.png"},
            {5,"background.png"},
            {6,"background.png"},
            {7,"background.png"},
            {8,"background.png"},
        };
        public Background(Size size, Point location)
        :base( size, location){
            SizeMode = PictureBoxSizeMode.StretchImage;
            Tag = "background";
            Image = new Bitmap(PathToImages + "background.png");
        }

        public void ChangeFrame() {
            _currentFrame = (_currentFrame + 1) % (_frames.Count - 1);
            Image = new Bitmap(PathToImages + _frames[_currentFrame]);
        }
    }
}