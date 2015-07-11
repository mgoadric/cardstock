using System.Collections.Generic;

namespace CardEngine{
	public class BooleanFilter{
		List<TFilter> filters = new List<TFilter>();
		public BooleanFilter(){
			
		}
		public bool TruthValue(){
			return true;
		}
	}
	public class TFilter{
		public bool all = true;
		public bool negate = false;
		
		public bool CardMatches(Card c){
			return (!negate)&&all;
		}
	}
}