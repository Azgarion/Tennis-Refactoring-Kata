using System;

namespace Tennis.Domain
{
    public class Player
    {
        protected internal Player(string name)
        {
            Name = name;
        }

        public void WinPoint()
        {
            Score++;
            Console.WriteLine($"Player {Name} score incremented to {Score}");
        }

        public int Score { get; private set; }
        public string Name { get; }
    }
}
