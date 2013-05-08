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
		private bool isGameOver;

		private LetterHandler letterHandler;
		private ScoreManager scoreManager;
        private RandomWordGenerator generator;
        private ConsoleRenderer renderer;
        private CommandParser parser;

        private void InitializeGameSettings()
        {
            this.isGameOver = false;
            this.isWordGuessed = false;
            
            this.generator = new RandomWordGenerator();            
            this.letterHandler = new LetterHandler();
            this.renderer = new ConsoleRenderer();
            this.parser = new CommandParser();

            this.dashWord = generator.AssignRandomWord();
            this.userWord = BlankWord(dashWord.Length);
        }

        private string BlankWord(int length)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                stringBuilder.Append('_');
            }

            return stringBuilder.ToString();
        }

		public Game(ScoreManager scoreManager)
		{
			InitializeGameSettings();
			this.scoreManager = scoreManager;
		}

		public void StartGame()
		{
			renderer.PrintWelcomeMessage();
			while (!isGameOver)
			{
				renderer.PrintUserWordMessage(userWord);
				userInput = Console.ReadLine();

				try
				{
					string command = parser.ParseCommand(userInput);
					ExecuteCommand(command);
				}
				catch (ArgumentException)
				{
					renderer.PrintIncorrectInputMessage();
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
			renderer.PrintExitMessage();
			EndGame();
		}
        
		private void ExecuteCommand(string command)
		{
			switch (command)
			{
				case "help":
					this.letterHandler.RevealLetter();
					break;
				case "top":
					this.renderer.PrintScoreboard(scoreManager.TopPlayers);
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