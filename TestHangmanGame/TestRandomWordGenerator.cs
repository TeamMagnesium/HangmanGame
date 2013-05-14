using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HangmanMain;

namespace TestHangmanGame
{
    [TestClass]
    public class TestRandomWordGenerator
    {
        [TestMethod]
        public void TestAssignRandomWord()
        {
            RandomWordGenerator generator = new RandomWordGenerator();
            for (int i = 0; i < 100; i++)
            {
                string generatedWord = generator.AssignRandomWord();
                bool isWordFound = false;

                foreach (var word in generator.Words)
                {
                    if (generatedWord == word)
                    {
                        isWordFound = true;
                    }
                }

                Assert.IsTrue(isWordFound);                
            }
        }
    }
}
