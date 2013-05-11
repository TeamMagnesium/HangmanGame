using System;
using System.Linq;

namespace HangmanMain
{
	public class CommandParser
	{
		private char guessedLetter;

		public string ParseCommand(string commandString)
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
                throw new ArgumentException("Incorrect guess or command!");
			}

			return command;
		}
	}
}