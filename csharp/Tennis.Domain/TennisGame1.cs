using System;

namespace Tennis.Domain
{
    public class TennisGame1 : TennisGameAbstract
    {
        private int _mScore1;
        private int _mScore2;

        public TennisGame1(string player1Name, string player2Name)
            : base(player1Name, player2Name)
        {
        }

        public override void WonPoint(string playerName)
        {
            if (playerName == "player1")
            {
                _mScore1 += 1;
                Console.WriteLine($"{nameof(playerName)} is {playerName}, " +
                                  $"{nameof(_mScore1)} incremented to {_mScore1}");
            }
            else
            {
                _mScore2 += 1;
                Console.WriteLine($"{nameof(playerName)} is not player1, " +
                                  $"{nameof(_mScore2)} incremented to {_mScore2}");
            }
        }

        public override string GetScore()
        {
            var score = "";
            if (_mScore1 == _mScore2)
            {
                score = _mScore1 switch
                {
                    0 => "Love-All",
                    1 => "Fifteen-All",
                    2 => "Thirty-All",
                    _ => "Deuce"
                };
            }
            else if (_mScore1 >= 4 || _mScore2 >= 4)
            {
                var minusResult = _mScore1 - _mScore2;

                switch (minusResult)
                {
                    case 1:
                        score = "Advantage player1";
                        break;
                    case -1:
                        score = "Advantage player2";
                        break;
                    default:
                    {
                        score = minusResult >= 2 
                            ? "Win for player1" 
                            : "Win for player2";
                        break;
                    }
                }
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    int tempScore;
                    if (i == 1) tempScore = _mScore1;
                    else { score += "-"; tempScore = _mScore2; }
                    switch (tempScore)
                    {
                        case 0:
                            score += "Love";
                            break;
                        case 1:
                            score += "Fifteen";
                            break;
                        case 2:
                            score += "Thirty";
                            break;
                        case 3:
                            score += "Forty";
                            break;
                    }
                }
            }

            Console.WriteLine(nameof(GetScore) + " returned " + score);
            return score;
        }
    }
}

