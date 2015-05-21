using System.Collections.Generic;
namespace CardEngine{
	public class Card{
		public Node attributes;
		public Card(Node atts){
			attributes = atts;
		}
		public override string ToString(){
			string ret = attributes.ToString();
			return ret;
		}
	}
}