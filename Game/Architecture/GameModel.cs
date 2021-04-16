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
        private int monsterSpownsMonitor;
        public GameModel(Size mapSize, int scores = 0)
        {
            Scores = scores;
            IsOver = false;
            MapSize = mapSize;
            EnvironmentObjects = new List<PictureBox>();
        }
        public Hero Hero { get; set; }
        public List<PictureBox> EnvironmentObjects { get; set; }
        public Background Background { get; set; }
        public int Scores { get; set; }
        public bool IsOver { get; set; }
        public Size MapSize { get; }

        public void SpawnMonster()
        {
            if (monsterSpownsMonitor % 20 == 0)
            {
                var random = new Random();
                var delta1 = random.Next() % 300;
                var delta2 = random.Next() % 300;
                var monster = new Monster(1, 1, 0, new Point(300 + delta2, 300 + delta1), new Size(40, 40));
                EnvironmentObjects.Add(monster);
            }
            if (monsterSpownsMonitor == 20 * 100)
                monsterSpownsMonitor = 0;
            monsterSpownsMonitor++;
        }

        public void MakeActionOfDynamicObjects()
        {
            foreach (var obj in EnvironmentObjects)
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
