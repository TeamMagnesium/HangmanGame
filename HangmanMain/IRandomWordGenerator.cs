using System;

namespace HangmanMain
{
	public interface IRandomWordGenerator
	{
		string[] Words { get; }

		string AssignRandomWord();

		ILetterHandler GenerateLetterHandler();
	}
}