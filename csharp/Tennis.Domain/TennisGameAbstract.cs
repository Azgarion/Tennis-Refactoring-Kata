using System;

namespace Tennis.Domain
{
    public abstract class TennisGameAbstract : ITennisGame
    {
        protected readonly string Player1Name;
        protected readonly string Player2Name;

        internal TennisGameAbstract(string player1Name, string player2Name)
        {
            Console.WriteLine($"New {GetType().Name}");

            Player1Name = player1Name;
            Console.WriteLine($"{nameof(Player1Name)} equals {Player1Name}");

            Player2Name = player2Name;
            Console.WriteLine($"{nameof(Player2Name)} equals {Player2Name}");
        }

        public abstract void WonPoint(string playerName);
        public abstract string GetScore();
    }
}
