using System;
using System.Linq;

namespace HangmanMain
{
    class HangmanMain
    {       

   

        static void Main()
        {
            // TODO: make class instances

            // TODO: generate dash word

            // TODO: make user word (char '-' repeating dash word length number of times)

			while (true)
			{
				// TODO: render messages

				var userInput = Console.ReadLine();
				var currentCommand = "";
				try
				{
					currentCommand = CommandManager.ParseCommand(userInput);
				}
				catch (ArgumentException arEx)
				{
					Console.WriteLine(arEx.Message);
					continue;
				}
				CommandManager.ExecuteCommand(currentCommand);

				// TODO: handle user input and catch exceptions

				// TODO: check letter

				// TODO: render messages
			}
        }
    }
}
