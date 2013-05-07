using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanMain
{
    public static class Game
    {
        private static string dashWord;
        private static string userWord;
        private static string input;
     //   private bool isWordGuessed;
       // private int health = 5;
        private char letter;
        private static bool isGameOver;

        public static void StartGame()
        {
            ConsoleRenderer.PrintWelcomeMessage();
            while (isGameOver == false)
            {
                ConsoleRenderer.PrintUserWordMessage(userWord);
                input = Console.ReadLine();

                try
                {
                    // TODO: parse command

                    // TODO: execute command
                }
                catch (ArgumentException ex)
                {
                    ConsoleRenderer.PrintIncorrectInputMessage(ex.Message);
                }
                

                // TODO: 
                // TODO: 
                // TODO: 
                // TODO: 
                // TODO: 
                // TODO: 
                // TODO: 
                
            }
        }

        public static void RestartGame()
        {
            // TODO: give default values to variables

            Game.StartGame();
        }

        public static void EndGame()
        {
            isGameOver = true;
        }

        public static void ExitGame()
        {
            ConsoleRenderer.PrintExitMessage();
            EndGame();
        }
    }
}
