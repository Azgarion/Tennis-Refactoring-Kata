namespace Tennis.Domain.Cases
{
    internal interface IPossibleIssue
    {
        bool Happens(Player one, Player two);
        string Name { get; }
    }
}
