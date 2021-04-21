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
    public enum MonsterType {
        firstMonster,
        secondMonster,
        thirdMonster,
    }
    public class Monster : DynamicObject
    {
        private readonly Dictionary<MonsterType, string> _mosterType = new Dictionary<MonsterType, string>()
        {
            {MonsterType.firstMonster, "firstMonster.png"},
            {MonsterType.secondMonster, "secondMonster.png"},
            {MonsterType.thirdMonster, "thirdMonster.png"}
        };
        public Monster(int health, int speed, int jumpHeight, Point location, Size size, MonsterType monsterType)
            : base(health, speed, jumpHeight, location, size)
        {
            Tag = "monster";
            Image = new Bitmap(PathToImages + _mosterType[monsterType]);
        }
    }
}
