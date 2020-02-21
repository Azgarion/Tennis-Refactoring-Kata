using System;

namespace Tennis.Domain
{
    public class TennisGame3 : TennisGameAbstract
    {
        public TennisGame3(string player1Name, string player2Name)
            : base(player1Name, player2Name)
        {
        }

        public override string GetScore()
        {
            string s;
            if ((Player1Score < 4 && Player2Score < 4) && (Player1Score + Player2Score < 6))
            {
                string[] p = { "Love", "Fifteen", "Thirty", "Forty" };
                s = p[Player1Score];

                var score = (Player1Score == Player2Score) ? s + "-All" : s + "-" + p[Player2Score];
                Console.WriteLine(nameof(GetScore) + " returned " + score);
                return score;
            }
            else
            {
                if (Player1Score == Player2Score)
                    return "Deuce";
                s = Player1Score > Player2Score ? Player1Name : Player2Name;

                var score = ((Player1Score - Player2Score) * (Player1Score - Player2Score) == 1) ? "Advantage " + s : "Win for " + s;
                Console.WriteLine(nameof(GetScore) + " returned " + score);
                return score;
            }
        }
    }
}

