using System;
using System.Linq;

namespace HangmanMain
{
	using System.Collections.Generic;

	class HangmanMain
	{ 
		static void Main()
		{
			var scoreManager = new ScoreManager();
			var game = new Game(scoreManager);
			game.StartGame();
		}
	}
}