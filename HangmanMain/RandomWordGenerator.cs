using System;
using System.Linq;

namespace HangmanMain
{
	public class RandomWordGenerator : IRandomWordGenerator
	{
		private readonly string[] words;

		public string[] Words
		{
			get
			{
				return words;
			}
		}

        public RandomWordGenerator()
        {
            this.words = new string[] {
                "computer", "programmer" , "software" , "debugger" , "compiler" , "developer" , "algorithm",
                "array" , "method" , "variable"
            };
        }

		public string AssignRandomWord()
		{
            Random randomizer = new Random();
            int wordIndex = randomizer.Next(0, this.words.Length);
			string randomWord = words[wordIndex];
			return randomWord;
        }

		public ILetterHandler GenerateLetterHandler()
		{
			return new LetterHandler(AssignRandomWord());
		}
    }
}
