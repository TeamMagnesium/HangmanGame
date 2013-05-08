using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanMain
{
	public class Game
	{
		private string dashWord;
		private string userWord;
		private string userInput;
		private bool isWordGuessed;
		private int health = 5;
		private char letter;
		private bool isGameOver;

		private LetterHandler letterHandler;
		private ScoreManager scoreManager;

		public Game(ScoreManager scoreManager)
		{
			InitializeGameSettings();
			this.scoreManager = scoreManager;
		}

		public void StartGame()
		{
			ConsoleRenderer.PrintWelcomeMessage();
			while (!isGameOver)
			{
				ConsoleRenderer.PrintUserWordMessage(userWord);
				userInput = Console.ReadLine();

				try
				{
					var currentCommand = CommandParser.ParseCommand(userInput);

					ExecuteCommand(currentCommand);
				}
				catch (ArgumentException ex)
				{
					ConsoleRenderer.PrintIncorrectInputMessage();
				}
			}
		}

		public void RestartGame()
		{
			InitializeGameSettings();
			StartGame();
		}

		public void EndGame()
		{
			isGameOver = true;
		}

		public void ExitGame()
		{
			ConsoleRenderer.PrintExitMessage();
			EndGame();
		}

		private void InitializeGameSettings()
		{
			this.isGameOver = false;
			this.isWordGuessed = false;
			this.health = 5;
			var generator = new RandomWordGenerator();
			this.userWord = generator.AssignRandomWord();
			this.letterHandler = new LetterHandler();
		}

		private void ExecuteCommand(string command)
		{
			switch (command)
			{
				case "help":
					this.letterHandler.RevealLetter();
					break;
				case "top":
					this.scoreManager.PrintScoreboard();
					break;
				case "restart":
					RestartGame();
					break;
				case "exit":
					ExitGame();
					break;
				default:
					this.letterHandler.HandleLetterGuess(command[0]);
					break;
			}
		}
	}
}