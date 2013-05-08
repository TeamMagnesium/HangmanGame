using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestHangmanGame
{
    using System.IO;

    using HangmanMain;

    [TestClass]
    public class TestConsoleRenderer
    {
        [TestMethod]
        public void ValidateConsoleExitMessage()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                ConsoleRenderer.PrintExitMessage();

                string expected = string.Format("Good bye!{0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void ValidateConsoleWelcomeMessage()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                ConsoleRenderer.PrintWelcomeMessage();

                string expected =
                    string.Format(
                        "Welcome to \"Hangman\" game. Please try to guess my secret word\r\nUse 'top' to view the scoreboard,"
                        + " 'restart' to start a new game and 'exit' to quit the game.{0}",
                        Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }
        }

    }
}