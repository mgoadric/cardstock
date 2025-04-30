using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;

namespace CardStock.CardEngine{
	public class Card{

        private readonly Dictionary<string, string> cardAtts;
		public CardCollection owner {get; set;}
        public readonly int id;
        public String name;

		public Card(Dictionary<string, string> atts, int id, String n){
            cardAtts = atts;
            this.id = id;
            this.name = n;
		}

		public Card Clone(){
            return new Card(cardAtts, id, name);;
		}

		public override string ToString(){
            //https://stackoverflow.com/questions/3871760/convert-dictionarystring-string-to-semicolon-separated-string-in-c-sharp
            return string.Join(";", cardAtts.Select(x => x.Key + "=" + x.Value)) + name;
		}

        public override bool Equals(object obj)
        {
            return Equals(obj as Card);
        }

        public bool Equals(Card c)
        {
            /*if(obj == null)
            { return false; }
            Card p = obj as Card;
            if (p == null)
            { return false; }*/

            if ((c.id != this.id) || (c.name != this.name)) 
            { return false; }

            return true; 
        }

        public override int GetHashCode() 
        {
            return ToString().GetHashCode(); 
        }

		public string ReadAttribute(string attributeName){
			
			try{
				return cardAtts[attributeName];
			}
			catch{
				Debug.WriteLine("KEYS");
				foreach (var key in cardAtts.Keys){
					Debug.WriteLine(key);
				}
				return "";
			}
		} 
    }
}
