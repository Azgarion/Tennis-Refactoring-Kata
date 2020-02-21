namespace Tennis.Domain
{
    public interface ITennisGame
    {
        void WonPoint(string playerName);
        string GetScore();
    }
}

