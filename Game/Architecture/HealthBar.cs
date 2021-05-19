using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Game {
    public class HealthBar : StaticObject {
        public int MaxValue;
        public HealthBar(Hero hero, Point location) {
            Location = location;
            BackColor = Color.Maroon;
            MaxValue = hero.Health;
            Visible = false;
            Size = new Size(150, 35);
        }
    }
}