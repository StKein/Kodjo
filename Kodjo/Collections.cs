using System;
using System.Collections.Generic;

namespace Kodjo{
	
	internal static class Commands{
		public const string NEW_GAME = "start";
		public const string PRINT = "print";
		public const string HELP = "help";
		public const string LIST = "ls";
		public const string EXIT = "exit";
		
		public static List<string> CommandsList{
			get{
				List<string> list = new List<string>();
				foreach( var constant in typeof( Commands ).GetFields() ){
					if( constant.IsLiteral && !constant.IsInitOnly ){
						list.Add((string)constant.GetValue(null));
					}
				}
				
				return list;
			}
		}
	}
	
	internal static class Messages{
		public const string GREETING = 
			"Guten tag and welcome to Kodjo 1.01!";
		public const string GUIDE = 
			"To start a new game, enter \"start\" (without quotes). " + 
			"To see a list of available commands, enter \"ls\".";
		public const string NEW_GAME = 
			"Started a new  game. Good luck!";
		public const string HELP = 
			"Your goal is to clear the field by opening " + 
			"pairs of the same items, one pair per move. " + 
			"To open a pair of items, enter their respective IDs, " + 
			"separated by space. To see remaining items and theid IDS, " + 
			"enter \"print\" (without quotes).";
		public const string MOVE = 
			"Enter your next move.";
		public const string GUESS_CORRECT = 
			"Items match! Well done.";
		public const string GUESS_INCORRECT = 
			"Items don't match.";
		public const string ERROR = 
			"Incorrect move. Please enter two IDs of remaining items, " + 
			"separated by space. If you want to see remaining items, " + 
			"enter \"print\" (without quotes).";
		public const string WIN = 
			"You won the game. Congratulations! Feel free to start a new one.";
		public const string LIST = 
			"Available commands:";
		public const string PRINT_NOGAME = 
			"Nothing to print. Enter \"start\" to start a new game first!";
		public const string PRINT_NOACTIVE = 
			"You've won this game. Enter \"start\" to start a new one!";
		public const string FAREWELL = 
			"Au revoir! Come back any time.";
	}
	
}