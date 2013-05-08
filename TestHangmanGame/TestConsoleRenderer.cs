namespace TestHangmanGame
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using HangmanMain;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestConsoleRenderer
    {
        [TestMethod]
        public void ValidateConsoleExitMessage()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                ConsoleRenderer.PrintExitMessage();

                string expected = string.Format("Good bye!{0}", Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void ValidateConsoleWelcomeMessage()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                ConsoleRenderer.PrintWelcomeMessage();

                string expected =
                    string.Format(
                        "Welcome to \"Hangman\" game. Please try to guess my secret word\r\nUse 'top' to view the scoreboard,"
                        + " 'restart' to start a new game and 'exit' to quit the game.{0}",
                        Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void ValidateConsolePrintUserWordMessage()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                ConsoleRenderer.PrintUserWordMessage("arr_ _");

                string expected = string.Format(
                    "The secret word is arr_ _{0}Enter your guess or command: ", Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void ValidateConsolePrintCorrectLetterMessageOf1()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                ConsoleRenderer.PrintCorrectLetterMessage(1);

                string expected = string.Format("Good job! You revealed 1 letter.{0}", Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void ValidateConsolePrintCorrectLetterMessageOf5()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                ConsoleRenderer.PrintCorrectLetterMessage(5);

                string expected = string.Format("Good job! You revealed 5 letters.{0}", Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void ValidateConsolePrintRevealMessageForA()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                ConsoleRenderer.PrintRevealMessage('a');

                string expected = string.Format("OK, I reveal for you the next letter 'a'.{0}", Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void ValidateConsolePrintIncorrectLetterMessageForA()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                ConsoleRenderer.PrintIncorrectLetterMessage('a');

                string expected = string.Format("Sorry! There are no unrevealed letters \"a\".{0}", Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void ValidateConsolePrintWinningMessageFor1Mistake()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                ConsoleRenderer.PrintWinningMessage(1);

                string expected = string.Format("You won with 1 mistake.{0}", Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void ValidateConsolePrintWinningMessageFor2Mistakes()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                ConsoleRenderer.PrintWinningMessage(2);

                string expected = string.Format("You won with 2 mistakes.{0}", Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void ValidateConsolePrintCheatingMessageFor1Mistake()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                ConsoleRenderer.PrintCheatingMessage(1);

                string expected =
                    string.Format(
                        "You won with 1 mistake but you have cheated. "
                        + "You are not allowed to enter into the scoreboard.{0}",
                        Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void ValidateConsolePrintCheatingMessageFor5Mistakes()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                ConsoleRenderer.PrintCheatingMessage(5);

                string expected =
                    string.Format(
                        "You won with 5 mistakes but you have cheated. "
                        + "You are not allowed to enter into the scoreboard.{0}",
                        Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void ValidateConsolePrintGetNameForScoreboard()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                ConsoleRenderer.PrintGetNameForScoreboard();
                string expected = "Please enter your name for the top scoreboard:";
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void ValidateConsolePrintIncorrectInputMessage()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                ConsoleRenderer.PrintIncorrectInputMessage();
                string expected = string.Format(
                    "Incorrect guess or command!{0}Enter your guess or command:", Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void ValidateConsolePrintScoreboardOf5Players()
        {
            List<Player> scoreboard = new List<Player>();

            scoreboard.Add(new Player("Ivan", 0));
            scoreboard.Add(new Player("petur", 1));
            scoreboard.Add(new Player("Bay Ivan", 2));
            scoreboard.Add(new Player("Misho", 3));
            scoreboard.Add(new Player("Milan", 5));

            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                ConsoleRenderer.PrintScoreboard(scoreboard);
                string expected =
                    string.Format(
                        "Scoreboard:{0}1. Ivan --> 0 mistakes{0}" + "2. petur --> 1 mistake{0}"
                        + "3. Bay Ivan --> 2 mistakes{0}" + "4. Misho --> 3 mistakes{0}5. Milan --> 5 mistakes{0}",
                        Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void ValidateConsolePrintScoreboardOf0Players()
        {
            List<Player> scoreboard = new List<Player>();

            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                ConsoleRenderer.PrintScoreboard(scoreboard);
                string expected = "There are no records in the scoreboard.";
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        public void ValidateConsolePrintScoreboardOf1Player()
        {
            List<Player> scoreboard = new List<Player>();
            scoreboard.Add(new Player("Ivan", 0));

            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                ConsoleRenderer.PrintScoreboard(scoreboard);
                string expected = string.Format("Scoreboard:{0}1. Ivan --> 0 mistakes{0}", Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void ValidateConsolePrintScoreboardOf6Players()
        {
            List<Player> scoreboard = new List<Player>();

            scoreboard.Add(new Player("Ivan", 0));
            scoreboard.Add(new Player("petur", 1));
            scoreboard.Add(new Player("Bay Ivan", 2));
            scoreboard.Add(new Player("Misho", 3));
            scoreboard.Add(new Player("Milan", 5));
            scoreboard.Add(new Player("Milcho", 6));

            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                ConsoleRenderer.PrintScoreboard(scoreboard);
                string expected =
                    string.Format(
                        "Scoreboard:{0}1. Ivan --> 0 mistakes{0}" + "2. petur --> 1 mistake{0}"
                        + "3. Bay Ivan --> 2 mistakes{0}" + "4. Misho --> 3 mistakes{0}5. Milan --> 5 mistakes{0}",
                        Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }
    }
}