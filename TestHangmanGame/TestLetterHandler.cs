using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HangmanMain;

namespace TestHangmanGame
{
    [TestClass]
    public class TestLetterHandler
    {
        [TestMethod]
        public void TestGuessedLettersCount1()
        {
            LetterHandler letterHandler = new LetterHandler("computer");
            string wordToDisplay = "________";
            LetterStatus letterStatus;

            letterHandler.HandleLetterGuess('o', wordToDisplay, out letterStatus);

            Assert.AreEqual(1, letterHandler.GuessedLettersCount);
        }

        [TestMethod]
        public void TestGuessedLettersCount2()
        {
            LetterHandler letterHandler = new LetterHandler("debugger");
            string wordToDisplay = "________";
            LetterStatus letterStatus;

            letterHandler.HandleLetterGuess('g', wordToDisplay, out letterStatus);

            Assert.AreEqual(2, letterHandler.GuessedLettersCount);
        }

        [TestMethod]
        public void TestWrongLettersCount1()
        {
            LetterHandler letterHandler = new LetterHandler("computer");
            string wordToDisplay = "________";
            LetterStatus letterStatus;

            letterHandler.HandleLetterGuess('a', wordToDisplay, out letterStatus);

            Assert.AreEqual(1, letterHandler.WrongLettersCount);
        }

        [TestMethod]
        public void TestLetterHandlerConstructor()
        {
            LetterHandler letterHandler = new LetterHandler("computer");
            LetterHandler letterHandlerSecond = new LetterHandler("software");

            Assert.AreNotSame(letterHandler, letterHandlerSecond);
        }

        [TestMethod]
        public void TestGetRevealedLetter()
        {
            LetterHandler letterHandler = new LetterHandler("computer");
            string wordToDisplay = "c_______";

            char revealedLetter = letterHandler.GetRevealedLetter(wordToDisplay);

            Assert.AreEqual('o', revealedLetter);
        }

        [TestMethod]
        public void TestRevealLetter()
        {
            LetterHandler letterHandler = new LetterHandler("computer");
            string wordToDisplay = "________";

            string wordToDisplayRevealed = letterHandler.RevealLetter(wordToDisplay);

            Assert.AreEqual("c_______", wordToDisplayRevealed);
        }

        [TestMethod]
        public void TestHandleLetterGuessCorrectLetterStatus()
        {
            LetterHandler letterHandler = new LetterHandler("computer");
            string wordToDisplay = "________";
            LetterStatus letterStatus;

            string wordToDisplayRevealed = letterHandler.HandleLetterGuess('c', wordToDisplay, out letterStatus);

            Assert.AreEqual(LetterStatus.Correct, letterStatus);
            Assert.AreEqual("c_______", wordToDisplayRevealed);
        }

        [TestMethod]
        public void TestHandleLetterGuessRepeatingLetterStatus()
        {
            LetterHandler letterHandler = new LetterHandler("computer");
            string wordToDisplay = "________";
            LetterStatus letterStatus;

            string wordToDisplayRevealed = letterHandler.HandleLetterGuess('c', wordToDisplay, out letterStatus);
            string wordToDisplayChecked = letterHandler.HandleLetterGuess('c', wordToDisplayRevealed, out letterStatus);

            Assert.AreEqual(LetterStatus.Repeating, letterStatus);
            Assert.AreEqual("c_______", wordToDisplayChecked);
        }

        [TestMethod]
        public void TestHandleLetterGuessIncorrectLetterStatus()
        {
            LetterHandler letterHandler = new LetterHandler("computer");
            string wordToDisplay = "________";
            LetterStatus letterStatus;

            string wordToDisplayRevealed = letterHandler.HandleLetterGuess('a', wordToDisplay, out letterStatus);

            Assert.AreEqual(LetterStatus.Incorrect, letterStatus);
            Assert.AreEqual("________", wordToDisplayRevealed);
        }

        [TestMethod]
        public void TestFillLetter()
        {
            LetterHandler letterHandler = new LetterHandler("computer");
            string wordToDisplay = "________";
            LetterStatus letterStatus;

            string wordToDisplayRevealed = letterHandler.HandleLetterGuess('c', wordToDisplay, out letterStatus);

            Assert.AreEqual(1, letterHandler.GuessedLettersCount);
            Assert.AreEqual("c_______", wordToDisplayRevealed);
        }
    }
}
