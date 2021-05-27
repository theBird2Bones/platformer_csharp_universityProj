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
            TemporalEnvironmentObjects = new List<PictureBox>();
        }
        public Hero Hero { get; set; }
        public List<PictureBox> TemporalEnvironmentObjects { get; set; }
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
        public bool NewGameShouldBeAfterThat = false;
        public int timer;

        public Point SpawnLocation = new Point(0,0);
        public Point SpawnLocation2 = new Point(0, 0);

        public void CheckTemporalEnvironmentObjects(
            Control.ControlCollection controls)
        {
            timer++;
            if (timer%10 == 0)
            {
                foreach(var obj in TemporalEnvironmentObjects)
                {
                    if (obj.Size.Width > 10)
                    {
                        obj.Size = new Size(obj.Size.Width - 10, obj.Size.Height);
                        obj.Left += 5;
                        timer = 0;
                    }
                    else
                    {
                        TemporalEnvironmentObjects.Remove(obj);
                        controls.Remove(obj);
                        EnvironmentObjects.Remove(obj);
                        timer--;
                        break;
                    }
                }
            }
        }
        public void SpawnMonster(int speedAdder)
        {
            if (monsterSpawnsMonitor > 1000)
            {
                var alreadyExist = false;
                foreach (var monster in Monsters)
                {
                    if (monster.MonsterType == MonsterType.boss)
                    {
                        alreadyExist = true;
                        break;
                    }
                }
                if (!alreadyExist)
                {
                    var boss = new Monster(3000, 3, 200, 100,
                    new Point(SpawnLocation.X, SpawnLocation.Y - 270),
                    new Size(180, 270), MonsterType.boss);
                    Monsters.Add(boss);
                }
                monsterSpawnsMonitor = 0;
            }
            else if (monsterSpawnsMonitor % 57 == 0)
            {
                var random = new Random();
                var randomMonsterType = random.Next(3);
                var spawnLocation = new Point(0, 0);
                if (random.Next(10) % 2 == 0)
                    spawnLocation = SpawnLocation;
                else
                    spawnLocation = SpawnLocation2;
                Monster monster = new Monster(300, 3 + speedAdder, 0, 50, spawnLocation, new Size(60, 90), MonsterType.fatMonster);
                switch (randomMonsterType) {
                    case (int)MonsterType.fatMonster: {
                        monster = new Monster(300, 3 + speedAdder, 40, 50, new Point(spawnLocation.X, spawnLocation.Y-90), new Size(60, 90), MonsterType.fatMonster);
                        break;
                    }
                    case (int)MonsterType.normalMonster: {
                        monster = new Monster(150, 6 + speedAdder, 80, 35, new Point(spawnLocation.X, spawnLocation.Y - 60), new Size(45, 60), MonsterType.normalMonster);
                        break;
                    }
                    case (int)MonsterType.fastMonster: {
                        monster = new Monster(50, 10 + speedAdder, 150, 10, new Point(spawnLocation.X, spawnLocation.Y - 45), new Size(25, 45), MonsterType.fastMonster);
                        break;
                    }
                }
                Monsters.Add(monster);
            }
            monsterSpawnsMonitor++;
        }

        public void MakeActionOfMonsters(
            Control.ControlCollection Controls, GameModel game)
        {
            foreach (var monster in Monsters) {
                monster.MoveToHero(this, monster.Speed);
                var scoresToAdd = 0;
                switch (monster.MonsterType) {
                    case MonsterType.fatMonster:
                        scoresToAdd = 60;
                        break;
                    
                    case MonsterType.normalMonster:
                        scoresToAdd = 40;
                        break;
                    
                    case MonsterType.fastMonster:
                        scoresToAdd = 25;
                        break;
                }
                var collectionWasChanged =
                            ProcessMonstersAndBulletsConflict(
                                Controls, game, monster, scoresToAdd);

                if (!game.IsOver)
                    collectionWasChanged =
                        ProcessMonsterIntersectsWithHero(
                            Controls, monster, game, collectionWasChanged);

                if (collectionWasChanged) break;
            }
        }

        public bool ProcessMonstersAndBulletsConflict(
            Control.ControlCollection Controls, GameModel game,
            Monster monster, int scores)
        {
            var collectionWasChanged = false;
            foreach (var firedBullet in FiredBullets)
            {
                if (monster.Bounds.IntersectsWith(firedBullet.Bounds))
                {
                    if (!monster.ActInConflict(Hero, true))
                    {
                        Controls.Remove(monster);
                        game.Monsters.Remove(monster);
                        collectionWasChanged = true;
                        game.Scores += scores;
                        if (monster.MonsterType == MonsterType.boss)
                        {
                            game.IsOver = true;
                            var res = MessageBox.Show("Победа! Хотите полностью выйти из игры?",
                                "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (res == DialogResult.Yes)
                                Application.Exit();
                            else
                            {
                                game.NewGameShouldBeAfterThat = true;
                                Application.ExitThread();
                                Application.Restart();
                            }
                            break;
                        }
                    }
                    game.FiredBullets.Remove(firedBullet);
                    if (game.Hero.Weapon.Bullets.Contains(firedBullet))
                        game.Hero.Weapon.Bullets.Remove(firedBullet);
                    break;
                }
            }
            return collectionWasChanged;
        }

        public bool ProcessMonsterIntersectsWithHero(
            Control.ControlCollection Controls, Monster monster,
            GameModel game, bool collectionWasChanged)
        {
            if (monster.Bounds.IntersectsWith(Hero.Bounds))
            {
                if (!monster.ActInConflict(Hero, false))
                {
                    Controls.Remove(Hero);
                    Hero = null;
                    collectionWasChanged = true;
                }
            }
            if (monster.Health <= 0)
            {
                Controls.Remove(monster);
                game.Monsters.Remove(monster);
                collectionWasChanged = true;
            }
            return collectionWasChanged;
        }
    }
}
