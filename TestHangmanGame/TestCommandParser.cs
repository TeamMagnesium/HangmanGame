using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HangmanMain;

namespace TestHangmanGame
{
    [TestClass]
    public class TestCommandParser
    {
        private static CommandParser parser;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            parser = new CommandParser();
        }

        [TestMethod]
        public void TestValidCommand()
        {
            string command = "top";
            string parsedCommand = parser.ParseCommand(command);
            Assert.AreEqual(command, parsedCommand);
        }

        [TestMethod]
        public void TestLetterCommand()
        {
            string command = "a";
            string parsedCommand = parser.ParseCommand(command);
            Assert.AreEqual(command, parsedCommand);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidCommand()
        {
            string command = "hello";
            string parsedCommand = parser.ParseCommand(command);
        }
    }
}
