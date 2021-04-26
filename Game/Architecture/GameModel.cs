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
            if (monsterSpawnsMonitor % 60 == 0)
            {
                var random = new Random();
                var d = random.Next(3);
                MonsterType monsterType = MonsterType.fatMonster;
                if (d % 3 == 1)
                    monsterType = MonsterType.normalMonster;
                if (d % 3 == 2)
                    monsterType = MonsterType.fastMonster;
                var monster = new Monster(1, 1, 0, 
                    new Point(SpawnLocation.X, SpawnLocation.Y), 
                    new Size(40, 40), monsterType);
                Monsters.Add(monster);
                //EnvironmentObjects.Add(monster);
            }
            monsterSpawnsMonitor = (monsterSpawnsMonitor + 1) % 61;
        }
        //переписать эту штуку для разных монсторв

        public void MakeActionOfMonsters()
        {
            foreach (var monster in Monsters) {
                switch (monster.MonsterType) {
                    case MonsterType.fatMonster:
                        monster.MoveToHero(this, 1);
                        break;
                    case MonsterType.normalMonster: 
                        monster.MoveToHero(this, 3);
                        break;
                    case MonsterType.fastMonster:
                        monster.MoveToHero(this, 5);
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
