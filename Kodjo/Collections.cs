using System;
using System.Collections.Generic;

namespace Kodjo{
	
	internal static class Commands{
		public const string NEW_GAME = "start";
		public const string HELP = "help";
		public const string LIST = "ls";
		public const string LANGUAGE = "lang";
		public const string EXIT = "exit";
	}
	
	internal static class Languages{
		public const string ENGLISH = "English";
		public const string RUSSIAN = "Russian";
	}
	
	internal static class Headers{
		public const string NEW_GAME = "ng";
		public const string HELP = "help";
		public const string LIST = "ls";
		public const string MOVE_CORRECT = "";
		public const string MOVE_INCORRECT = "move_i";
		public const string UNKNOWN_COMMAND = "duh";
	}
	
	internal static class Pages{
		public const string INDEX = "index";
		public const string GAME = "game";
		public const string GAME_GUESS_CORRECT = "game_gut";
		public const string GAME_GUESS_INCORRECT = "game_ngut";
		public const string GAME_WIN = "game_booyah";
		public const string GAME_LOSE = "game_shit";
		public const string EXIT = "exit";
	}
	
	internal static class Texts{
		public const string GREETING = "greeting";
		public const string GUIDE = "guide";
		public const string NEW_GAME = "new_game";
		public const string HELP = "help";
		public const string MOVE = "move";
		public const string GUESS_CORRECT = "guess_correct";
		public const string GUESS_INCORRECT = "guess_incorrect";
		public const string MOVE_INCORRECT = "move_incorrect";
		public const string LOSE = "lose";
		public const string WIN = "win";
		public const string LIST = "list";
		public const string LIST_PS = "list_ps";
		public const string LANGUAGE_ALREADY_SET = "language_already_set";
		public const string LANGUAGE_SET = "language_set";
		public const string UNKNOWN_COMMAND = "duh";
		public const string FAREWELL = "farewell";
	}
	
}