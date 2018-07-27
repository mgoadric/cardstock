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

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Card);
        }

        public bool Equals(Card p)
        {
            /*if(obj == null)
            { return false; }
            Card p = obj as Card;
            if (p == null)
            { return false; }*/

            if (p.ToOutputString() != ToOutputString()) 
            { return false; }

            return true; 
        }

        public override int GetHashCode() 
        {
            return ToOutputString().GetHashCode(); 
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

    public class TreeTraversal
    {
        public List<int> traversals;
        public TreeTraversal(List<int> t)
        {
            traversals = t;
        }
        public string ReadValue(Card c)
        {
            var desiredNode = c.attributes;
            foreach (var childNum in traversals)
            {
                desiredNode = desiredNode.children[childNum];
            }
            return desiredNode.Value;
        }
    }

}