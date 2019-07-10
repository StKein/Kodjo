using System;
using System.Collections.Generic;

namespace Kodjo
{
	public abstract class TextStorage
	{
		public abstract string Language{ get; }
		
		
		public TextStorage(){}
		
		
		public List<string> getCommandsGuide(){
			List<string> guide = new List<string>();
			foreach( var constant in typeof( Commands ).GetFields() ){
				if( constant.IsLiteral && !constant.IsInitOnly ){
					string command = (string)constant.GetValue(null);
					string description = this.getCommandDescription( command );
					if( command.Equals( Commands.LANGUAGE ) ){
						description += this.getLanguagesConcat();
					}
					guide.Add( command + " - " + description );
				}
			}
			
			return guide;
		}
		
		
		protected string getLanguagesConcat(){
			string concat = "";
			foreach( var constant in typeof( Languages ).GetFields() ){
				if( constant.IsLiteral && !constant.IsInitOnly ){
					if( !concat.Equals("") ){
						concat += ", ";
					}
					concat += (string)constant.GetValue(null);
				}
			}
			
			return concat;
		}
		
		
		public abstract string getMessage( string _type );
		public abstract string getCommandDescription( string _command );
	}
}
