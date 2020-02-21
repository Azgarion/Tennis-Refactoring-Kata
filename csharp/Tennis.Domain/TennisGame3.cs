using System;

namespace Tennis.Domain
{
    public class TennisGame3 : TennisGameAbstract
    {
        private int _p2;
        private int _p1;

        public TennisGame3(string player1Name, string player2Name)
            : base(player1Name, player2Name)
        {
        }

        public override string GetScore()
        {
            string s;
            if ((_p1 < 4 && _p2 < 4) && (_p1 + _p2 < 6))
            {
                string[] p = { "Love", "Fifteen", "Thirty", "Forty" };
                s = p[_p1];

                var score = (_p1 == _p2) ? s + "-All" : s + "-" + p[_p2];
                Console.WriteLine(nameof(GetScore) + " returned " + score);
                return score;
            }
            else
            {
                if (_p1 == _p2)
                    return "Deuce";
                s = _p1 > _p2 ? Player1Name : Player2Name;

                var score = ((_p1 - _p2) * (_p1 - _p2) == 1) ? "Advantage " + s : "Win for " + s;
                Console.WriteLine(nameof(GetScore) + " returned " + score);
                return score;
            }
        }

        public override void WonPoint(string playerName)
        {
            if (playerName == "player1")
            {
                this._p1 += 1;
                Console.WriteLine(nameof(this._p1) + " incremented");
            }
            else
            {
                this._p2 += 1;
                Console.WriteLine(nameof(this._p2) + " incremented");
            }
        }
    }
}

