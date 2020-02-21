using System;

namespace Tennis.Domain
{
    public abstract class TennisGameAbstract : ITennisGame
    {
        protected Player Player1 { get; }
        protected Player Player2 { get; }

        internal TennisGameAbstract(string player1Name, string player2Name)
        {
            Console.WriteLine($"New {GetType().Name}");

            Player1 = new Player(player1Name);
            Console.WriteLine($"Player1Name equals {Player1.Name}");

            Player2 = new Player(player2Name);
            Console.WriteLine($"Player2Name equals {Player2.Name}");
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1") 
                Player1.WinPoint();
            else 
                Player2.WinPoint();
        }
        public abstract string GetScore();
    }
}
