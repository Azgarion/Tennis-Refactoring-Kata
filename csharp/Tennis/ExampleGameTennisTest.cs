using ApprovalTests.Reporters;
using NUnit.Framework;
using Tennis.Domain;

namespace Tennis.Tests
{
    [UseReporter(typeof(DiffReporter))]
    [TestFixture]
    public class ExampleGameTennisTest 
    {
        [Test]
        public void CheckGame1()
        {
            using (new GoldenMasterTest())
            {
                var game = new TennisGame1("player1", "player2");
                RealisticTennisGame(game);
            }
        }

        [Test]
        public void CheckGame2()
        {
            using (new GoldenMasterTest())
            {
                var game = new TennisGame2("player1", "player2");
                RealisticTennisGame(game);
            }
        }

        [Test]
        public void CheckGame3()
        {
            using (new GoldenMasterTest())
            {
                var game = new TennisGame3("player1", "player2");
                RealisticTennisGame(game);
            }
        }

        private void RealisticTennisGame(ITennisGame game)
        {
            string[] points = { "player1", "player1", "player2", "player2", "player1", "player1" };
            string[] expectedScores = { "Fifteen-Love", "Thirty-Love", "Thirty-Fifteen", "Thirty-All", "Forty-Thirty", "Win for player1" };
            for (var i = 0; i < 6; i++)
            {
                game.WonPoint(points[i]);
                Assert.AreEqual(expectedScores[i], game.GetScore());
            }
        }
    }
}
