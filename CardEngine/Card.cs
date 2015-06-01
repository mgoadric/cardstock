using System;
using System.Collections.Generic;
namespace CardEngine{
	public class Card{
		private Dictionary<string,TreeTraversal> mapAttributes = new Dictionary<string,TreeTraversal>();
		public Node attributes;
		public Card(Node atts){
			attributes = atts;
			CreateTraversals();
		}
		private void CreateTraversals(){
			for (int i = 0; i < attributes.children.Count; ++i){
				Create(attributes.children[i], new List<int>{i});
			}
		}
		private void Create(Node spot,List<int> directions){
			
			if (spot != null&&spot.Key != null&&!mapAttributes.ContainsKey(spot.Key)){
				mapAttributes.Add(spot.Key,new TreeTraversal(directions));
				if (spot.children != null){
					
					for (int i = 0; i < spot.children.Count; ++i){
						var passOnList = new List<int>(directions);
						passOnList.Add(i);
						Create(spot,passOnList);
					}
				}
			}
		}
		public override string ToString(){
			string ret = attributes.ToString();
			return ret;
		}
		public string ReadAttribute(string attributeName){
			return mapAttributes[attributeName].ReadValue(this);
		}
	}
}