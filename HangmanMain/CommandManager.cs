using System;
using System.Linq;

namespace HangmanMain
{
	public class CommandManager : ICommandManager
	{
		private readonly ScoreManager scoreManager;
		private readonly ICommandParser parser;
		private readonly IConsoleRenderer renderer;

		public CommandManager() : this(new CommandParser(), new ConsoleRenderer())
		{
		}

		public CommandManager(ICommandParser parser, IConsoleRenderer renderer)
		{
			this.parser = parser;
			this.renderer = renderer;
			scoreManager = ScoreManager.Instance;
		}

		public void ExecuteCommandFromUserInput(IGame game, string userInput)
		{
			string command = this.parser.ParseCommand(userInput);
			ExecuteCommand(game, command);
		}

		public void ExecuteCommand(IGame game, string command)
		{
			switch (command.ToLower())
			{
				case "help":
					game.UseHelp();
					break;
				case "top":
					this.renderer.PrintScoreboard(this.scoreManager.TopPlayers);
					break;
				case "restart":
					game.RestartGame();
					break;
				case "exit":
					game.ExitGame();
					break;
				default:
					char guessedLetter = command[0];
					game.GuessSingleLetter(guessedLetter);
					break;
			}
		}
	}
}
