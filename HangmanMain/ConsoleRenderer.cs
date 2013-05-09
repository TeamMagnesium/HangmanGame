namespace HangmanMain
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ConsoleRenderer
    {
        public const int MaxNumberOfTopPlayers = 5;

        public void PrintNewLine()
        {
            Console.WriteLine();
        }

        public void PrintWelcomeMessage()
        {
            StringBuilder printMessage = new StringBuilder();
            printMessage.Append("Welcome to \"Hangman\" game. Please try to guess my secret word\r\n");
            printMessage.Append("Use 'top' to view the scoreboard, 'restart' to start a new game and 'exit' to quit the game.");

            Console.WriteLine(printMessage.ToString());
        }

        public void PrintWordToDisplayMessage(string wordToDisplay)
        {
			Console.WriteLine("The secret word is {0}", GetSpaceSeparatedWord(wordToDisplay));
        }

        public void PrintEnterGuessOrCommandMessage()
        {
            Console.Write("Enter your guess or command: ");
        }

        public void PrintCorrectLetterMessage(int revealedLetters)
        {
            string printMessage;
            if (revealedLetters == 1)
            {
                printMessage = string.Format("Good job! You revealed {0} letter.", revealedLetters); 
            }
            else
            {
                printMessage = string.Format("Good job! You revealed {0} letters.", revealedLetters); 
            }

            Console.WriteLine(printMessage);
        }

        public void PrintRevealMessage(char revealedLetter)
        {
            string printMessage = string.Format("OK, I reveal for you the next letter '{0}'.", revealedLetter);
            Console.WriteLine(printMessage);
        }

        public void PrintIncorrectLetterMessage(char guessedLetter)
        {
            string printMessage = string.Format("Sorry! There are no unrevealed letters \"{0}\".", guessedLetter);

            Console.WriteLine(printMessage);
        }

        public void PrintRepeatingLetterMessage(char guessedLetter)
        {
            string printMessage = string.Format("You have already guessed the letter \"{0}\".", guessedLetter);
            Console.WriteLine(printMessage);
        }

        public void PrintWinningMessage(int mistakes)
        {
            string printMessage;
            if (mistakes == 1)
            {
                printMessage = string.Format("You won with {0} mistake.", mistakes);
            }
            else
            {
                printMessage = string.Format("You won with {0} mistakes.", mistakes);
            }

            Console.WriteLine(printMessage);
        }

        public void PrintCheatingMessage(int mistakes)
        {
            string printMessage;
            if (mistakes == 1)
            {
                printMessage = string.Format("You won with {0} mistake but you have cheated. You are not allowed to enter into the scoreboard.", mistakes);
            }
            else
            {
                printMessage = string.Format("You won with {0} mistakes but you have cheated. You are not allowed to enter into the scoreboard.", mistakes);
            }

            Console.WriteLine(printMessage);
        }

        public void PrintGetNameForScoreboard()
        {
            string printMessage = string.Format("Please enter your name for the top scoreboard: ");

            Console.Write(printMessage);
        }

        public void PrintScoreboard(List<Player> topPlayers)
        {
            StringBuilder printMessage = new StringBuilder();
            int listCount = 0;

            if (topPlayers.Count > MaxNumberOfTopPlayers)
            {
                listCount = MaxNumberOfTopPlayers;
            }
            else
            {
                listCount = topPlayers.Count;
            }

            if (listCount == 0)
            {
                printMessage.AppendLine("There are no records in the scoreboard.");
            }
            else
            {
                printMessage.Append("Scoreboard:\r\n");
                for (int i = 0; i < listCount; i++)
                {
                    if (topPlayers[i].Mistakes == 1)
                    {
                        printMessage.AppendFormat(
                            "{0}. {1} --> {2} mistake\r\n", i + 1, topPlayers[i].Name, topPlayers[i].Mistakes);
                    }
                    else
                    {
                        printMessage.AppendFormat(
                            "{0}. {1} --> {2} mistakes\r\n", i + 1, topPlayers[i].Name, topPlayers[i].Mistakes);
                    }
                }
            }

            Console.Write(printMessage);
        }

        public void PrintIncorrectInputMessage()
        {
            string printMessage = "Incorrect guess or command!";
            Console.WriteLine(printMessage);
        }        

        public void PrintExitMessage()
        {
            string printMessage = "Good bye!";
            Console.WriteLine(printMessage);
        }

		private string GetSpaceSeparatedWord(string word)
		{
			return String.Join(" ", word.ToCharArray());
		}
    }
}
