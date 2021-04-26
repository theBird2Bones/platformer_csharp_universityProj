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
            Monsters = new List<PictureBox>();
        }
        public Hero Hero { get; set; }
        public List<PictureBox> EnvironmentObjects { get; set; }
        public List<PictureBox> Monsters { get; set; }
        
        public Background Background { get; set; }
        public WeaponIcon WeaponIcon { get; set; }
        public MenuButton MenuButton { get; set; }
        public BackgroundWeapon BackgroundWeapon { get; set; }
        public int Scores { get; set; }
        public bool IsOver { get; set; }
        public Size MapSize { get; }

        public void SpawnMonster()
        {
            if (monsterSpawnsMonitor % 20 == 0)
            {
                var random = new Random();
                var delta1 = random.Next() % 300;
                var delta2 = random.Next() % 300;
                MonsterType monsterType = MonsterType.firstMonster;
                if (delta1 % 3 == 1)
                    monsterType = MonsterType.secondMonster;
                if (delta1 % 3 == 2)
                    monsterType = MonsterType.thirdMonster;
                var monster = new Monster(1, 1, 0, 
                    new Point(300 + delta2, 300 + delta1), 
                    new Size(40, 40), monsterType);
                Monsters.Add(monster);
                //EnvironmentObjects.Add(monster);
            }
            if (monsterSpawnsMonitor == 20 * 100)
                monsterSpawnsMonitor = 0;
            monsterSpawnsMonitor++;
        }
        //переписать эту штуку для разных монсторв

        public void MakeActionOfMonsters()
        {
            foreach (var obj in Monsters)
            {
                if (obj is DynamicObject)
                {
                    var objAsDynamicObject = (DynamicObject)obj;
                    objAsDynamicObject.Action();
                }
            }
        }
    }
}
