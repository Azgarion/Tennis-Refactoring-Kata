namespace Tennis.Domain.Cases
{
    internal class FifteenLove : IPossibleIssue
    {
        public bool Happens(Player one, Player two)
            => one.Score == 1 && two.Score == 0;

        public string Name => "Fifteen-Love";
    }

    internal class LoveFifteen : IPossibleIssue
    {
        public bool Happens(Player one, Player two)
            => one.Score == 0 && two.Score == 1;

        public string Name => "Love-Fifteen";
    }
}
