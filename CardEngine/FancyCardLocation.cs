namespace CardEngine{
	public class FancyCardLocation{
		public CardCollection cardList;
		public string locIdentifier;
		
		public CardFilter filter;
		public void Add(Card c){
			if (locIdentifier == "top"){
				cardList.Add(c);
			}
			else if (locIdentifier == "bottom"){
				
			}
		}
		public int FilteredCount(){
			if (filter != null){
				var temp = filter.FilterMatchesAll(cardList);
				return temp.Count;
			}
			return cardList.Count;
		}
		public Card Get(){
			if (filter != null){
				var temp = filter.FilterMatchesAll(cardList);
				if (locIdentifier == "top"){
					return temp.Peek();
				}
				else if (locIdentifier == "bottom"){
					return temp.AllCards().GetEnumerator().Current;
				}
			}
			if (locIdentifier == "top"){
				return cardList.Peek();
			}
			else if (locIdentifier == "bottom"){
				return cardList.AllCards().GetEnumerator().Current;
			}
			return null;
		}
		public CardCollection FilteredList(){
			if (filter != null){
				var temp = filter.FilterMatchesAll(cardList);
				return temp;
			}
			return cardList;
		}
		public Card Remove(){
			if (filter != null){
				var temp = filter.FilterMatchesAll(cardList);
				if (locIdentifier == "top"){
					return temp.Remove();
				}
				else if (locIdentifier == "bottom"){
					return temp.AllCards().GetEnumerator().Current;
				}
			}
			if (cardList.Count != 0){
				if (locIdentifier == "top"){
					return cardList.Remove();
				}
				else if (locIdentifier == "bottom"){
					return cardList.Remove();
				}
			}
			return null;
		}
	}	
}