using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanMain
{
    public class LetterHandler
    {
		private List<char> guessedLetters = new List<char>();
		private List<char> triedLetters = new List<char>();

		private readonly string wordToGuess;

		public LetterHandler(string word)
		{
			this.wordToGuess = word;
		}

        public char GetRevealedLetter(string wordToDisplay)
        {
            char revealedLetter = 'a'; // has to be changed

            // find revealed letter - first hidden letter from left to right

            return revealedLetter;
        }

		public void RevealLetter(ref string wordToDisplay)
        {
			char revealedLetter = GetRevealedLetter(wordToDisplay);
			FillLetter(revealedLetter, wordToDisplay);
        }

		public void HandleLetterGuess(char guessedLetter, ref string wordToDisplay, out LetterStatus letterStatus)
        {
            // TODO: check if letter is repeating (is in guessedLetters)

            // TODO: if not, add letter to guessedLetters, check if letter is correct

            // TODO: if letter is correct, fill userWord

            // TODO: change letterStatus

            letterStatus = LetterStatus.Incorrect;
        }

        private bool IsLetterRepeating(char letter)
        {

            return false;
        }

        private bool IsLetterCorrect(char letter)
        {


            return false;
        }

		private string FillLetter(char letter, string wordToDisplay)
        {


			return wordToDisplay;
        }

    }
}
