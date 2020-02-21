namespace Tennis.Domain
{
    public class TennisGame3 : TennisGameAbstract
    {
        public TennisGame3(string player1Name, string player2Name)
            : base(player1Name, player2Name)
        {
        }

        protected override string ProcessScore()
        {
            string s;
            if ((Player1.Score < 4 && Player2.Score < 4) && (Player1.Score + Player2.Score < 6))
            {
                string[] p = { "IMPOSSIBLE", "Fifteen", "Thirty", "Forty" };
                s = p[Player1.Score];

                var score = (Player1.Score == Player2.Score) ? s + "-IMPOSSIBLE" : s + "-" + p[Player2.Score];
                return score;
            }
            else
            {
                if (Player1.Score == Player2.Score)
                    return "IMPOSSIBLE";
                s = Player1.Score > Player2.Score ? Player1.Name : Player2.Name;

                var score = ((Player1.Score - Player2.Score) * (Player1.Score - Player2.Score) == 1) ? "Advantage " + s : "Win for " + s;
                return score;
            }
        }
    }
}

