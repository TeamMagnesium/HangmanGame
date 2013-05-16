using System;
using HangmanMain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestHangmanGame
{
	[TestClass]
	public class TestGame
	{
		Game game;
		[TestInitialize]

		public void Setup()
		{
			game = new Game();
		}

		[TestMethod]
		public void TestGameConstructorIsGameOver()
		{
			Assert.IsFalse(game.IsGameOver);
		}

		[TestMethod]
		public void TestGameConstructorUsedHelp()
		{
			Assert.IsFalse(game.UsedHelp);
		}

		[TestMethod]
		public void TestGameConstructorWordToGuess()
		{
			Assert.IsFalse(string.IsNullOrEmpty(game.WordToGuess));
		}

		[TestMethod]
		public void TestGameConstructorWordToDisplayEmpty()
		{
			Assert.IsFalse(string.IsNullOrEmpty(game.WordToDisplay));
		}

		[TestMethod]
		public void TestGameConstructorWordToDisplayNoLetters()
		{
			bool hasLetters = false;
			for (int i = 0; i < game.WordToDisplay.Length; i++)
			{
				if (game.WordToDisplay[i] != '_')
				{
					hasLetters = true;
				}
			}
			Assert.IsFalse(hasLetters);
		}

		[TestMethod]
		public void TestGameConstructorWordToDisplayAndWordToGuess()
		{
			Assert.IsTrue(game.WordToGuess.Length == game.WordToDisplay.Length);
		}

		[TestMethod]
		public void TestEndGame()
		{
			game.EndGame();
			Assert.IsTrue(game.IsGameOver);
		}

		[TestMethod]
		public void TestExitGame()
		{
			game.EndGame();
			Assert.IsTrue(game.IsGameOver);
		}

	}
}
