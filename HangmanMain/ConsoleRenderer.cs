﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanMain
{
    public static class ConsoleRenderer
    {
        public const int MaxNumberOfTopPlayers = 5;

        public static void PrintWelcomeMessage()
        {
            StringBuilder printMessage = new StringBuilder();
            printMessage.Append("Welcome to \"Hangman\" game. Please try to guess my secret word\r\n");
            printMessage.Append("Use 'top' to view the scoreboard, 'restart' to start a new game and 'exit' to quit the game.");

            Console.WriteLine(printMessage.ToString());
        }

        public static void PrintUserWordMessage(string userWord)
        {
            StringBuilder printMessage = new StringBuilder();
            printMessage.AppendFormat("The secret word is {0}\r\n", userWord);
            printMessage.Append("Enter your guess or command: ");

            Console.Write(printMessage.ToString());
        }

        public static void PrintCorrectLetterMessage(int revealedLetters)
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

        public static void PrintRevealMessage(char revealedLetter)
        {
            string printMessage = string.Format("OK, I reveal for you the next letter '{0}'.", revealedLetter);
            Console.WriteLine(printMessage);
        }

        public static void PrintIncorrectLetterMessage(char guessedLetter)
        {
            string printMessage = string.Format("Sorry! There are no unrevealed letters \"{0}\".", guessedLetter);

            Console.WriteLine(printMessage);
        }

        public static void PrintWinningMessage(int mistakes)
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

        public static void PrintCheatingMessage(int mistakes)
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

        public static void PrintGetNameForScoreboard()
        {
            string printMessage = string.Format("Please enter your name for the top scoreboard:");

            Console.Write(printMessage);
        }

        public static void PrintScoreboard(List<Player> topPlayers)
        {
            StringBuilder printMessage = new StringBuilder();
			if (topPlayers.Count == 0)
			{
				printMessage.Append("There are no records in the scoreboard.");
			}
			else
			{
				printMessage.Append("Scoreboard:\r\n");
				for (int i = 0; i < MaxNumberOfTopPlayers; i++)
				{
					if (topPlayers[i].Mistakes == 1)
					{
						printMessage.AppendFormat(
							"{0}. {1} --> {2} mistake\r\n",
							i,
							topPlayers[i].Name,
							topPlayers[i].Mistakes);
					}
					else
					{
						printMessage.AppendFormat(
							"{0}. {1} --> {2} mistakes\r\n",
							i,
							topPlayers[i].Name,
							topPlayers[i].Mistakes);
					}
				}
			}
			Console.WriteLine(printMessage);
        }

        public static void PrintIncorrectInputMessage()
        {
            string printMessage = "Incorrect guess or command!\r\nEnter your guess or command:";
            Console.Write(printMessage);
        }

        public static void PrintExitMessage()
        {
            string printMessage = "Good bye!";
            Console.WriteLine(printMessage);
        }
    }
}
