namespace Tennis.Domain.Cases
{
    internal class ThirtyLove : IPossibleIssue
    {
        public bool Happens(Player one, Player two)
            => one.Score == 2 && two.Score == 0;

        public string Name => "Thirty-Love";
    }

    internal class LoveThirty : IPossibleIssue
    {
        public bool Happens(Player one, Player two)
            => one.Score == 0 && two.Score == 2;

        public string Name => "Love-Thirty";
    }
}
