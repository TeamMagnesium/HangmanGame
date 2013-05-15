using System;

namespace HangmanMain
{
	public interface ICommandParser
	{
		string ParseCommand(string commandString);
	}
}