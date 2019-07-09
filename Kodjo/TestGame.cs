using System;
using NUnit.Framework;

namespace Kodjo
{
	[TestFixture]
	public class TestGame
	{
		[Test]
		public void testFieldCreation(){
			String[,] field = ( new Game(6) ).GameField;
			for( int i = 0; i < field.GetLength(0); i++ ){
				if( i > 0 ){
					Console.WriteLine();
				}
				for( int j = 0; j < field.GetLength(1); j++ ){
					if( j > 0 ){
						Console.Write(" ");
					}
					Console.Write( field[i,j] );
				}
			}
		}
		
		[Test]
		public void testMove(){
			Game game = new Game(6);
			string valid = ( game.validateMove( 1, 13 ) ) ? "valid" : "invalid";
			Console.WriteLine( "1, 13 - {0}", valid );
			valid = ( game.validateMove( 15, -3 ) ) ? "valid" : "invalid";
			Console.WriteLine( "15, -3 - {0}", valid );
		}
	}
}
