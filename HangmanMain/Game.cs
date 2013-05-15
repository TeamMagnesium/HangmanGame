using System;
using System.Linq;

namespace HangmanMain
{
	public class Game : IGame
	{
		public string WordToGuess { get; private set; }

		public string WordToDisplay { get; private set; }

		public bool IsGameOver { get; private set; }

		public bool UsedHelp { get; private set; }

		private ILetterHandler letterHandler;
		private readonly ScoreManager scoreManager;
		private readonly IRandomWordGenerator generator;
		private readonly IConsoleRenderer renderer;

		private readonly ICommandManager commandManager;

		private void InitializeGameSettings()
		{
			this.IsGameOver = false;
			this.UsedHelp = false;

			this.WordToGuess = generator.AssignRandomWord();
            this.WordToDisplay = GenerateBlankWord(WordToGuess.Length);

			this.letterHandler = this.generator.GenerateLetterHandler();
		}

		private string GenerateBlankWord(int length)
		{
			return new String('_', length);
		}

		public Game() : this(new ConsoleRenderer(), new RandomWordGenerator(), new CommandManager())
		{
		}

		public Game(IConsoleRenderer renderer, IRandomWordGenerator generator, ICommandManager commandManager)
		{
			this.renderer = renderer;
			this.generator = generator;
			this.commandManager = commandManager;
			this.scoreManager = ScoreManager.Instance;

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
					string userInput = this.renderer.Read();
					this.commandManager.ExecuteCommandFromUserInput(this, userInput);
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

		public void UseHelp()
		{
			this.UsedHelp = true;
			char revealedLetter = this.letterHandler.GetRevealedLetter(this.WordToDisplay);
			this.renderer.PrintRevealMessage(revealedLetter);
			this.WordToDisplay = this.letterHandler.RevealLetter(this.WordToDisplay);
			this.renderer.PrintWordToDisplayMessage(this.WordToDisplay);
		}

		public void GuessSingleLetter(char guessedLetter)
		{
			LetterStatus letterStatus;
			this.WordToDisplay = this.letterHandler.HandleLetterGuess(guessedLetter, this.WordToDisplay, out letterStatus);
			HandleLetterGuess(guessedLetter, letterStatus);
			this.renderer.PrintWordToDisplayMessage(WordToDisplay);
		}

		private bool IsWordGuessed()
		{
			if (WordToDisplay == WordToGuess)
			{
				return true;
			}
			
			return false;
		}

		private void HandleLetterGuess(char guessedLetter, LetterStatus letterStatus)
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