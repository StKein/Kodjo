using System;
using System.Collections.Generic;

namespace Kodjo
{
	public class GameMaster
	{
		private Game Game;
		private ContentMaster ContentMaster;
		
		const int DEFAULT_GAME_SIZE = 4;
		
		
		public GameMaster()
		{
			this.ContentMaster = new ContentMaster();
			this.ContentMaster.printPage();
		}
		
		
		public void processInput( string _input ){
			this.ContentMaster.clearContent();
			if( _input == "" ){
				this.ContentMaster.setHeader("");
				this.ContentMaster.printPage();
				return;
			}
			string[] input = _input.Split(' ');
			switch( input[0] ){
				case Commands.NEW_GAME:
					this.startGame( input );
					this.ContentMaster.setHeader( Headers.NEW_GAME );
					this.ContentMaster.setPage( Pages.GAME );
					this.ContentMaster.setGameField( this.Game.GameField );
					break;
				case Commands.HELP:
					this.ContentMaster.setHeader( Headers.HELP );
					break;
				case Commands.LIST:
					this.ContentMaster.setHeader( Headers.LIST );
					break;
				case Commands.LANGUAGE:
					this.ContentMaster.setHeader("");
					string language = ( input.Length >= 2 ) ? input[1].ToLower() : "";
					this.ContentMaster.setLanguage( language );
					break;
				case Commands.EXIT:
					this.ContentMaster.setHeader("");
					this.ContentMaster.setPage( Pages.EXIT );
					break;
				// MOVE
				default:
					this.processMove( input );
					break;
			}
			this.ContentMaster.printPage();
		}
		
		
		private void startGame( string[] _input ){
			int size = GameMaster.DEFAULT_GAME_SIZE;
			if( _input.Length >= 2 ){
				int.TryParse( _input[1], out size );
				if( size < 2 ){
					size = GameMaster.DEFAULT_GAME_SIZE;
				} else if( size % 2 == 1 ){
					size++;
				}
			}
			this.Game = new Game( size );
		}
		
		// Input is console input split by " ", from processInput
		private void processMove( string[] _input ){
			if( this.Game == null || !this.Game.IsActive || _input == null || _input.Length < 2 ){
				this.ContentMaster.setHeader( Headers.UNKNOWN_COMMAND );
			} else {
				if( this.Game.validateMove( int.Parse( _input[0] ), int.Parse( _input[1] ) ) ){
					this.ContentMaster.setHeader( Headers.MOVE_CORRECT );
					this.ContentMaster.setGameField( this.Game.GameField );
					if( this.Game.guessIsCorrect() ){
						if( this.Game.IsActive ){
							this.ContentMaster.setPage( Pages.GAME_GUESS_CORRECT );
						} else {
							this.ContentMaster.setPage( Pages.GAME_WIN );
						}
					} else {
						this.ContentMaster.setPage( Pages.GAME_GUESS_INCORRECT );
					}
				} else {
					this.ContentMaster.setHeader( Headers.MOVE_INCORRECT );
					this.ContentMaster.setPage( Pages.GAME );
				}
			}
		}
	}
}
