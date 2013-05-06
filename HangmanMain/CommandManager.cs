using System;
using System.Linq;

namespace HangmanMain
{
	public static class CommandManager
	{
		private static char currentLetter;
		public static void ExecuteCommand(string command)
		{
			switch (command)
			{
				case "help":
					//TO DO: Add command
					break;
				case "top":
					//TO DO: ConsoleRenderer.PrintScores();
					break;
				case "restart":
					//TO DO: Game.Restart();
					break;
				case "exit":
					//TO DO: ConsoleRenderer.Print("Good bye!");
					break;
				case "turn":
					//TO DO: LetterHandler.CheckLetter(currentLetter);
					break;
				default:
					break;
			}
		}
		public static string ParseCommand(string commandString)
		{
			var command = "";
			if (commandString == "help" || commandString == "top" || commandString == "exit" || commandString == "restart")
			{
				command = commandString;
			}
			else if (commandString.Length == 1 && Char.IsLetter(commandString[0]))
			{
				currentLetter = commandString[0];
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
