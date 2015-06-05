using System.Collections.Generic;

namespace CardEngine{
	public class CardFilter{
		public List<CardExpression> filters;
		public CardFilter(List<CardExpression> f){
			filters = f;
		}
		public CardFilter Copy(){
			var ret = new CardFilter(
				new List<CardExpression>()
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
	public abstract class CardExpression{
		public abstract CardExpression Copy();
		public abstract bool CardConforms(Card c);
	}
	
	public class ScoreExpression : CardExpression{
		CardScore scorer;
		string oper;
		int TargetValue;
		public ScoreExpression(CardScore scorer, string op, int targetValue){
			this.scorer = scorer;
			oper = op;
			TargetValue = targetValue;
		}
		public override CardExpression Copy(){
			return this;
		}
		public override bool CardConforms(Card c){
			if (oper == ">="){
				return scorer.GetScore(c) >= TargetValue;
			}
			else if (oper == "<="){
				return scorer.GetScore(c) <= TargetValue;
			}
			return false;
		}
	}
	
	public class TreeExpression : CardExpression {
		public string CardAttribute;
		bool equal;
		public string expectedValue;
		
		public TreeExpression(string cardAttribute, string s, bool e){
			
			CardAttribute = cardAttribute;
			expectedValue = s;
			equal = e;
			
		}
		public override CardExpression Copy(){
			return new TreeExpression(CardAttribute,this.expectedValue,this.equal);
		}
		public override bool CardConforms(Card c){
			var desiredValue = c.ReadAttribute(CardAttribute);
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