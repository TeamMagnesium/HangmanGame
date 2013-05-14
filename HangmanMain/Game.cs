using System;
using System.Linq;

namespace HangmanMain
{
	public class Game
	{
		public string WordToGuess { get; private set; }
		public string WordToDisplay { get; private set; }
		public bool IsGameOver { get; private set; }
		public bool UsedHelp { get; private set; }

		private LetterHandler letterHandler;
		private ScoreManager scoreManager;
		private RandomWordGenerator generator;
		private ConsoleRenderer renderer;
		private CommandParser parser;

		private void InitializeGameSettings()
		{
			this.IsGameOver = false;
			this.UsedHelp = false;

			this.generator = new RandomWordGenerator();
            this.WordToGuess = generator.AssignRandomWord();
            this.WordToDisplay = GenerateBlankWord(WordToGuess.Length);

            this.letterHandler = new LetterHandler(WordToGuess);
            this.renderer = new ConsoleRenderer();
            this.parser = new CommandParser();
            this.scoreManager = ScoreManager.Instance;
		}

		private string GenerateBlankWord(int length)
		{
			return new String('_', length);
		}

		public Game()
		{
			InitializeGameSettings();
		}

		public void StartGame()
		{
            this.renderer.PrintWelcomeMessage();
            this.renderer.PrintWordToDisplayMessage(WordToDisplay);

			while (!IsGameOver)
			{
				try
				{
                    this.renderer.PrintEnterGuessOrCommandMessage();
					string userInput = Console.ReadLine();
					string command = parser.ParseCommand(userInput);
					ExecuteCommand(command);
				}
				catch (ArgumentException argumentException)
				{
                    this.renderer.PrintIncorrectInputMessage(argumentException.Message);
				}
			}
		}

		public void RestartGame()
		{
			InitializeGameSettings();
            this.renderer.PrintNewLine();
			StartGame();
		}

		public void EndGame()
		{
			IsGameOver = true;
		}

		public void ExitGame()
		{
			this.renderer.PrintExitMessage();
			EndGame();
		}

		private bool IsWordGuessed()
		{
			if (WordToDisplay == WordToGuess)
			{
				return true;
			}
			
			return false;
		}
        
		public void ExecuteCommand(string command)
		{
			switch (command.ToLower())
			{
				case "help":
					this.UsedHelp = true;
                    char revealedLetter = this.letterHandler.GetRevealedLetter(this.WordToDisplay);
                    this.renderer.PrintRevealMessage(revealedLetter);
					this.WordToDisplay = this.letterHandler.RevealLetter(this.WordToDisplay);
                    this.renderer.PrintWordToDisplayMessage(this.WordToDisplay);
					break;
				case "top":
                    this.renderer.PrintScoreboard(this.scoreManager.TopPlayers);
					break;
				case "restart":
					RestartGame();
					break;
				case "exit":
					ExitGame();
					break;
				default:
					char guessedLetter = command[0];
					LetterStatus letterStatus;
					this.WordToDisplay = this.letterHandler.HandleLetterGuess(guessedLetter, this.WordToDisplay, out letterStatus);
					HandleLetterGuessCommand(guessedLetter, letterStatus);
                    this.renderer.PrintWordToDisplayMessage(WordToDisplay);
					break;
			}
		}

		private void HandleLetterGuessCommand(char guessedLetter, LetterStatus letterStatus)
		{
			switch (letterStatus)
			{
				case LetterStatus.Correct:
					if (!IsWordGuessed())
					{
						this.renderer.PrintCorrectLetterMessage(this.letterHandler.GuessedLettersCount);
					}
					else
					{
						if (this.UsedHelp)
						{
							this.renderer.PrintCheatingMessage(this.letterHandler.WrongLettersCount);
							this.renderer.PrintWordToDisplayMessage(this.WordToDisplay);
						}
						else
						{
							this.renderer.PrintWinningMessage(this.letterHandler.WrongLettersCount);
							this.renderer.PrintWordToDisplayMessage(this.WordToDisplay);

							if (this.scoreManager.IsPlayerTop(this.letterHandler.WrongLettersCount))
							{
								this.renderer.PrintGetNameForScoreboard();
								string playerName = Console.ReadLine();
								int playerMistakes = this.letterHandler.WrongLettersCount;
								Player player = new Player(playerName, playerMistakes);
								this.scoreManager.AddPlayerToScoreBoard(player);
							}

							this.renderer.PrintScoreboard(this.scoreManager.TopPlayers);
						}

						this.RestartGame();
					}
					break;

				case LetterStatus.Incorrect:
					this.renderer.PrintIncorrectLetterMessage(guessedLetter);
					break;

				case LetterStatus.Repeating:
					this.renderer.PrintRepeatingLetterMessage(guessedLetter);
					break;
				default:
					break;
			}
		}
	}
}