﻿namespace TestHangmanGame
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using HangmanMain;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestConsoleRenderer
    {
        private ConsoleRenderer renderer = new ConsoleRenderer();
        
        [TestMethod]
        public void TestConsoleExitMessage()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                renderer.PrintExitMessage();

                string expected = string.Format("Good bye!{0}", Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void TestConsolePrintEnterYourGuessOrCommand()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                renderer.PrintEnterGuessOrCommandMessage();

                string expected = "Enter your guess or command: ";
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void TestConsoleWelcomeMessage()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                renderer.PrintWelcomeMessage();

                string expected =
                    string.Format(
                        "Welcome to \"Hangman\" game. Please try to guess my secret word\r\nUse 'top' to view the scoreboard,"
                        + " 'restart' to start a new game and 'exit' to quit the game.{0}",
                        Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void TestConsolePrintUserWordMessage()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                renderer.PrintWordToDisplayMessage("arr__");

                string expected = string.Format(
                    "The secret word is a r r _ _{0}", Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void TestConsolePrintCorrectLetterMessageOf1()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                renderer.PrintCorrectLetterMessage(1);

                string expected = string.Format("Good job! You revealed 1 letter.{0}", Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void TestConsolePrintCorrectLetterMessageOf5()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                renderer.PrintCorrectLetterMessage(5);

                string expected = string.Format("Good job! You revealed 5 letters.{0}", Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void TestConsolePrintRevealMessageForA()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                renderer.PrintRevealMessage('a');

                string expected = string.Format("OK, I reveal for you the next letter 'a'.{0}", Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void TestConsolePrintIncorrectLetterMessageForA()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                renderer.PrintIncorrectLetterMessage('a');

                string expected = string.Format("Sorry! There are no unrevealed letters \"a\".{0}", Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void TestConsolePrintWinningMessageFor1Mistake()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                renderer.PrintWinningMessage(1);

                string expected = string.Format("You won with 1 mistake.{0}", Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void TestConsolePrintWinningMessageFor2Mistakes()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                renderer.PrintWinningMessage(2);

                string expected = string.Format("You won with 2 mistakes.{0}", Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void TestConsolePrintCheatingMessageFor1Mistake()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                renderer.PrintCheatingMessage(1);

                string expected =
                    string.Format(
                        "You won with 1 mistake but you have cheated. "
                        + "You are not allowed to enter into the scoreboard.{0}",
                        Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void TestConsolePrintCheatingMessageFor5Mistakes()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                renderer.PrintCheatingMessage(5);

                string expected =
                    string.Format(
                        "You won with 5 mistakes but you have cheated. "
                        + "You are not allowed to enter into the scoreboard.{0}",
                        Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void TestConsolePrintGetNameForScoreboard()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                renderer.PrintGetNameForScoreboard();
                string expected = "Please enter your name for the top scoreboard: ";
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void TestConsolePrintIncorrectInputMessage()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                renderer.PrintIncorrectInputMessage("Incorrect guess or command!");
                string expected = string.Format(
                    "Incorrect guess or command!{0}", Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void TestConsolePrintRepeatingLetterMessage()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                renderer.PrintRepeatingLetterMessage('t');
                string expected = string.Format(
                    "You have already guessed the letter \"t\".{0}", Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void TestConsolePrintScoreboardOf5Players()
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
                renderer.PrintScoreboard(scoreboard);
                string expected =
                    string.Format(
                        "Scoreboard:{0}1. Ivan --> 0 mistakes{0}" + "2. petur --> 1 mistake{0}"
                        + "3. Bay Ivan --> 2 mistakes{0}" + "4. Misho --> 3 mistakes{0}5. Milan --> 5 mistakes{0}",
                        Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void TestConsolePrintScoreboardOf0Players()
        {
            List<Player> scoreboard = new List<Player>();

            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                renderer.PrintScoreboard(scoreboard);
                string expected = String.Format("There are no records in the scoreboard.{0}",Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        public void TestConsolePrintScoreboardOf1Player()
        {
            List<Player> scoreboard = new List<Player>();
            scoreboard.Add(new Player("Ivan", 0));

            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                renderer.PrintScoreboard(scoreboard);
                string expected = string.Format("Scoreboard:{0}1. Ivan --> 0 mistakes{0}", Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void TestConsolePrintNewLine()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                renderer.PrintNewLine();
                string expected = Environment.NewLine;
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }
    }
}