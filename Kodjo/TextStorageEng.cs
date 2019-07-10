using System;

namespace Kodjo
{
	public class TextStorageEng : TextStorage
	{
		public override string Language{ get{ return Languages.ENGLISH; } }
		
		
		public TextStorageEng() : base(){}
		
		
		public override string getMessage( string _type ){
			string message = "";
			string no_quotes = " (without quotes)";
			switch( _type ){
				case Texts.GREETING:
					message = "Guten tag and welcome to Kodjo 1.01!";
					break;
				case Texts.GUIDE:
					message = 
						"To start a new game, enter \"" + Commands.NEW_GAME + "\"" + 
						no_quotes + ". " + "To see a list of available " +
						"commands, enter \"" + Commands.LIST + "\".";
					break;
				case Texts.UNKNOWN_COMMAND:
					message = 
						"Unknown command. To see a list of available " +
						"commands, enter \"" + Commands.LIST + "\".";
					break;
				case Texts.NEW_GAME:
					message = "Started a new  game. Good luck!";
					break;
				case Texts.HELP:
					message = 
						"Your goal is to clear the field by opening " + 
						"pairs of the same items, one pair per move. " + 
						"To open a pair of items, enter their respective IDs, " + 
						"separated by space.";
					break;
				case Texts.MOVE:
					message = "Enter your next move.";
					break;
				case Texts.GUESS_CORRECT:
					message = "Items match! Well done.";
					break;
				case Texts.GUESS_INCORRECT:
					message = "Items don't match.";
					break;
				case Texts.MOVE_INCORRECT:
					message = 
						"Incorrect move. Please enter two IDs of remaining items, " + 
						"separated by space.";
					break;
				case Texts.LOSE:
					message = 
						"Alas, you lost the game. Don't get upset! " +
						"Start a new game or switch to something else.";
					break;
				case Texts.WIN:
					message = "You won the game. Congratulations! Feel free to start a new one.";
					break;
				case Texts.LIST:
					message = "Available commands:";
					break;
				case Texts.LIST_PS:
					message = "Any other command will be treated as game move.";
					break;
				case Texts.LANGUAGE_ALREADY_SET:
					message = "Language already set to english.";
					break;
				case Texts.LANGUAGE_SET:
					message = "Language set to english.";
					break;
				case Texts.FAREWELL:
					message = "Au revoir! Come back any time.";
					break;
			}
			
			return message;
		}
		
		public override string getCommandDescription( string _command ){
			string description = "";
			string no_quotes = " (without quotes)";
			switch( _command ){
				case Commands.NEW_GAME:
					description = 
						"Start a new game. You can set the field size after space, " + 
						"for example, \"" + Commands.NEW_GAME + " 6\"" + no_quotes + 
						". Keep in mind that field is square and if you enter " + 
						"odd number, it will be increased by 1.";
					break;
				case Commands.HELP:
					description = "Print help about game.";
					break;
				case Commands.LIST:
					description = "Print list of commands and their description.";
					break;
				case Commands.LANGUAGE:
					description = 
						"Set text language in game. Keep in mind that you can enter " + 
						"either full name of language or short one. Available languages: ";
					break;
				case Commands.EXIT:
					description = "Exit the game.";
					break;
			}
			
			return description;
		}
	}
}
