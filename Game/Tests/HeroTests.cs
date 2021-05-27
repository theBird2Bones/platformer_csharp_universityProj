using System.Drawing;
using NUnit.Framework;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace Game
{
    [TestFixture]
    class HeroTests
    {
        public enum ResultFirstTest
        {
            IsGoingLeft,
            IsNotGoingLeft,
            IsGoingRight,
            IsNotGoingRight,
            IsJumping,
            IsNotJumping
        }

        [TestCase(Keys.Left, ActionWithKey.Pressed, ResultFirstTest.IsGoingLeft)]
        [TestCase(Keys.Left, ActionWithKey.Unpressed, ResultFirstTest.IsNotGoingLeft)]
        [TestCase(Keys.Right, ActionWithKey.Pressed, ResultFirstTest.IsGoingRight)]
        [TestCase(Keys.Right, ActionWithKey.Unpressed, ResultFirstTest.IsNotGoingRight)]
        [TestCase(Keys.Space, ActionWithKey.Pressed, ResultFirstTest.IsJumping)]
        [TestCase(Keys.Space, ActionWithKey.Unpressed, ResultFirstTest.IsNotJumping)]
        public void HeroReactCorrectlyOnKeys_Test(
            Keys key, ActionWithKey actionWithKey, ResultFirstTest correctResult)
        {
            var game = MakeGameWithHero();
            game.Hero.IsLanded = true;
            var timer = new Timer();

            timer.Start();
            game.Hero.Action(game, key, actionWithKey, timer);
            timer.Stop();

            switch (correctResult)
            {
                case ResultFirstTest.IsGoingLeft:
                    Assert.That(game.Hero.IsGoingLeft);
                    break;
                case ResultFirstTest.IsNotGoingLeft:
                    Assert.That(!game.Hero.IsGoingLeft);
                    break;
                case ResultFirstTest.IsGoingRight:
                    Assert.That(game.Hero.IsGoingRight);
                    break;
                case ResultFirstTest.IsNotGoingRight:
                    Assert.That(!game.Hero.IsGoingRight);
                    break;
                case ResultFirstTest.IsJumping:
                    Assert.That(game.Hero.IsJumping);
                    game.Hero.IsJumping = false;
                    game.Hero.Action(game, key, actionWithKey, new Timer());
                    Assert.That(!game.Hero.IsJumping);
                    break;
                case ResultFirstTest.IsNotJumping:
                    Assert.That(!game.Hero.IsJumping);
                    break;
            }
        }

        [TestCase(WeaponType.stone)]
        [TestCase(WeaponType.kunai)]
        [TestCase(WeaponType.shuriken)]
        [TestCase(WeaponType.bow)]
        [TestCase(WeaponType.platformMaker)]
        public void OrdinaryShoot_Test(WeaponType weaponType)
        {
            var game = MakeGameWithHero();
            game.Hero.Weapon = new Weapon(
                new Size(26, 26), new Point(0, 0),
                    weaponType, 10, 0.4, 1.5, 30, 5,
                    new System.Windows.Vector(), game.Hero);

            game.Hero.Shoot(game);

            Assert.That(game.FiredBullets.Count != 0);
            Assert.That(game.FiredBullets.First().WeaponType == weaponType);
        }

        [TestCase(WeaponType.stone)]
        [TestCase(WeaponType.kunai)]
        [TestCase(WeaponType.shuriken)]
        [TestCase(WeaponType.bow)]
        [TestCase(WeaponType.platformMaker)]
        public void Shoot_WithoutBullets_Test(WeaponType weaponType)
        {
            var game = MakeGameWithHero();
            game.Hero.Weapon = new Weapon(
                new Size(26, 26), new Point(0, 0),
                    weaponType, 0, 0.4, 1.5, 30, 5,
                    new System.Windows.Vector(), game.Hero);
            game.WeaponIcon = new WeaponIcons(
                new Size(5, 5),
                game.Hero.Weapon.Location,
                game.Hero.Weapon.WeaponType);

            game.Hero.Shoot(game);

            Assert.That(game.FiredBullets.Count == 0);
            Assert.That(game.Hero.Weapon.WeaponType == WeaponType.stone);
        }

        public void SpecialBulletsAction_Test()
        {
            var game = MakeGameWithHero();
            game.Hero.Weapon = new Weapon(
                new Size(26, 26), new Point(0, 0),
                    WeaponType.platformMaker, 2, 0.4, 1.5, 30, 5,
                    new System.Windows.Vector(), game.Hero);

            game.Hero.Shoot(game);
            Assert.That(game.Hero.SpecialBullets.Count != 0);
            game.Hero.MakeActionWithBullet(game);

            Assert.That(game.TemporalEnvironmentObjects.Count != 0);
            Assert.That(game.EnvironmentObjects.Count != 0);
            Assert.That(game.FiredBullets.Count == 0);
            Assert.That(game.Hero.SpecialBullets.Count == 0);
        }

        public void MonstersHitHero_Test()
        {
            var game = MakeGameWithHero();
            var monster = new Monster(50, 10, 150, 10,
                game.Hero.Location, new Size(25, 45), MonsterType.fastMonster);
            var prevHealth = game.Hero.Health;

            monster.ActInConflict(game.Hero, false);

            Assert.That(prevHealth - game.Hero.Health == 10);
        }

        public void BulletsHitMonsters_Test()
        {
            var game = MakeGameWithHero();
            var monster = new Monster(50, 10, 150, 10,
                game.Hero.Location, new Size(25, 45), MonsterType.fatMonster);
            var prevHealth = monster.Health;

            monster.ActInConflict(game.Hero, true);

            Assert.That(prevHealth - monster.Health == 30);
        }

        public void MonstersDieWithNotPositiveHealth_Test()
        {
            var game = MakeGameWithHero();
            var monster = new Monster(1, 10, 150, 10,
                game.Hero.Location, new Size(25, 45), MonsterType.fatMonster);

            var monsterIsDead = !monster.ActInConflict(game.Hero, true);

            Assert.That(monsterIsDead);
        }

        public GameModel MakeGameWithHero()
        {
            var game = new GameModel(new Size(1500, 900));
            game.Hero = new Hero(100, 6, 12,
                new Point(400, 400),
                new Size(30, 40));
            return game;
        }
    }
}
