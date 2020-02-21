namespace Tennis.Domain.Cases
{
    internal class FifteenAll : IPossibleIssue
    {
        public bool Happens(Player one, Player two) 
            => one.Score == two.Score && one.Score == 1;

        public string Name => "Fifteen-All";
    }
}
