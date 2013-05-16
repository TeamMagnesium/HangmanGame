namespace HangmanMain
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	public interface IConsoleRenderer
	{
		void PrintNewLine();

		void PrintWelcomeMessage();

		void PrintWordToDisplayMessage(string wordToDisplay);

		void PrintEnterGuessOrCommandMessage();

		void PrintCorrectLetterMessage(int revealedLetters);

		void PrintRevealMessage(char revealedLetter);

		void PrintIncorrectLetterMessage(char guessedLetter);

		void PrintRepeatingLetterMessage(char guessedLetter);

		void PrintWinningMessage(int mistakes);

		void PrintCheatingMessage(int mistakes);

		void PrintGetNameForScoreboard();

		void PrintScoreboard(List<Player> topPlayers);

		void PrintIncorrectInputMessage(string exceptionMessage);

		void PrintExitMessage();
	}
}