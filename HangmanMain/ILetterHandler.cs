using System;
using System.Collections.Generic;
using System.Linq;

namespace HangmanMain
{
	public interface ILetterHandler
	{
		int GuessedLettersCount { get; }

		int WrongLettersCount { get; }

		char GetRevealedLetter(string wordToDisplay);

		string RevealLetter(string wordToDisplay);

		string HandleLetterGuess(char guessedLetter, string wordToDisplay, out LetterStatus letterStatus);
	}
}