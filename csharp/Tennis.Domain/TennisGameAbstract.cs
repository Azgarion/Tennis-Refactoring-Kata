using System;

namespace Tennis.Domain
{
    public abstract class TennisGameAbstract : ITennisGame
    {
        protected readonly string Player1Name;
        protected readonly string Player2Name;

        protected int Player1Score { get; private set; }
        protected int Player2Score { get; private set; }

        internal TennisGameAbstract(string player1Name, string player2Name)
        {
            Console.WriteLine($"New {GetType().Name}");

            Player1Name = player1Name;
            Console.WriteLine($"{nameof(Player1Name)} equals {Player1Name}");

            Player2Name = player2Name;
            Console.WriteLine($"{nameof(Player2Name)} equals {Player2Name}");
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
            {
                Player1Score += 1;
                Console.WriteLine(nameof(Player1Score) + " incremented");
            }
            else
            {
                Player2Score += 1;
                Console.WriteLine(nameof(Player2Score) + " incremented");
            }
        }
        public abstract string GetScore();
    }
}
