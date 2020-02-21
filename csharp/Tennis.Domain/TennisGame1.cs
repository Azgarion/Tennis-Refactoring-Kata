using System;

namespace Tennis.Domain
{
    public class TennisGame1 : TennisGameAbstract
    {
        public TennisGame1(string player1Name, string player2Name)
            : base(player1Name, player2Name)
        {
        }

        public override string GetScore()
        {
            var score = "";
            if (Player1Score == Player2Score)
            {
                score = Player1Score switch
                {
                    0 => "Love-All",
                    1 => "Fifteen-All",
                    2 => "Thirty-All",
                    _ => "Deuce"
                };
            }
            else if (Player1Score >= 4 || Player2Score >= 4)
            {
                var minusResult = Player1Score - Player2Score;

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
                    if (i == 1) tempScore = Player1Score;
                    else { score += "-"; tempScore = Player2Score; }
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

