using System.Collections.Generic;
namespace CardEngine{
	public class Card{
		Dictionary<string,string> attributes; 
		public Card(Dictionary<string,string> atts){
			attributes = atts;
		}
		public override string ToString(){
			string ret = "";
			foreach (var key in attributes.Keys){
				ret += " " + attributes[key];
			}
			return ret;
		}
	}
}