using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanMain
{
    public class LetterHandler
    {
        private List<char> guessedLetters = new List<char>();

        public char GetRevealedLetter(string dashWord, string userWord)
        {
            char revealedLetter = 'a'; // has to be changed

            // find revealed letter - first hidden letter from left to right

            return revealedLetter;
        }

        public void RevealLetter(string dashWord, ref string userWord)
        {
            char revealedLetter = GetRevealedLetter(dashWord, userWord);
            FillLetter(revealedLetter, dashWord, userWord);
        }

        public void HandleLetterGuess(char guessedLetter, string dashWord, ref string userWord, out LetterStatus letterStatus)
        {
            // TODO: check if letter is repeating (is in guessedLetters)

            // TODO: if not, add letter to guessedLetters, check if letter is correct

            // TODO: if letter is correct, fill userWord

            // TODO: change letterStatus

            letterStatus = LetterStatus.Incorrect;
        }

        private bool IsLetterRepeating(char letter)
        {

            return false;
        }

        private bool IsLetterCorrect(char letter, string dashWord)
        {


            return false;
        }

        private string FillLetter(char letter, string dashWord, string userWord)
        {


            return userWord;
        }

    }
}
