namespace Tennis.Domain.Cases
{
    internal class ThirtyAll : IPossibleIssue
    {
        public bool Happens(Player one, Player two) 
            => one.Score == two.Score && one.Score == 2;

        public string Name => "Thirty-All";
    }
}
