using System;
using System.Collections.Generic;

namespace Kodjo
{
	public class GameMaster
	{
		private Game Game;
		
		public GameMaster()
		{
			Console.WriteLine( Messages.GREETING );
			Console.WriteLine( Messages.GUIDE );
		}
		
		public void processInput( string _input ){
			Console.Clear();
			if( _input == "" ){
				if( this.Game == null || !this.Game.IsActive ){
					Console.WriteLine( Messages.GUIDE );
				} else {
					Console.WriteLine( Messages.MOVE );
				}
				return;
			}
			string[] input = _input.Split(' ');
			switch( input[0] ){
				case Commands.NEW_GAME:
					int size = 4;
					if( input.Length >= 2 ){
						int.TryParse( input[1], out size );
						if( size < 2 ){
							size = 4;
						} else if( size % 2 == 1 ){
							size++;
						}
					}
					this.Game = new Game( size );
					Console.WriteLine( Messages.NEW_GAME );
					this.printGameField();
					Console.WriteLine( Messages.MOVE );
					break;
				case Commands.HELP:
					Console.WriteLine( Messages.HELP );
					break;
				case Commands.LIST:
					Console.WriteLine( Messages.LIST );
					List<string> commands = Commands.CommandsList;
					for( int i = 0; i < commands.Count; i++ ){
						Console.WriteLine( commands[i] );
					}
					break;
				case Commands.PRINT:
					if( this.Game == null ){
						Console.WriteLine( Messages.PRINT_NOGAME );
					} else if( !this.Game.IsActive ){
						Console.WriteLine( Messages.PRINT_NOACTIVE );
					} else {
						this.printGameField();
					}
					break;
				case Commands.EXIT:
					Console.WriteLine( Messages.FAREWELL );
					break;
				// MOVE
				default:
					if( this.Game == null || !this.Game.IsActive ){
						Console.WriteLine( Messages.GUIDE );
					} else if( this.Game.validateMove( int.Parse( input[0] ), int.Parse( input[1] ) ) ){
						this.printGameField();
						if( this.Game.guessIsCorrect() ){
							Console.WriteLine( Messages.GUESS_CORRECT );
							if( this.Game.IsActive ){
								Console.WriteLine( Messages.MOVE );
							} else {
								Console.WriteLine( Messages.WIN );
							}
						} else {
							Console.WriteLine( Messages.GUESS_INCORRECT );
							Console.WriteLine( Messages.MOVE );
						}
					} else {
						Console.WriteLine( Messages.ERROR );
					}
					break;
			}
		}
		
		
		private void printGameField(){
			string[,] field = this.Game.GameField;
			for( int i = 0; i < field.GetLength(0); i++ ){
				for( int j = 0; j < field.GetLength(1); j++ ){
					if( j > 0 ){
						Console.Write(" ");
					}
					Console.Write( field[i,j] );
				}
				Console.WriteLine();
			}
		}
	}
}
