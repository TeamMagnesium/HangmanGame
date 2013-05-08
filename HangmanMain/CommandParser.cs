using System;
using System.Linq;

namespace HangmanMain
{
	public static class CommandParser
	{
		private static char guessedLetter;

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
				command = guessedLetter.ToString();
			}
			else
			{
				throw new ArgumentException("Invalid command. Allowed commands are top, restart, help, exit, or a letter guess.");
			}

			return command;
		}
	}
}