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
        fatMonster,
        normalMonster,
        fastMonster,
        fatMonsterGoingRight,
        fatMonsterGoingLeft,
        normalMonsterGoingRight,
        normalMonsterGoingLeft,
        fastMonsterGoingRight,
        fastMonsterGoingLeft,
    }
    public class Monster : DynamicObject {
        public int Damage { get; private set; }
        public MonsterType MonsterType;
        private readonly Dictionary<MonsterType, string> _mosterType = new Dictionary<MonsterType, string>()
        {           
            {MonsterType.fatMonster, "fatMonster.png"},
            {MonsterType.fatMonsterGoingLeft, "fatMonsterLeft.png"},
            {MonsterType.fatMonsterGoingRight, "fatMonsterRight.png"},
            {MonsterType.normalMonster, "normalMonster.png"},
            {MonsterType.normalMonsterGoingLeft, "normalMonsterLeft.png"},
            {MonsterType.normalMonsterGoingRight, "normalMonsterRight.png"},
            {MonsterType.fastMonster, "fastMonster.png"},
            {MonsterType.fastMonsterGoingLeft, "fastMonsterLeft.png"},
            {MonsterType.fastMonsterGoingRight, "fastMonsterRight.png"},
        };
        public Monster(int health, int speed, int jumpHeight,int damage, Point location, Size size, MonsterType monsterType)
            : base(health, speed, jumpHeight, location, size)
        {
            Tag = "monster";
            Image = new Bitmap(PathToImages + _mosterType[monsterType]);
            MonsterType = monsterType;
            Damage = damage;
            Visible = false;
        }

        public void MoveToHero(GameModel game, int travelSpeed) {
            MonsterType monsterType = this.MonsterType;
            if (this.Left > game.Hero.Right) {
                this.Left -= travelSpeed;
                switch (this.MonsterType) {
                    case MonsterType.fatMonster:
                        monsterType = MonsterType.fatMonsterGoingLeft;
                        break;
                    case MonsterType.normalMonster:
                        monsterType = MonsterType.normalMonsterGoingLeft;
                        break;
                    case MonsterType.fastMonster:
                        monsterType = MonsterType.fastMonsterGoingLeft;
                        break;
                }
            }
            if (this.Right <= game.Hero.Left) {
                this.Left += travelSpeed;
                switch (this.MonsterType) {
                    case MonsterType.fatMonster:
                        monsterType = MonsterType.fatMonsterGoingRight;
                        break;
                    case MonsterType.normalMonster:
                        monsterType = MonsterType.normalMonsterGoingRight;
                        break;
                    case MonsterType.fastMonster:
                        monsterType = MonsterType.fastMonsterGoingRight;
                        break;
                }
            }
            Image = new Bitmap(PathToImages + _mosterType[monsterType]);
        }
    }
}
