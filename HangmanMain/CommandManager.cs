using System;
using System.Linq;

namespace HangmanMain
{
	public static class CommandManager
	{
		private static char guessedLetter;

		public static void ExecuteCommand(string command)
		{
			switch (command)
			{
				case "help":
                    LetterHandler.RevealLetter();
					break;
				case "top":
                    ScoreManager.PrintScoreboard();
					break;
				case "restart":
					Game.RestartGame();
					break;
				case "exit":
                    Game.ExitGame();
					break;
				case "turn":
					LetterHandler.HandleLetterGuess(guessedLetter);
					break;
				default:
					break;
			}
		}
		public static string ParseCommand(string commandString)
		{
			string command;

			if (commandString == "help" || commandString == "top" || commandString == "exit" || commandString == "restart")
			{
				command = commandString;
			}
			else if (commandString.Length == 1 && Char.IsLetter(commandString[0]))
			{
				guessedLetter = commandString[0];
				command = "turn";
			}
			else
			{
				throw new ArgumentException("Invalid command. Allowed commands are top, restart, help, exit, or a letter guess.");
			}

			return command;
		}
	}
}
