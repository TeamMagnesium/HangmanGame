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

		public void setup()
		{
			game = new Game();
		}

		[TestMethod]
		public void GameConstructor_IsGameOver()
		{
			Assert.IsFalse(game.IsGameOver);
		}

		[TestMethod]
		public void GameConstructor_UsedHelp()
		{
			Assert.IsFalse(game.UsedHelp);
		}

		[TestMethod]
		public void GameConstructor_WordToGuess()
		{
			Assert.IsFalse(string.IsNullOrEmpty(game.WordToGuess));
		}

		[TestMethod]
		public void GameConstructor_WordToDisplayEmpty()
		{
			Assert.IsFalse(string.IsNullOrEmpty(game.WordToDisplay));
		}

		[TestMethod]
		public void GameConstructor_WordToDisplayNoLetters()
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
		public void GameConstructor_WordToDisplayAndWordToGuess()
		{
			Assert.IsTrue(game.WordToGuess.Length == game.WordToDisplay.Length);
		}

		[TestMethod]
		public void ExecuteCommand_Help()
		{
			game.ExecuteCommand("Help");
			Assert.IsTrue(game.UsedHelp);
		}

		[TestMethod]
		public void ExecuteCommand_Exit()
		{
			game.ExecuteCommand("Exit");
			Assert.IsTrue(game.IsGameOver);
		}

	}
}
