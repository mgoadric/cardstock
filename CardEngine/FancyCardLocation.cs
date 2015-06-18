namespace CardEngine{
	public class FancyCardLocation{
		CardCollection cardList;
		string locIdentifier;
		
		public FancyCardLocation(CardCollection c, string locIdent){
			cardList = c;
			locIdentifier = locIdent;
		}
		public void Add(Card c){
			if (locIdentifier == "top"){
				cardList.Add(c);
			}
			else if (locIdentifier == "bottom"){
				
			}
		}
		public Card Get(){
			
			if (locIdentifier == "top"){
				return cardList.Peek();
			}
			else if (locIdentifier == "bottom"){
				return cardList.AllCards().GetEnumerator().Current;
			}
			return null;
		}
		public Card Remove(){
			if (locIdentifier == "top"){
				return cardList.Remove();
			}
			else if (locIdentifier == "bottom"){
				return cardList.Remove();
			}
			return null;
		}
	}	
}