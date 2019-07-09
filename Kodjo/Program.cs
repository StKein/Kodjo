
using System;

namespace Kodjo
{
	class Program
	{
		public static void Main(string[] args)
		{
			GameMaster gm = new GameMaster();
			string input = "";
			do{
				input = Console.ReadLine();
				gm.processInput( input );
			} while( input != Commands.EXIT );
			Console.ReadKey();
		}
	}
}