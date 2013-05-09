using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanMain
{
    public class LetterHandler
    {
		private readonly List<char> triedLetters = new List<char>();

		private readonly string wordToGuess;

		public LetterHandler(string word)
		{
			this.wordToGuess = word;
		}

        public char GetRevealedLetter(string wordToDisplay)
        {
			char revealedLetter = char.MinValue;
			for (int i = 0; i < wordToDisplay.Length; i++)
			{
				if (wordToDisplay[i] == '_')
				{
					revealedLetter = wordToGuess[i];
					break;
				}
			}
			return revealedLetter;
        }

		public void RevealLetter(ref string wordToDisplay)
        {
			char revealedLetter = GetRevealedLetter(wordToDisplay);
			wordToDisplay = FillLetter(revealedLetter, wordToDisplay);
        }

		public void HandleLetterGuess(char guessedLetter, ref string wordToDisplay, out LetterStatus letterStatus)
        {
			if (triedLetters.Contains(guessedLetter))
			{
				letterStatus = LetterStatus.Repeating;
			}
			else
			{
				triedLetters.Add(guessedLetter);
				if (wordToGuess.Contains(guessedLetter))
				{
					wordToDisplay = FillLetter(guessedLetter, wordToDisplay);
					letterStatus = LetterStatus.Correct;
				}
				else
				{
					letterStatus = LetterStatus.Incorrect;
				}
			}
        }

		private string FillLetter(char letter, string wordToDisplay)
        {
			char[] wordAfterLetterFill = wordToDisplay.ToCharArray();
			for (int i = 0; i < wordAfterLetterFill.Length; i++)
			{
				if (wordToGuess[i] == letter)
				{
					wordAfterLetterFill[i] = letter;
				}
			}
			return String.Join("",wordAfterLetterFill);
        }

    }
}
