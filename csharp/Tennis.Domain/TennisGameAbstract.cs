using System;
using System.Collections.Generic;
using System.Linq;
using Tennis.Domain.Cases;

namespace Tennis.Domain
{
    public abstract class TennisGameAbstract : ITennisGame
    {
        protected Player Player1 { get; }
        protected Player Player2 { get; }

        private static readonly IEnumerable<IPossibleIssue> KnownIssues = new IPossibleIssue[]
        {
            new LoveAll(),
            new FifteenAll(),
            new ThirtyAll(),
            new Deuce()
        };

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

        private bool IssueMatches(IPossibleIssue possibleIssue)
            => possibleIssue.Happens(Player1, Player2);

        public string GetScore()
        {
            var score = KnownIssues
                .FirstOrDefault(IssueMatches)?.Name 
                ?? ProcessScore();

            Console.WriteLine(nameof(GetScore) + " returned " + score);
            return score;
        }

        protected abstract string ProcessScore();
    }
}
