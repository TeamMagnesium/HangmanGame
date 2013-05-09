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
		private bool isGameOver;
        private char guessedLetter;
        private LetterStatus letterStatus;

		private LetterHandler letterHandler;
		private ScoreManager scoreManager;
        private RandomWordGenerator generator;
        private ConsoleRenderer renderer;
        private CommandParser parser;

        private void InitializeGameSettings()
        {
            this.isGameOver = false;
            
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
            string blankWord;

            for (int i = 0; i < length; i++)
            {
                stringBuilder.Append("_ ");
            }

            blankWord = stringBuilder.ToString();
            string trimmedBlankWord = blankWord.TrimEnd();

            return trimmedBlankWord;
        }

		public Game(ScoreManager scoreManager)
		{
			InitializeGameSettings();
			this.scoreManager = scoreManager;
		}

		public void StartGame()
		{
			renderer.PrintWelcomeMessage();
            renderer.PrintUserWordMessage(userWord);

			while (!isGameOver)
			{
                try
                {
                    renderer.PrintEnterGuessOrCommandMessage();
                    userInput = Console.ReadLine();
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

        private bool IsWordGuessed()
        {
            if (userWord==dashWord)
            {
                return true;
            }

            return false;
        }
        
		private void ExecuteCommand(string command)
		{
			switch (command)
			{
				case "help":
                    char revealedLetter = letterHandler.GetRevealedLetter(dashWord, userWord);
                    renderer.PrintRevealMessage(revealedLetter);

					letterHandler.RevealLetter(dashWord, ref userWord);

                    renderer.PrintUserWordMessage(userWord);
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
                    this.guessedLetter = command[0];
					this.letterHandler.HandleLetterGuess(guessedLetter, dashWord, ref userWord, out letterStatus);
                    
                    // TODO: if IsWordGuessed
                    //       PrintWinning/PrintCheatingMessage
                    //       PrintUserWordMessage
                    //       PrintGetNameForScoreboard
                    //       AddPlayerToScoreboard
                    //       PrintScoreboard
                    //       Restart game

                          // else
                    // TODO: check letterStatus and print appropriate messages

                    renderer.PrintUserWordMessage(userWord);
					break;
			}
		}
	}
}