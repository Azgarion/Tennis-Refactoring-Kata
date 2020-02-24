using System;
using ApprovalTests.Reporters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Tennis
{
    [UseReporter(typeof(DiffReporter))]
    [TestFixture( 0,  0, "Love-All")]
    [TestFixture( 1,  1, "Fifteen-All")]
    [TestFixture( 2,  2, "Thirty-All")]
    [TestFixture( 3,  3, "Deuce")]
    [TestFixture( 4,  4, "Deuce")]
    [TestFixture( 1,  0, "Fifteen-Love")]
    [TestFixture( 0,  1, "Love-Fifteen")]
    [TestFixture( 2,  0, "Thirty-Love")]
    [TestFixture( 0,  2, "Love-Thirty")]
    [TestFixture( 3,  0, "Forty-Love")]
    [TestFixture( 0,  3, "Love-Forty")]
    [TestFixture( 4,  0, "Win for player1")]
    [TestFixture( 0,  4, "Win for player2")]
    [TestFixture( 2,  1, "Thirty-Fifteen")]
    [TestFixture( 1,  2, "Fifteen-Thirty")]
    [TestFixture( 3,  1, "Forty-Fifteen")]
    [TestFixture( 1,  3, "Fifteen-Forty")]
    [TestFixture( 4,  1, "Win for player1")]
    [TestFixture( 1,  4, "Win for player2")]
    [TestFixture( 3,  2, "Forty-Thirty")]
    [TestFixture( 2,  3, "Thirty-Forty")]
    [TestFixture( 4,  2, "Win for player1")]
    [TestFixture( 2,  4, "Win for player2")]
    [TestFixture( 4,  3, "Advantage player1")]
    [TestFixture( 3,  4, "Advantage player2")]
    [TestFixture( 5,  4, "Advantage player1")]
    [TestFixture( 4,  5, "Advantage player2")]
    [TestFixture(15, 14, "Advantage player1")]
    [TestFixture(14, 15, "Advantage player2")]
    [TestFixture( 6,  4, "Win for player1")]
    [TestFixture( 4,  6, "Win for player2")]
    [TestFixture(16, 14, "Win for player1")]
    [TestFixture(14, 16, "Win for player2")]
    public class TennisTests
    {
        private readonly int _player1Score;
        private readonly int _player2Score;
        private readonly string _expectedScore;

        private string CurrentTestName => $"{_player1Score}-{_player2Score} " + _expectedScore;

        public TennisTests(int player1Score, int player2Score, string expectedScore)
        {
            this._player1Score = player1Score;
            this._player2Score = player2Score;
            this._expectedScore = expectedScore;
        }

        
        [Test]
        public void CheckTennisGame1()
        {
            using (new GoldenMaster(CurrentTestName))
            {
                var game = new TennisGame1("player1", "player2");
                CheckAllScores(game);
            }
        }

        [Test]
        public void CheckTennisGame2()
        {
            using (new GoldenMaster(CurrentTestName))
            {
                var game = new TennisGame2("player1", "player2");
                CheckAllScores(game);
            }
        }

        [Test]
        public void CheckTennisGame3()
        {
            using (new GoldenMaster(CurrentTestName))
            {
                var game = new TennisGame3("player1", "player2");
                CheckAllScores(game);
            }
        }

        private void CheckAllScores(ITennisGame game)
        {
            var highestScore = Math.Max(this._player1Score, this._player2Score);
            for (var i = 0; i < highestScore; i++)
            {
                if (i < this._player1Score)
                    game.WonPoint("player1");
                if (i < this._player2Score)
                    game.WonPoint("player2");
            }
            Assert.AreEqual(this._expectedScore, game.GetScore());
        }

    }

    [UseReporter(typeof(DiffReporter))]
    [TestFixture]
    public class ExampleGameTennisTest
    {
        [Test]
        public void CheckGame1()
        {
            using (new GoldenMaster())
            {
                var game = new TennisGame1("player1", "player2");
                RealisticTennisGame(game);
            }
        }

        [Test]
        public void CheckGame2()
        {
            using (new GoldenMaster())
            {
                var game = new TennisGame2("player1", "player2");
                RealisticTennisGame(game);
            }
        }

        [Test]
        public void CheckGame3()
        {
            using (new GoldenMaster())
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

//    [TestClass]
//    public class TennisMsTest
//    {
//        [TestMethod]
//        public void Score_0_to_0_ShouldEqual_LoveAll()
//        {
//            
//        }
//        
//        [TestMethod]
//        public void Score_1_to_1_ShouldEqual_FifteenAll()
//        {
//            
//        }
//        
//        [TestMethod]
//        public void Score_2_to_2_ShouldEqual_ThirtyAll()
//        {
//            
//        }
//        
//        [TestMethod]
//        public void Score_3_to_3_ShouldEqual_Deuce()
//        {
//            
//        }
//        
//        [TestMethod]
//        public void Score_4_to_4_ShouldEqual_Deuce()
//        {
//            
//        }
//
//        [TestMethod]
//        public void Score_5_To_4_ShouldEqual_AdvantagePlayer1()
//        {
//            
//        }
//        
//        [TestMethod]
//        public void Score_4_To_5_ShouldEqual_AdvantagePlayer2()
//        {
//            
//        }
//        
//        [TestMethod]
//        public void Score__To__ShouldEqual_WinPlayer1()
//        {
//            
//        }
//        
//        
//        
//        
//        
//        
//    }

}

