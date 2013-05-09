using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanMain
{
	public class Game
	{
		private string wordToGuess;
		private string wordToDisplay;
		private string userInput;
		private bool isGameOver;
        private char guessedLetter;
        private LetterStatus letterStatus;

		private LetterHandler letterHandler;
		private readonly ScoreManager scoreManager;
		private RandomWordGenerator generator;
        private ConsoleRenderer renderer;
        private CommandParser parser;

        private void InitializeGameSettings()
        {
			this.isGameOver = false;
            this.generator = new RandomWordGenerator();
			this.wordToGuess = generator.AssignRandomWord();
			this.wordToDisplay = GenerateBlankWord(wordToGuess.Length);
			this.letterHandler = new LetterHandler(wordToGuess);
            this.renderer = new ConsoleRenderer();
            this.parser = new CommandParser();
        }

        private string GenerateBlankWord(int length)
        {
            return new String('_', length);
        }

		public Game(ScoreManager scoreManager)
		{
			InitializeGameSettings();
			this.scoreManager = scoreManager;
		}

		public void StartGame()
		{
			renderer.PrintWelcomeMessage();
            renderer.PrintUserWordMessage(wordToDisplay);

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
            if (wordToDisplay==wordToGuess)
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
                    char revealedLetter = letterHandler.GetRevealedLetter(wordToDisplay);
                    renderer.PrintRevealMessage(revealedLetter);
					letterHandler.RevealLetter(ref wordToDisplay);
                    renderer.PrintUserWordMessage(wordToDisplay);
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
					this.letterHandler.HandleLetterGuess(guessedLetter, ref wordToDisplay, out letterStatus);
                    
                    // TODO: if IsWordGuessed
                    //       PrintWinning/PrintCheatingMessage
                    //       PrintUserWordMessage
                    //       PrintGetNameForScoreboard
                    //       AddPlayerToScoreboard
                    //       PrintScoreboard
                    //       Restart game

                          // else
                    // TODO: check letterStatus and print appropriate messages

                    renderer.PrintUserWordMessage(wordToDisplay);
					break;
			}
		}
	}
}