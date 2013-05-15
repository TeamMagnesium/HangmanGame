using System;
using HangmanMain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;

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
		public void StartGame_RendererPrints_WelcomeMessage()
		{
			var rendererMock = Mock.Create<IConsoleRenderer>();
			var generatorMock = Mock.Create<IRandomWordGenerator>();
			var commandManagerMock = Mock.Create<ICommandManager>();

			Mock.Arrange(() => rendererMock.PrintWelcomeMessage()).OccursOnce();
			Mock.Arrange(() => generatorMock.AssignRandomWord()).Returns("word");
			
			var game = new Game(rendererMock, generatorMock, commandManagerMock);
			Mock.Arrange(() => game.IsGameOver).Returns(true);

			game.StartGame();

			Mock.Assert(rendererMock);
		}

	}
}
