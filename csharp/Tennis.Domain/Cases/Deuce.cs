namespace Tennis.Domain.Cases
{
    public class Deuce : IPossibleIssue
    {
        public bool Happens(Player one, Player two)
            => one.Score == two.Score && one.Score > 2;

        public string Name => "Deuce";
    }
}
