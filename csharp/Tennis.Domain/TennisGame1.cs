namespace Tennis.Domain
{
    public class TennisGame1 : TennisGameAbstract
    {
        public TennisGame1(string player1Name, string player2Name)
            : base(player1Name, player2Name)
        {
        }

        protected override string ProcessScore()
        {
            var score = "";
            
            if (Player1.Score >= 4 || Player2.Score >= 4)
            {
                var minusResult = Player1.Score - Player2.Score;

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
                    if (i == 1) tempScore = Player1.Score;
                    else { score += "-"; tempScore = Player2.Score; }
                    switch (tempScore)
                    {
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

            return score;
        }
    }
}

