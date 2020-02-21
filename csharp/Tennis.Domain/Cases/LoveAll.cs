namespace Tennis.Domain.Cases
{
    internal class LoveAll : IPossibleIssue
    {
        public bool Happens(Player one, Player two) 
            => one.Score == two.Score && one.Score == 0;

        public string Name => "Love-All";
    }
}
