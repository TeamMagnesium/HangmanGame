using System;
using System.Linq;

namespace HangmanMain
{
    public struct Player
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int mistakes;
        public int Mistakes
        {
            get { return mistakes; }
            set { mistakes = value; }
        }

        public Player(string name, int mistakes)
        {
            this.name = name;
            this.mistakes = mistakes;
        }
    }
}
