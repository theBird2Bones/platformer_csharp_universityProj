using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public class GameModel
    {
        private int monsterSpawnsMonitor;
        public GameModel(Size mapSize, int scores = 0)
        {
            Scores = scores;
            IsOver = false;
            MapSize = mapSize;
            EnvironmentObjects = new List<PictureBox>();
            Monsters = new List<Monster>();
        }
        public Hero Hero { get; set; }
        public List<PictureBox> EnvironmentObjects { get; set; }
        public List<Monster> Monsters { get; set; }
        public List<Bullet> FiredBullets { get; set; } = new List<Bullet>();
        public Background Background { get; set; }
        public WeaponIcons WeaponIcon { get; set; }
        public BackgroundWeapon BackgroundWeapon { get; set; }
        public MenuButton MenuButton { get; set; }
        public int Scores { get; set; }
        public bool IsOver { get; set; }
        public Size MapSize { get; }

        public Point SpawnLocation = new Point(0,0);
        public void SpawnMonster()
        {
            if (monsterSpawnsMonitor % 100 == 0)
            {
                var random = new Random();
                var randomMonsterType = random.Next(3);
                Monster monster = new Monster(300, 1, 0, 0,SpawnLocation, new Size(40, 60), MonsterType.fatMonster);
                switch (randomMonsterType) {
                    case (int)MonsterType.fatMonster: {
                        monster = new Monster(300, 1, 0, 50,SpawnLocation, new Size(40, 60), MonsterType.fatMonster);
                        break;
                    }
                    case (int)MonsterType.normalMonster: {
                        monster = new Monster(150, 3, 0, 35,SpawnLocation, new Size(30, 40), MonsterType.normalMonster);
                        break;
                    }
                    case (int)MonsterType.fastMonster: {
                        monster = new Monster(50, 5, 0, 15,SpawnLocation, new Size(25, 30), MonsterType.fastMonster);
                        break;
                    }
                }
                Monsters.Add(monster);
            }
            monsterSpawnsMonitor = (monsterSpawnsMonitor + 1) % 101;
        }
        public void MakeActionOfMonsters()
        {
            foreach (var monster in Monsters) {
                switch (monster.MonsterType) {
                    case MonsterType.fatMonster:
                        monster.MoveToHero(this, 1);

                        /*foreach (var firedBullet in FiredBullets)
                        {
                            if (monster.Bounds.IntersectsWith(firedBullet.Bounds))
                            {
                                if (!monster.ActInConflict(Hero, true)
                                //прописать затирание монстра
                            }
                        }

                        if (monster.Bounds.IntersectsWith(Hero.Bounds))
                        {
                            if(!monster.ActInConflict(Hero, false))
                                //прописать затирание героя
                        }*/
                        break;
                    
                    case MonsterType.normalMonster: 
                        monster.MoveToHero(this, 3);
                        /*foreach (var firedBullet in FiredBullets)
                        {
                            if (monster.Bounds.IntersectsWith(firedBullet.Bounds))
                            {
                                if (!monster.ActInConflict(Hero, true)
                                //прописать затирание монстра
                            }
                        }
                        
                        if (monster.Bounds.IntersectsWith(Hero.Bounds))
                        {
                            if(!monster.ActInConflict(Hero, false))
                                //прописать затирание героя
                        }*/
                        break;
                    
                    case MonsterType.fastMonster:
                        monster.MoveToHero(this, 5);
                        /*foreach (var firedBullet in FiredBullets)
                        {
                            if (monster.Bounds.IntersectsWith(firedBullet.Bounds))
                            {
                                if (!monster.ActInConflict(Hero, true)
                                //прописать затирание монстра
                            }
                        }
                        
                        if (monster.Bounds.IntersectsWith(Hero.Bounds))
                        {
                            if(!monster.ActInConflict(Hero, false))
                                //прописать затирание героя
                        }*/
                        break;
                }
                foreach (var platform in EnvironmentObjects.Where(x => x is Platform)) {
                    if (monster.Bounds.IntersectsWith(platform.Bounds))
                        monster.Top = platform.Top - monster.Height + 1;
                    else {
                        monster.Top += 7;
                    }
                }
            }
        }
    }
}
