namespace Tennis.Domain.Cases
{
    internal class FortyLove : IPossibleIssue
    {
        public bool Happens(Player one, Player two)
            => one.Score == 3 && two.Score == 0;

        public string Name => "Forty-Love";
    }

    internal class LoveForty : IPossibleIssue
    {
        public bool Happens(Player one, Player two)
            => one.Score == 0 && two.Score == 3;

        public string Name => "Love-Forty";
    }
}
