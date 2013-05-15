using System;
using System.Linq;

namespace HangmanMain
{
	public interface ICommandManager
	{
		void ExecuteCommand(IGame game, string command);
		void ExecuteCommandFromUserInput(IGame game, string userInput);
	}
}
