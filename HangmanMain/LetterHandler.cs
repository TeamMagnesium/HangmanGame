using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanMain
{
    public class LetterHandler
    {
        private static char[] guessedLetters;
        public static char[] GuessedLetters
        {
            get { return guessedLetters; }
            set { guessedLetters = value; }
        }

        public void RevealLetter()
        {
        }

        public void HandleLetterGuess(char guessedLetter)
        {
        }

        private void CheckLetter(char letter, string dashWord, ref string userWord, out LetterStatus letterStatus)
        {
            // TODO: check if letter is repeating (is in guessedLetters)

            // TODO: if not, check if letter is in dashWord

            // TODO: if letter is correct, change userWord

            // TODO: change letterStatus
            
            //userWord = userWord;
            letterStatus = LetterStatus.Incorrect;
        }
    }
}
