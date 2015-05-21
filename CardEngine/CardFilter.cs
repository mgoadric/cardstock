using System.Collections.Generic;

namespace CardEngine{
	public class CardFilter{
		List<TreeDirections> filters;
		public CardFilter(List<TreeDirections> f){
			filters = f;
		}
		public bool CardConforms(Card c){
			foreach (var f in filters){
				if (!f.CardConforms(c)){
					return false;
				}
			}
			return true;
		}
		
	}
	public class TreeDirections {
		bool equal;
		List<int> traversals;
		string expectedValue;
		public TreeDirections(List<int> t, string s, bool e){
			traversals = t;
			expectedValue = s;
			equal = e;
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