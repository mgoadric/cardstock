using System;
using System.Collections.Generic;
namespace CardEngine{
    public readonly struct PointMap : ICloneable{

		public readonly Dictionary<string,Dictionary<string,int>> pointLookups;
		public PointMap(List<PointAwards> input){

            pointLookups = new Dictionary<string, Dictionary<string, int>>();
			foreach (var award in input){
				if (pointLookups.ContainsKey(award.identifier)){
					if (pointLookups[award.identifier].ContainsKey(award.value)){
						pointLookups[award.identifier][award.value] += award.pointsToAward;
					}
					else{
						pointLookups[award.identifier].Add(award.value,award.pointsToAward);
					}
				}
				else{
					pointLookups[award.identifier] = new Dictionary<string,int>{
						{award.value, award.pointsToAward}
					};
				}
			}
		}

		public int GetScore(Card c){
			int total = 0;
			foreach (var key in pointLookups.Keys){
				var arrAtts = key.Split(',');
				var attStr = "";
				foreach (var att in arrAtts){
                    System.Diagnostics.Debug.WriteLine("Card: " + c);
					var val = c.ReadAttribute(att);
					attStr += val + ",";
				}
				attStr = attStr.Substring(0,attStr.Length - 1);
				if (pointLookups[key].ContainsKey(attStr)){
					total += pointLookups[key][attStr];
				}
			}
			return total;
		}

        // This is a readonly struct, so no cloning necessary.
        public object Clone() {
            return this;
        }

        public override bool Equals(System.Object obj)
        {

            if (obj == null)
            { return false; }

            if (!(obj is PointMap p))
            { return false; }

            if (pointLookups.Count != p.pointLookups.Count)
            { return false; }

            foreach (string key in pointLookups.Keys)
            {
                var otherscores = p.pointLookups[key];
                if (otherscores.Count != p.pointLookups[key].Count)
                { return false; }

                foreach (string key2 in pointLookups[key].Keys)
                {
                    if (otherscores[key2] != pointLookups[key][key2]) 
                        { return false; }  
                }
            }

            return true;

        }

        public override int GetHashCode()
        {
            int hash = 0;
            foreach (string key in pointLookups.Keys)
            {
                hash ^= key.GetHashCode();
                foreach (string key2 in pointLookups[key].Keys)
                {
                    hash ^= key2.GetHashCode();
                    hash ^= pointLookups[key][key2].GetHashCode();
                }
            }
            return hash;
        }

    }

    // TODO Can we get rid of this with a Tuple<string, string, int> ???
	public class PointAwards{
		public readonly string identifier;
		public readonly string value;
		public readonly int pointsToAward;
		public PointAwards(string identifier, string value, int p){
			this.identifier = identifier;
			this.value = value;
			pointsToAward = p;
		}
		
        public override bool Equals(System.Object obj)
        {
            if (obj ==null)
            {
                return false;
            }
            PointAwards p = obj as PointAwards;
            if ((System.Object)p == null)
            {
                return false;
            }

            return ((identifier == p.identifier) && (value == p.value) && (pointsToAward == p.pointsToAward));
        }

        public override int GetHashCode()
        {
            return identifier.GetHashCode() ^ value.GetHashCode() ^ pointsToAward;
        }

    }
}