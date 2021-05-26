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
        public bool NewGameShouldBeAfterThat = false;

        public Point SpawnLocation = new Point(0,0);
        public void SpawnMonster(int speedAdder)
        {
            if (monsterSpawnsMonitor % 57 == 0)
            {
                var random = new Random();
                var randomMonsterType = random.Next(3);
                Monster monster = new Monster(300, 3 + speedAdder, 0, 50,SpawnLocation, new Size(60, 90), MonsterType.fatMonster);
                switch (randomMonsterType) {
                    case (int)MonsterType.fatMonster: {
                        monster = new Monster(300, 3 + speedAdder, 0, 50,SpawnLocation, new Size(60, 90), MonsterType.fatMonster);
                        break;
                    }
                    case (int)MonsterType.normalMonster: {
                        monster = new Monster(150, 6 + speedAdder, 0, 35,SpawnLocation, new Size(45, 60), MonsterType.normalMonster);
                        break;
                    }
                    case (int)MonsterType.fastMonster: {
                        monster = new Monster(50, 13 + speedAdder, 0, 10,SpawnLocation, new Size(25, 45), MonsterType.fastMonster);
                        break;
                    }
                }
                Monsters.Add(monster);
            }
            monsterSpawnsMonitor = (monsterSpawnsMonitor + 1) % 57;
        }
        public void MakeActionOfMonsters(
            Control.ControlCollection Controls, GameModel game)
        {
            foreach (var monster in Monsters) {
                var collectionWasChanged = false;
                switch (monster.MonsterType) {
                    case MonsterType.fatMonster:
                        monster.MoveToHero(this, monster.Speed);
                        foreach (var firedBullet in FiredBullets)
                        {
                            if (monster.Bounds.IntersectsWith(firedBullet.Bounds))
                            {
                                if (!monster.ActInConflict(Hero, true))
                                {
                                    Controls.Remove(monster);
                                    game.Monsters.Remove(monster);
                                    collectionWasChanged = true;
                                    game.Scores += 60;
                                }
                                game.FiredBullets.Remove(firedBullet);
                                if (game.Hero.Weapon.Bullets.Contains(firedBullet))
                                    game.Hero.Weapon.Bullets.Remove(firedBullet);
                                break;
                            }
                        }

                        if (monster.Bounds.IntersectsWith(Hero.Bounds))
                        {
                            if (!monster.ActInConflict(Hero, false))
                            {
                                Controls.Remove(Hero);
                                Hero = null;
                                collectionWasChanged = true;
                            }
                        }
                        break;
                    
                    case MonsterType.normalMonster: 
                        monster.MoveToHero(this, monster.Speed);
                        foreach (var firedBullet in FiredBullets)
                        {
                            if (monster.Bounds.IntersectsWith(firedBullet.Bounds))
                            {
                                if (!monster.ActInConflict(Hero, true))
                                {
                                    Controls.Remove(monster);
                                    game.Monsters.Remove(monster);
                                    collectionWasChanged = true;
                                    game.Scores += 40;
                                }
                                game.FiredBullets.Remove(firedBullet);
                                if (game.Hero.Weapon.Bullets.Contains(firedBullet))
                                    game.Hero.Weapon.Bullets.Remove(firedBullet);
                                break;
                            }
                        }
                        
                        if (monster.Bounds.IntersectsWith(Hero.Bounds))
                        {
                            if(!monster.ActInConflict(Hero, false))
                            {
                                Controls.Remove(Hero);
                                Hero = null;
                                collectionWasChanged = true;
                            }
                        }
                        break;
                    
                    case MonsterType.fastMonster:
                        monster.MoveToHero(this, monster.Speed);
                        foreach (var firedBullet in FiredBullets)
                        {
                            if (monster.Bounds.IntersectsWith(firedBullet.Bounds))
                            {
                                if (!monster.ActInConflict(Hero, true))
                                {
                                    Controls.Remove(monster);
                                    game.Monsters.Remove(monster);
                                    collectionWasChanged = true;
                                    game.Scores += 25;
                                }
                                game.FiredBullets.Remove(firedBullet);
                                if (game.Hero.Weapon.Bullets.Contains(firedBullet))
                                    game.Hero.Weapon.Bullets.Remove(firedBullet);
                                break;
                            }
                        }
                        
                        if (monster.Bounds.IntersectsWith(Hero.Bounds))
                        {
                            if(!monster.ActInConflict(Hero, false))
                            {
                                Controls.Remove(Hero);
                                Hero = null;
                                collectionWasChanged = true;
                            }
                        }
                        break;
                }
                foreach (var platform in EnvironmentObjects.Where(x => x is Platform)) {
                    if (monster.Bounds.IntersectsWith(platform.Bounds))
                        monster.Top = platform.Top - monster.Height + 1;
                    else {
                        monster.Top += 7;
                    }
                }
                if (collectionWasChanged) break;
            }
        }
    }
}
