using System.Drawing;
using NUnit.Framework;
using System.Windows.Forms;
using System.IO;

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
            var game = new GameModel(new Size(1500, 900));
            game.Hero = new Hero(100, 6, 12,
                new Point(400, 400),
                new Size(30, 40));

            game.Hero.IsLanded = true;
            game.Hero.Action(game, key, actionWithKey,new Timer());

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
                    game.Hero.Action(game, key, actionWithKey,new Timer());
                    Assert.That(!game.Hero.IsJumping);
                    break;
                case ResultFirstTest.IsNotJumping:
                    Assert.That(!game.Hero.IsJumping);
                    break;
            }
        }

        [Test]
        public void HeroCannotGoThrowTheGround_Test()
        {

        }

        /*
        [Test]
        public void HeroCannotGoAwayFromTheSreen_Test()
        {

        }
        */
    }
}
