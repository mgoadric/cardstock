using System.Collections.Generic;

namespace CardEngine{
	public class CardFilter{
		public List<TreeDirections> filters;
		public CardFilter(List<TreeDirections> f){
			filters = f;
		}
		public CardFilter Copy(){
			var ret = new CardFilter(
				new List<TreeDirections>()
			);
			foreach (var f in filters){
				ret.filters.Add(f.Copy());
			}
			return ret;
		}
		public bool CardConforms(Card c){
			foreach (var f in filters){
				if (!f.CardConforms(c)){
					return false;
				}
			}
			return true;
		}
		public override string ToString(){
			string ret = "";
			foreach (var f in filters){
				ret += f.ToString();
			}
			return ret;
		}
	}
	public class TreeDirections {
		bool equal;
		List<int> traversals;
		public string expectedValue;
		public TreeDirections(List<int> t, string s, bool e){
			traversals = t;
			expectedValue = s;
			equal = e;
		}
		public TreeDirections Copy(){
			return new TreeDirections(this.traversals,this.expectedValue,this.equal);
		}
		public bool CardConforms(Card c){
			var desiredNode = c.attributes;
			foreach (var childNum in traversals){
				desiredNode = desiredNode.children[childNum];
			}
			return equal? desiredNode.Value == expectedValue : desiredNode.Value != expectedValue;
		}
	}
}