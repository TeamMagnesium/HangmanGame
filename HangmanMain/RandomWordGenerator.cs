using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanMain
{
    public class RandomWordGenerator
    {
        private string[] words;
        public string[] Words
        {
            get { return words; }
            set { words = value; }
        }

        public RandomWordGenerator()
        {
            this.words = new string[] {
                "computer", "programmer" , "software" , "debugger" , "compiler" , "developer" , "algorithm",
                "array" , "method" , "variable"
            };
        }

        public string RandomizeAWord()
        {
            Random randomizer = new Random();
            int wordIndex = randomizer.Next(0, this.words.Length);

            return words[wordIndex];
        }
    }
}
