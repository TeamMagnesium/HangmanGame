using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HangmanMain;

namespace TestHangmanGame
{
    [TestClass]
    public class TestScoreManager
    {
        [TestInitialize]
        public void ClearScoreboard()
        {
            ScoreManager.Instance.TopPlayers.Clear();
        }

        [TestMethod]
        public void TestInstance()
        {
            ScoreManager manager1 = ScoreManager.Instance;
            ScoreManager manager2 = ScoreManager.Instance;

            Assert.AreEqual(manager1, manager2);
        }

        [TestMethod]
        public void TestIsPlayerTop4TopPlayers()
        {
            Player player1 = new Player("Ivan", 0);
            Player player2 = new Player("Maria", 1);
            Player player3 = new Player("Georgi", 2);
            Player player4 = new Player("Gergana", 5);

            ScoreManager manager = ScoreManager.Instance;

            manager.AddPlayerToScoreBoard(player1);
            manager.AddPlayerToScoreBoard(player2);
            manager.AddPlayerToScoreBoard(player3);
            manager.AddPlayerToScoreBoard(player4);

            Player newPlayer = new Player("Pesho", 10);
            Assert.IsTrue(manager.IsPlayerTop(newPlayer.Mistakes));
        }

        [TestMethod]
        public void TestIsPlayerTop5PlayersIsTop()
        {
            Player player1 = new Player("Ivan", 0);
            Player player2 = new Player("Maria", 1);
            Player player3 = new Player("Georgi", 2);
            Player player4 = new Player("Gergana", 5);
            Player player5 = new Player("Gosho", 3);

            ScoreManager manager = ScoreManager.Instance;

            manager.AddPlayerToScoreBoard(player1);
            manager.AddPlayerToScoreBoard(player2);
            manager.AddPlayerToScoreBoard(player3);
            manager.AddPlayerToScoreBoard(player4);
            manager.AddPlayerToScoreBoard(player5);

            Player newPlayer = new Player("Pesho", 4);
            Assert.IsTrue(manager.IsPlayerTop(newPlayer.Mistakes));
        }

        [TestMethod]
        public void TestIsPlayerTop5PlayersIsNotTop()
        {
            Player player1 = new Player("Ivan", 0);
            Player player2 = new Player("Maria", 1);
            Player player3 = new Player("Georgi", 2);
            Player player4 = new Player("Gergana", 5);
            Player player5 = new Player("Gosho", 3);

            ScoreManager manager = ScoreManager.Instance;

            manager.AddPlayerToScoreBoard(player1);
            manager.AddPlayerToScoreBoard(player2);
            manager.AddPlayerToScoreBoard(player3);
            manager.AddPlayerToScoreBoard(player4);
            manager.AddPlayerToScoreBoard(player5);

            Player newPlayer = new Player("Pesho", 5);
            Assert.IsFalse(manager.IsPlayerTop(newPlayer.Mistakes));
        }

        [TestMethod]
        public void TestAddPlayerToScoreboard()
        {
            Player player1 = new Player("Ivan", 0);
            Player player2 = new Player("Maria", 1);
            Player player3 = new Player("Georgi", 2);
            Player player4 = new Player("Gergana", 5);
            Player player5 = new Player("Gosho", 3);
            Player newPlayer = new Player("Pesho", 4);

            ScoreManager manager = ScoreManager.Instance;

            manager.AddPlayerToScoreBoard(player1);
            manager.AddPlayerToScoreBoard(player2);
            manager.AddPlayerToScoreBoard(player3);
            manager.AddPlayerToScoreBoard(player4);
            manager.AddPlayerToScoreBoard(player5);
            manager.AddPlayerToScoreBoard(newPlayer);

            Assert.IsTrue(manager.TopPlayers.Contains(newPlayer));
            Assert.IsFalse(manager.TopPlayers.Contains(player4));
        }
    }
}
