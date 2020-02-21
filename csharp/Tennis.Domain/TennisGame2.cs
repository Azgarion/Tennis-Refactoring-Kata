namespace Tennis.Domain
{
    public class TennisGame2 : TennisGameAbstract
    {
        private string _p1Res = "";
        private string _p2Res = "";

        public TennisGame2(string player1Name, string player2Name)
            : base(player1Name, player2Name)
        {
        }

        protected override string ProcessScore()
        {
            var score = "";
            if (Player1.Score > Player2.Score && Player1.Score < 4)
            {
                if (Player1.Score == 2)
                    _p1Res = "Thirty";
                if (Player1.Score == 3)
                    _p1Res = "Forty";
                if (Player2.Score == 1)
                    _p2Res = "Fifteen";
                if (Player2.Score == 2)
                    _p2Res = "Thirty";
                score = _p1Res + "-" + _p2Res;
            }
            if (Player2.Score > Player1.Score && Player2.Score < 4)
            {
                if (Player2.Score == 2)
                    _p2Res = "Thirty";
                if (Player2.Score == 3)
                    _p2Res = "Forty";
                if (Player1.Score == 1)
                    _p1Res = "Fifteen";
                if (Player1.Score == 2)
                    _p1Res = "Thirty";
                score = _p1Res + "-" + _p2Res;
            }

            if (Player1.Score > Player2.Score && Player2.Score >= 3)
            {
                score = "Advantage player1";
            }

            if (Player2.Score > Player1.Score && Player1.Score >= 3)
            {
                score = "Advantage player2";
            }

            if (Player1.Score >= 4 && Player2.Score >= 0 && (Player1.Score - Player2.Score) >= 2)
            {
                score = "Win for player1";
            }
            if (Player2.Score >= 4 && Player1.Score >= 0 && (Player2.Score - Player1.Score) >= 2)
            {
                score = "Win for player2";
            }

            return score;
        }
    }
}

