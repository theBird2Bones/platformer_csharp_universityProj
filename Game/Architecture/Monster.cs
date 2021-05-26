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
    }
    public class Monster : DynamicObject {
        public int Damage { get; private set; }
        public MonsterType MonsterType;
        private readonly Dictionary<MonsterType, string> _mosterType = new Dictionary<MonsterType, string>() {
            {MonsterType.fatMonster, "fatMonster.png"},
            {MonsterType.normalMonster, "normalMonster.png"},
            {MonsterType.fastMonster, "fastMonster.png"}
        };
        private Timer punchTimer = new Timer();
        private int frame = 0;
        private Dictionary<int,string> frames = new Dictionary<int, string> {
            {0,"monsterPunch1.png"},
            {1,"monsterPunch2.png"},
            {2,"monsterPunch3.png"},
            {3,"monsterPunch4.png"},
        };
        public Monster(int health, int speed, int jumpHeight,int damage, Point location, Size size, MonsterType monsterType)
            : base(health, speed, jumpHeight, location, size)
        {
            Tag = "monster";
            Image = new Bitmap(PathToImages + _mosterType[monsterType]);
            MonsterType = monsterType;
            Damage = damage;
            Visible = false;
            punchTimer.Interval = 30;
        }

        public void MoveToHero(GameModel game, int travelSpeed) {
            if (this.Left >= game.Hero.Right) 
                this.Left -= travelSpeed;
            if (this.Right <= game.Hero.Left)
                this.Left += travelSpeed;
        }
        
        public bool ActInConflict(Hero hero, bool conflictObject)
        {
            if (conflictObject)
            {
                this.Health -= hero.Weapon.Damage;
                return this.Health > 0;
            }
            
            hero.Health -= this.Damage;
            if (hero.Health > 0)
            {
                var shift = 50;
                if (hero.IsLookingRight) shift = -50;
                hero.Location = new Point(hero.Location.X + shift, hero.Location.Y - 30);
            }
            return hero.Health > 0;
        }

        public void DrawPunchAnimation() {
            punchTimer.Start();
            punchTimer.Tick += (s, a) => {
                if(frame >= 3)
                    punchTimer.Stop();
                else {
                    /*Paint += (sender, args) => {
                        var g = args.Graphics;
                        g.DrawImage(new Bitmap(new Bitmap(PathToImages + frames[frame]), 
                            new Size(35, 35)), Location);
                    };
                    frame = (frame + 1) % 4;*/
                }
                
            };
        }
    }
}
