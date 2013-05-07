using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanMain
{
    public static class ConsoleRenderer
    {
        public static void PrintWelcomeMessage()
        {
            StringBuilder printMessage = new StringBuilder();
            printMessage.Append("Welcome to \"Hangman\" game. Please try to guess my secret word\r\n");
            printMessage.Append("Use 'top' to view the scoreboard, 'restar' to start a new game and 'exit' to quit the game.");

            Console.WriteLine(printMessage.ToString());
        }

        public static void PrintUserWordMessage(string userWord)
        {
        }

        public static void PrintCorrectLetterMessage(int revealedLetters)
        {
            StringBuilder printMessage = new StringBuilder();
            printMessage.AppendFormat("Good job! You revealed {0} letter.", revealedLetters);

            Console.WriteLine(printMessage.ToString());
        }

        public static void PrintIncorrectLetterMessage(char guessedLetter)
        {
            StringBuilder printMessage = new StringBuilder();
            printMessage.AppendFormat("Sorry! There are no unrevealed letters \"{0}\".", guessedLetter);

            Console.WriteLine(printMessage.ToString());
        }

        public static void PrintWinningMessage(int mistakes)
        {
            StringBuilder printMessage = new StringBuilder();
            printMessage.AppendFormat("You won with {0} mistakes.", mistakes);

            Console.WriteLine(printMessage.ToString());
        }

        public static void PrintCheatingMessage(int mistakes)
        {
            StringBuilder printMessage = new StringBuilder();
            printMessage.AppendFormat("You won with {0} mistakes but you have cheated. You are not allowed to enter unto the scoreboard.", mistakes);

            Console.WriteLine(printMessage.ToString());
        }

        public static void PrintGetNameForScoreboard()
        {
            StringBuilder printMessage = new StringBuilder();
            printMessage.Append("Please enter your name for the top scoreboard:");

            Console.Write(printMessage.ToString());
        }

        public static void PrintScoreboard(List<Player> topPlayers)
        {
        }

        public static void PrintIncorrectInputMessage(string message)
        {
            StringBuilder printMessage = new StringBuilder();
            printMessage.Append("Incorrect guess or command!");
        }

        public static void PrintExitMessage()
        {
        }
    }
}
