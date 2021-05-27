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
        boss,
    }
    public class Monster : DynamicObject {
        private int patienceRight;
        private int patienceLeft;
        private bool underPlatform;
        private int timer;
        private int currentJumpHeight;
        public bool IsLanded { get; set; }
        public int Damage { get; private set; }
        public MonsterType MonsterType;
        private readonly Dictionary<MonsterType, string> _mosterType = new Dictionary<MonsterType, string>() {
            {MonsterType.fatMonster, "fatMonster.png"},
            {MonsterType.normalMonster, "normalMonster.png"},
            {MonsterType.fastMonster, "fastMonster.png"},
            {MonsterType.boss, "KostyaPixelRight.png"}
        };
        private readonly Dictionary<MonsterType, string> sightDirectionRight = new Dictionary<MonsterType, string>() {
            {MonsterType.fatMonster, "fatMonsterRight.png"},
            {MonsterType.normalMonster, "normalMonsterRight.png"},
            {MonsterType.fastMonster, "fastMonsterRight.png"},
            {MonsterType.boss, "KostyaPixelRight.png"}
        };
        private readonly Dictionary<MonsterType, string> sightDirectionLeft = new Dictionary<MonsterType, string>() {
            {MonsterType.fatMonster, "fatMonsterLeft.png"},
            {MonsterType.normalMonster, "normalMonsterLeft.png"},
            {MonsterType.fastMonster, "fastMonsterLeft.png"},
            {MonsterType.boss, "KostyaPixelLeft.png"}
        };
        public Monster(int health, int speed, int jumpHeight,int damage, Point location, Size size, MonsterType monsterType)
            : base(health, speed, jumpHeight, location, size)
        {
            Tag = "monster";
            Image = new Bitmap(PathToImages + _mosterType[monsterType]);
            MonsterType = monsterType;
            Damage = damage;
            Visible = false;
            IsLanded = false;
        }

        public void MoveToHero(GameModel game, int travelSpeed) {
            this.IsLanded = false;
            timer++;
            if (this.MonsterType == MonsterType.boss)
            {
                if (this.Left >= game.Hero.Right)
                    this.Left -= travelSpeed;
                if (this.Right <= game.Hero.Left)
                    this.Left += travelSpeed;
                if (this.Top >= game.Hero.Top)
                    this.Top -= travelSpeed;
                if (this.Bottom <= game.Hero.Bottom)
                    this.Top += travelSpeed;
                return;
            }
            if (Right < game.Hero.Right)
                Image = new Bitmap(PathToImages + sightDirectionRight[MonsterType]);
            else {
                Image = new Bitmap(PathToImages + sightDirectionLeft[MonsterType]);
            }
            foreach (Control obj in game.EnvironmentObjects.Where(x => x is Platform))
            {
                if (obj is Platform && this.Bounds.IntersectsWith(obj.Bounds))
                {
                    if (this.Bottom <= obj.Top + 20
                        && (this.Left > obj.Left || this.Right < obj.Right))
                    {
                        this.Top = obj.Top - this.Height +1;
                        this.IsLanded = true;
                        this.currentJumpHeight = 0;
                    }
                    break;
                }
                else if (!this.IsLanded && currentJumpHeight == 0)
                {
                    this.Top += 4;
                }
            }
            if (!underPlatform)
            {
                if (this.Left >= game.Hero.Right)
                    this.Left -= travelSpeed;
                if (this.Right <= game.Hero.Left)
                    this.Left += travelSpeed;
            }
            if (!IsLanded && currentJumpHeight != 0 
                && currentJumpHeight < JumpHeight)
            {
                this.Top -= this.JumpHeight/4;
                this.currentJumpHeight += this.JumpHeight / 4;
                if (currentJumpHeight >= JumpHeight)
                    currentJumpHeight = 0;
            }
            if (this.Bottom >= game.Hero.Bottom + 100 && this.IsLanded && timer > 50)
            {
                foreach (Control obj in game.EnvironmentObjects.Where(x => x is Platform))
                {
                    if (obj.Top <= this.Bottom-2 
                        && this.Right >= obj.Left && this.Left <= obj.Right)
                    {
                        underPlatform = true;
                        if (Math.Abs(obj.Right - this.Left - patienceRight) < Math.Abs(obj.Left - this.Right - patienceLeft))
                        {
                            this.Left += travelSpeed;
                        }
                        else
                        {
                            this.Left -= travelSpeed;
                        }
                        if (this.Right < obj.Left || this.Left > obj.Right)
                        {
                            if (this.Right < obj.Left)
                            {
                                patienceLeft += 50;
                                patienceRight = 0;
                            }
                            else
                            {
                                patienceRight += 50;
                                patienceLeft = 0;
                            }
                            underPlatform = false;
                            this.Top -= this.JumpHeight/2;
                            this.currentJumpHeight += this.JumpHeight / 2;
                            this.IsLanded = false;
                            timer = 0;
                        }
                        break;
                    }
                }
            }
        }
        
        public bool ActInConflict(Hero hero, bool conflictObject)
        {
            if (conflictObject)
            {
                this.Health -= hero.Weapon.Damage;
                return this.Health > 0;
            }
            
            hero.Health -= this.Damage;
            if (this.MonsterType == MonsterType.fastMonster)
            {
                this.Health -= 25;
            }
            if (hero.Health > 0)
            {
                var shift = 50;
                if (hero.IsLookingRight) shift = -50;
                hero.Location = new Point(hero.Location.X + shift, hero.Location.Y - 30);
            }
            return hero.Health > 0;
        }
    }
}
