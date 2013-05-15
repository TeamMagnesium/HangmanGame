using System;

namespace HangmanMain
{
	public interface IGame
	{
		string WordToGuess { get; }

		string WordToDisplay { get; }

		bool IsGameOver { get; }

		bool UsedHelp { get; }

		void StartGame();

		void RestartGame();

		void EndGame();

		void ExitGame();

		void UseHelp();

		void GuessSingleLetter(char charToGuess);
	}
}