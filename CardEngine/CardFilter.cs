using System.Collections.Generic;

namespace CardEngine{
	public class CardFilter{
		public List<TreeExpression> filters;
		public CardFilter(List<TreeExpression> f){
			filters = f;
		}
		public CardFilter Copy(){
			var ret = new CardFilter(
				new List<TreeExpression>()
			);
			foreach (var f in filters){
				ret.filters.Add(f.Copy());
			}
			return ret;
		}
		public CardCollection FilterMatchesAll(CardCollection cards){
			var ret = new CardListCollection();
			foreach (var c in cards.AllCards()){
				if (CardConforms(c)){
					ret.Add(c);
				}
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
	public class TreeExpression {
		bool equal;
		TreeTraversal traversals;
		public string expectedValue;
		public string indexLabel;
		public TreeExpression(List<int> t, string s, bool e, string iLabel){
			traversals = new TreeTraversal(t);
			expectedValue = s;
			equal = e;
			indexLabel = iLabel;
		}
		public TreeExpression Copy(){
			return new TreeExpression(this.traversals.traversals,this.expectedValue,this.equal,this.indexLabel);
		}
		public bool CardConforms(Card c){
			var desiredValue = traversals.ReadValue(c);
			return equal? desiredValue == expectedValue : desiredValue != expectedValue;
		}
	}
	public class TreeTraversal{
		public List<int> traversals;
		public TreeTraversal(List<int> t){
			traversals = t;
		}
		public string ReadValue(Card c){
			var desiredNode = c.attributes;
			foreach (var childNum in traversals){
				desiredNode = desiredNode.children[childNum];
			}
			return desiredNode.Value;
		}
	}
}