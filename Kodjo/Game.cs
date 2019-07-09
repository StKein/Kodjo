using System;
using System.Collections.Generic;

namespace Kodjo
{
	public class Game
	{
		private int remainingPairs;
		private string[,] Field;
		private Random Random;
		private int[,] Move;
		private readonly int ItemSize;
		
		public int RemainingPairs{ get{ return this.remainingPairs; } }
		public bool IsActive{ get{ return ( this.remainingPairs > 0 ); } }
		public string[,] GameField{
			get{
				string[,] field = new String[ this.Field.GetLength(0), this.Field.GetLength(1) ];
				for( int i = 0; i < this.Field.GetLength(0); i++ ){
					for( int j = 0; j < this.Field.GetLength(1); j++ ){
						if(
							this.Field[i,j] == ""  || 
							i == this.Move[0,0] && j == this.Move[0,1] ||
							i == this.Move[1,0] && j == this.Move[1,1]
						  ) {
							field[i,j] = this.Field[i,j];
						} else {
							field[i,j] = ( i * this.Field.GetLength(1) + j + 1 ) + "";
						}
						while( field[i,j].Length < this.ItemSize ){
							field[i,j] = " " + field[i,j];
						}
					}
				}
				
				return field;
			}
		}
		
		
		public Game( int _size ){
			if( _size % 2 == 1 ){
				_size++;
			}
			if( _size < 2 ){
				throw new Exception( "Incorrect field size!" );
			}
			
			this.Random = new Random( DateTime.Now.Millisecond );
			this.Field = new String[ _size, _size ];
			this.remainingPairs = _size * _size / 2;
			this.Move = new int[2,2]{ { -1, -1 }, { -1, -1 } };
			this.ItemSize = 3;
			
			this.setField();
		}
		
		
		public bool validateMove( int _id1, int _id2 ){
			if(
				_id1 <= 0 || _id1 > this.Field.GetLength(0) * this.Field.GetLength(1) || 
				_id2 <= 0 || _id2 > this.Field.GetLength(0) * this.Field.GetLength(1)
			){
				return false;
			}
			
			this.Move[0,0] = ( _id1 - 1 ) / this.Field.GetLength(1);
			this.Move[0,1] = ( _id1 - 1 ) % this.Field.GetLength(1);
			this.Move[1,0] = ( _id2 - 1 ) / this.Field.GetLength(1);
			this.Move[1,1] = ( _id2 - 1 ) % this.Field.GetLength(1);
			
			return true;
		}
		
		public bool guessIsCorrect(){
			if( this.Field[ this.Move[0,0], this.Move[0,1] ].Equals( this.Field[ this.Move[1,0], this.Move[1,1] ] ) ){
				this.Field[ this.Move[0,0], this.Move[0,1] ] = "";
				this.Field[ this.Move[1,0], this.Move[1,1] ] = "";
				this.remainingPairs--;
				return true;
			} else {
				return false;
			}
		}
		
		
		private void setField(){
			List<string> items = new List<string>();
			string item = "";
			for( int i = 0; i < this.remainingPairs; i++ ){
				do {
					item = this.generateItem();
				} while( items.Contains( item ) );
				
				this.addItemToField( item );
			}
		}
		
		private string generateItem(){
			string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			char[] string_chars = new char[ this.ItemSize ];
			for( int i = 0; i < this.ItemSize; i++ ){
				string_chars[i] = chars[ this.Random.Next( chars.Length ) ];
			}
			
			return new string( string_chars );
		}
		
		private void addItemToField( string _item ){
			int row = 0;
			int col = 0;
			
			do {
				row = this.Random.Next( this.Field.GetLength(0) );
				col = this.Random.Next( this.Field.GetLength(1) );
			} while( this.Field[ row, col ] != null );
			this.Field[ row, col ] = _item;
			
			do {
				row = this.Random.Next( this.Field.GetLength(0) );
				col = this.Random.Next( this.Field.GetLength(1) );
			} while( this.Field[ row, col ] != null );
			this.Field[ row, col ] = _item;
		}
	}
}
