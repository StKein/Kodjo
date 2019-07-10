using System;
using System.Collections.Generic;

namespace Kodjo
{
	public class ContentMaster
	{
		private TextStorage TextStorage;
		private string Page;
		private string Header;
		private string[,] CurrentGameField;
		
		public void setPage( string _page ){ this.Page = _page; }
		public void setHeader( string _header ){ this.Header = _header; }
		public void setGameField( string[,] _game_field ){ this.CurrentGameField = _game_field; }
		
		
		public ContentMaster(){
			this.TextStorage = new TextStorageEng();
			this.Page = "index";
			this.Header = "";
		}
		
		
		public void setLanguage( string _language ){
			switch( _language ){
				case "en":
				case "eng":
				case "english":
					if( this.TextStorage.Language.Equals( Languages.ENGLISH ) ){
						Console.WriteLine( this.TextStorage.getMessage("language_already_set") );
					} else {
						this.TextStorage = new TextStorageEng();
						Console.WriteLine( this.TextStorage.getMessage("language_set") );
					}
					break;
				case "ru":
				case "rus":
				case "russian":
					if( this.TextStorage.Language.Equals( Languages.RUSSIAN ) ){
						Console.WriteLine( this.TextStorage.getMessage("language_already_set") );
					} else {
						this.TextStorage = new TextStorageRus();
						Console.WriteLine( this.TextStorage.getMessage("language_set") );
					}
					break;
			}
		}
		
		public void clearContent(){
			Console.Clear();
		}
		
		public void printPage(){
			this.printHeader();
			if( !this.Header.Equals("") ){
				Console.WriteLine();
			}
			this.printContent();
		}
		
		
		private void printHeader(){
			switch( this.Header ){
				case Headers.NEW_GAME:
					Console.WriteLine( this.TextStorage.getMessage( Texts.NEW_GAME ) );
					break;
				case Headers.MOVE_INCORRECT:
					Console.WriteLine( this.TextStorage.getMessage( Texts.MOVE_INCORRECT ) );
					break;
				case Headers.UNKNOWN_COMMAND:
					Console.WriteLine( this.TextStorage.getMessage( Texts.UNKNOWN_COMMAND ) );
					break;
				case Headers.HELP:
					Console.WriteLine( this.TextStorage.getMessage( Texts.HELP ) );
					break;
				case Headers.LIST:
					Console.WriteLine( this.TextStorage.getMessage( Texts.LIST ) );
					List<string> guide = this.TextStorage.getCommandsGuide();
					for( int i = 0; i < guide.Count; i++ ){
						Console.WriteLine( guide[i] );
					}
					break;
			}
		}
		
		private void printContent(){
			switch( this.Page ){
				case Pages.INDEX:
					Console.WriteLine( this.TextStorage.getMessage( Texts.GREETING ) );
					Console.WriteLine( this.TextStorage.getMessage( Texts.GUIDE ) );
					break;
				case Pages.GAME:
					this.printGameField();
					Console.WriteLine( this.TextStorage.getMessage( Texts.MOVE ) );
					break;
				case Pages.GAME_GUESS_CORRECT:
					this.printGameField();
					Console.WriteLine( this.TextStorage.getMessage( Texts.GUESS_CORRECT ) );
					Console.WriteLine( this.TextStorage.getMessage( Texts.MOVE ) );
					break;
				case Pages.GAME_GUESS_INCORRECT:
					this.printGameField();
					Console.WriteLine( this.TextStorage.getMessage( Texts.GUESS_INCORRECT ) );
					Console.WriteLine( this.TextStorage.getMessage( Texts.MOVE ) );
					break;
				case Pages.GAME_LOSE:
					this.printGameField();
					Console.WriteLine( this.TextStorage.getMessage( Texts.LOSE ) );
					break;
				case Pages.GAME_WIN:
					this.printGameField();
					Console.WriteLine( this.TextStorage.getMessage( Texts.WIN ) );
					this.setPage( Pages.INDEX ); // Да, костыль. Но иначе пиздос
					break;
				case Pages.EXIT:
					Console.WriteLine( this.TextStorage.getMessage( Texts.FAREWELL ) );
					break;
			}
		}
		
		private void printGameField(){
			for( int i = 0; i < this.CurrentGameField.GetLength(0); i++ ){
				for( int j = 0; j < this.CurrentGameField.GetLength(1); j++ ){
					if( j > 0 ){
						Console.Write(" ");
					}
					Console.Write( this.CurrentGameField[i,j] );
				}
				Console.WriteLine();
			}
		}
	}
}
