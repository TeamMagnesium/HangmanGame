using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace HangmanMain
{
    public class Player
    {
        private string name;
        public string Name
        {
            get { return name; }
        }

        private int mistakes;
        public int Mistakes
        {
            get { return mistakes; }
        }        

        public Player(string name, int mistakes)
        {
            this.name = name;

            Debug.Assert(mistakes >= 0, "Mistakes cannot be less than 0!");
            this.mistakes = mistakes;
        }
    }
}
