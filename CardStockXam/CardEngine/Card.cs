using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
namespace CardEngine{
	public class Card{
		private Dictionary<string,TreeTraversal> mapAttributes = new Dictionary<string,TreeTraversal>();
		public CardCollection owner {get; set;}
		public Node attributes;
		public Card(Node atts){
			attributes = atts;
			CreateTraversals();
		}


		public Card Clone(){
			Card ret = new Card (attributes);
			return ret;
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

        public override bool Equals(System.Object obj)
        {
            if(obj == null)
            {
                return false;
            }
            PointsStorage p = obj as PointsStorage;
            if ((System.Object)p == null)
            {
                return false;
            }


            if (p.ToString() != this.ToString()) 
            {
                return false;
            }

            return true; // Returns that strings are equal
        }

        public override int GetHashCode() 
        {
            return this.ToString().GetHashCode(); // unless the attributes.toString() causes some problem
        }

        public string ToOutputString()
        {
            return attributes.ToOutputString();
        }
        public string Serialize(){
			return attributes.Serialize ();
		}
		public string ReadAttribute(string attributeName){
			
			try{
				return mapAttributes[attributeName].ReadValue(this);
			}
			catch{
				Debug.WriteLine("KEYS");
				foreach (var key in mapAttributes.Keys){
					Debug.WriteLine(key);
				}
				throw;
			}
		}
	}
}