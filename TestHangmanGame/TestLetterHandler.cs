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
        public void GuessedLettersCountIsValid()
        {
            LetterHandler letterHandler = new LetterHandler("computer");
            string wordToDisplay = "________";
            LetterStatus letterStatus;

            letterHandler.HandleLetterGuess('c', wordToDisplay, out letterStatus);

            Assert.AreEqual(1, letterHandler.GuessedLettersCount);
        }

        [TestMethod]
        public void GuessedLettersCount_BiggerThanOneIsValid()
        {
            LetterHandler letterHandler = new LetterHandler("debugger");
            string wordToDisplay = "________";
            LetterStatus letterStatus;

            letterHandler.HandleLetterGuess('g', wordToDisplay, out letterStatus);

            Assert.AreEqual(2, letterHandler.GuessedLettersCount);
        }

        [TestMethod]
        public void WrongLettersCountIsValid()
        {
            LetterHandler letterHandler = new LetterHandler("computer");
            string wordToDisplay = "________";
            LetterStatus letterStatus;

            letterHandler.HandleLetterGuess('a', wordToDisplay, out letterStatus);

            Assert.AreEqual(1, letterHandler.WrongLettersCount);
        }

        [TestMethod]
        public void LetterHandlerIsValid()
        {
            LetterHandler letterHandler = new LetterHandler("computer");
            LetterHandler letterHandlerSecond = new LetterHandler("computer");

            Assert.AreNotSame(letterHandler, letterHandlerSecond);
        }

        [TestMethod]
        public void GetRevealedLetterIsValid()
        {
            LetterHandler letterHandler = new LetterHandler("computer");
            string wordToDisplay = "________";

            char revealedLetter = letterHandler.GetRevealedLetter(wordToDisplay);

            Assert.AreEqual('c', revealedLetter);
        }

        [TestMethod]
        public void RevealLetterIsValid()
        {
            LetterHandler letterHandler = new LetterHandler("computer");
            string wordToDisplay = "________";

            string wordToDisplayRevealed = letterHandler.RevealLetter(wordToDisplay);

            Assert.AreEqual("c_______", wordToDisplayRevealed);
        }

        [TestMethod]
        public void HandleLetterGuess_CorrectLetterStatusIsValid()
        {
            LetterHandler letterHandler = new LetterHandler("computer");
            string wordToDisplay = "________";
            LetterStatus letterStatus;

            string wordToDisplayRevealed = letterHandler.HandleLetterGuess('c', wordToDisplay, out letterStatus);

            Assert.AreEqual(LetterStatus.Correct, letterStatus);
            Assert.AreEqual("c_______", wordToDisplayRevealed);
        }

        [TestMethod]
        public void HandleLetterGuess_RepeatingLetterStatusIsValid()
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
        public void HandleLetterGuess_IncorrectLetterStatusIsValid()
        {
            LetterHandler letterHandler = new LetterHandler("computer");
            string wordToDisplay = "________";
            LetterStatus letterStatus;

            string wordToDisplayRevealed = letterHandler.HandleLetterGuess('a', wordToDisplay, out letterStatus);

            Assert.AreEqual(LetterStatus.Incorrect, letterStatus);
            Assert.AreEqual("________", wordToDisplayRevealed);
        }

        [TestMethod]
        public void FillLetterIsValid()
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
