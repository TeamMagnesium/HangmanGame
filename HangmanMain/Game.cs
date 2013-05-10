using System;
using System.Linq;

namespace HangmanMain
{
	public class Game
	{
		private string wordToGuess;
		private string wordToDisplay;
		private string userInput;
		private bool isGameOver;
		private bool usedHelp;
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
			this.usedHelp = false;

			this.generator = new RandomWordGenerator();
            this.wordToGuess = generator.AssignRandomWord();
            this.wordToDisplay = GenerateBlankWord(wordToGuess.Length);

            this.letterHandler = new LetterHandler(wordToGuess);
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
            this.renderer.PrintWordToDisplayMessage(wordToDisplay);

			while (!isGameOver)
			{
				try
				{
                    this.renderer.PrintEnterGuessOrCommandMessage();
					userInput = Console.ReadLine();
					string command = parser.ParseCommand(userInput);
					ExecuteCommand(command);
				}
				catch (ArgumentException)
				{
                    this.renderer.PrintIncorrectInputMessage();
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
			isGameOver = true;
		}

		public void ExitGame()
		{
			this.renderer.PrintExitMessage();
			EndGame();
		}

		private bool IsWordGuessed()
		{
			if (wordToDisplay == wordToGuess)
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
					this.usedHelp = true;
                    char revealedLetter = this.letterHandler.GetRevealedLetter(wordToDisplay);
                    this.renderer.PrintRevealMessage(revealedLetter);
                    this.letterHandler.RevealLetter(ref wordToDisplay);
                    this.renderer.PrintWordToDisplayMessage(wordToDisplay);
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
					this.guessedLetter = command[0];
					this.letterHandler.HandleLetterGuess(guessedLetter, ref wordToDisplay, out letterStatus);

					switch (letterStatus)
					{
						case LetterStatus.Correct:
							if (IsWordGuessed() == false)
							{
								this.renderer.PrintCorrectLetterMessage(this.letterHandler.GuessedLettersCount);
							}
							else
							{
								if (this.usedHelp)
								{
									this.renderer.PrintCheatingMessage(this.letterHandler.WrongLettersCount);
                                    this.renderer.PrintWordToDisplayMessage(this.wordToDisplay);
								}
								else
								{
									this.renderer.PrintWinningMessage(this.letterHandler.WrongLettersCount);
									this.renderer.PrintWordToDisplayMessage(this.wordToDisplay);

                                    if (this.scoreManager.IsPlayerTop(this.letterHandler.WrongLettersCount))
                                    {
                                        this.renderer.PrintGetNameForScoreboard();
                                        Player player = new Player();
                                        player.Name = Console.ReadLine();
                                        player.Mistakes = this.letterHandler.WrongLettersCount;
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
                    this.renderer.PrintWordToDisplayMessage(wordToDisplay);
					break;
			}
		}
	}
}