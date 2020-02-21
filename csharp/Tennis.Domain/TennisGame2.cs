using System;

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

        public override string GetScore()
        {
            var score = "";
            if (Player1Score == Player2Score && Player1Score < 3)
            {
                if (Player1Score == 0)
                    score = "Love";
                if (Player1Score == 1)
                    score = "Fifteen";
                if (Player1Score == 2)
                    score = "Thirty";
                score += "-All";
            }
            if (Player1Score == Player2Score && Player1Score > 2)
                score = "Deuce";

            if (Player1Score > 0 && Player2Score == 0)
            {
                if (Player1Score == 1)
                    _p1Res = "Fifteen";
                if (Player1Score == 2)
                    _p1Res = "Thirty";
                if (Player1Score == 3)
                    _p1Res = "Forty";

                _p2Res = "Love";
                score = _p1Res + "-" + _p2Res;
            }
            if (Player2Score > 0 && Player1Score == 0)
            {
                if (Player2Score == 1)
                    _p2Res = "Fifteen";
                if (Player2Score == 2)
                    _p2Res = "Thirty";
                if (Player2Score == 3)
                    _p2Res = "Forty";

                _p1Res = "Love";
                score = _p1Res + "-" + _p2Res;
            }

            if (Player1Score > Player2Score && Player1Score < 4)
            {
                if (Player1Score == 2)
                    _p1Res = "Thirty";
                if (Player1Score == 3)
                    _p1Res = "Forty";
                if (Player2Score == 1)
                    _p2Res = "Fifteen";
                if (Player2Score == 2)
                    _p2Res = "Thirty";
                score = _p1Res + "-" + _p2Res;
            }
            if (Player2Score > Player1Score && Player2Score < 4)
            {
                if (Player2Score == 2)
                    _p2Res = "Thirty";
                if (Player2Score == 3)
                    _p2Res = "Forty";
                if (Player1Score == 1)
                    _p1Res = "Fifteen";
                if (Player1Score == 2)
                    _p1Res = "Thirty";
                score = _p1Res + "-" + _p2Res;
            }

            if (Player1Score > Player2Score && Player2Score >= 3)
            {
                score = "Advantage player1";
            }

            if (Player2Score > Player1Score && Player1Score >= 3)
            {
                score = "Advantage player2";
            }

            if (Player1Score >= 4 && Player2Score >= 0 && (Player1Score - Player2Score) >= 2)
            {
                score = "Win for player1";
            }
            if (Player2Score >= 4 && Player1Score >= 0 && (Player2Score - Player1Score) >= 2)
            {
                score = "Win for player2";
            }

            Console.WriteLine(nameof(GetScore) + " returned " + score);
            return score;
        }
    }
}

