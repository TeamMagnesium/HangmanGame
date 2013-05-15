using System;
using System.Collections.Generic;
using System.Linq;

namespace HangmanMain
{
	public class LetterHandler : ILetterHandler
	{
		private readonly List<char> triedLetters = new List<char>();

		private string wordToGuess;

		public int GuessedLettersCount { get; private set; }

		public int WrongLettersCount { get; private set; }

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

		public string RevealLetter(string wordToDisplay)
		{
			char revealedLetter = GetRevealedLetter(wordToDisplay);
			wordToDisplay = FillLetter(revealedLetter, wordToDisplay);
			return wordToDisplay;
        }

		public string HandleLetterGuess(char guessedLetter, string wordToDisplay, out LetterStatus letterStatus)
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
					letterStatus = LetterStatus.Correct;
					wordToDisplay = FillLetter(guessedLetter, wordToDisplay);
				}
				else
				{
					letterStatus = LetterStatus.Incorrect;
					this.WrongLettersCount++;
				}
			}
			return wordToDisplay;
        }

		private string FillLetter(char letter, string wordToDisplay)
        {
            this.GuessedLettersCount = 0;

			char[] wordAfterLetterFill = wordToDisplay.ToCharArray();
			for (int i = 0; i < wordAfterLetterFill.Length; i++)
			{
				if (wordToGuess[i] == letter)
				{
					wordAfterLetterFill[i] = letter;
                    this.GuessedLettersCount++;
				}
			}
			return String.Join("",wordAfterLetterFill);
        }
    }
}
