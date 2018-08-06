using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace CardEngine
{
    /**********
     * The Owner class holds all of the data for the Table, Players,
     * and Teams. CardCollections, Integers, Strings, and PointMaps are 
     * implemented with a DefaultStorage to make them always
     * available.
     */
    public class Owner
    {
        // A place for integers, for chips, bids, bets, in-game points
        public DefaultStorage<int> intBins;

        // Can make string values saved. 
        // TODO Add this to Recycle
        public DefaultStorage<string> stringBins;

        // Anyone can have their own pointmaps to localize card scoring. 
        // TODO Add this to Recycle
        public DefaultStorage<PointMap> pointBins; 

        // Set up four default dictionaries, one for each type of card
        // an Owner can have, VISIBLE, INVISIBLE, HIDDEN, and MEMORY
        public Dictionary<CCType, CardStorage> cardBins;

        public readonly string name;  // A string for easy printing
        public readonly int id;   // index of Owner in the CardGame list for its type

        public Owner(string name, int id)
        {
            // Use 0, "", and an empty PointMap for defaults
            intBins = new DefaultStorage<int>(0, this);
            stringBins = new DefaultStorage<string>("", this);
            pointBins = new DefaultStorage<PointMap>(new PointMap(new List<ValueTuple<string, string, int>>()), this); 

            cardBins = new Dictionary<CCType, CardStorage>();
            foreach (CCType type in Enum.GetValues(typeof(CCType))) {
                if (type != CCType.VIRTUAL)
                {
                    cardBins[type] = new CardStorage(
                          new CardCollection(type), this);
                }
            }

            // Record the name and id
            this.name = name;
            this.id = id;
        }


        // We only want to clone the actual values for the int, string, and 
        // PointMap bins, the CardCollection bins should be hollow
        // so the cards can be filled in from the sourceDeck of the CardGame
        public Owner Clone()
        {
            var other = new Owner(name, id);
            other.intBins = intBins.Clone(other);
            other.stringBins = stringBins.Clone(other);
            other.pointBins = pointBins.Clone(other);
            other.cardBins = new Dictionary<CCType, CardStorage>();
            foreach (CCType type in Enum.GetValues(typeof(CCType)))
            {
                if (type != CCType.VIRTUAL) 
                {
                    other.cardBins[type] = cardBins[type].Clone(other);
                }
            }
            return other;
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder(); // GetType().ToString() + ":\n");
            ret.Append("Name: " + name + " | ID: " + id.ToString() + "\r\n");
            ret.Append("Listing Storages...\r\n");
            foreach(CCType type in cardBins.Keys)
            {
                ret.Append(cardBins[type].ToString());
            }
            ret.Append(intBins.ToString());
            ret.Append(pointBins.ToString());
            return ret.ToString();
        }

        public override bool Equals(System.Object obj) // USE THIS AS GENERAL OWNER CHECK --
        {
            
            if (obj == null)
            { Console.WriteLine("owner is null"); return false; }
           
            Owner otherowner = obj as Owner;
            if (otherowner == null)
            { Console.WriteLine("owner as owner is null"); return false; }

            if (GetType() != otherowner.GetType())
            { Console.WriteLine("Types not equal"); return false; }

            if (this as Player != null && otherowner as Player != null)
            {
                Player thisplayer = this as Player; Player otherplayer = otherowner as Player;
                if (thisplayer.team.id != otherplayer.team.id)
                { Console.WriteLine("Player Specific Owner failure");
                       return false; }
            }

            if (this as Team != null && otherowner as Team != null)
            {
                Team thisteam = this as Team; Team otherteam = otherowner as Team;
                if (!thisteam.teamPlayers.SequenceEqual(otherteam.teamPlayers))
                { Console.WriteLine("Team specific owner failure");
                    return false; }
            }
            //SPECIAL THINGS FOR OTHER OWNERS??

            if (!(intBins.Equals(otherowner.intBins)))
            { //Console.WriteLine("owner intBins not equal");
                return false; }
            
            if (!(stringBins.Equals(otherowner.stringBins)))
            { //Console.WriteLine("owner stringbins not equal");
                return false; }

            foreach (CCType type in Enum.GetValues(typeof(CCType)))
            {
                if (type != CCType.VIRTUAL)
                {
                    if (!otherowner.cardBins[type].Equals(cardBins[type]))
                    { //Console.WriteLine("Owner Cardbin " + type.ToString() + " not equal.");
                        return false; }
                }
            }
            
            if (!(pointBins.Equals(otherowner.pointBins)))
            { //Console.WriteLine("owner pointbins not equal");
                return false; }
            
            if (name != otherowner.name)
            { //Console.WriteLine("owner names not equal");
                return false; }
            
            if (id != otherowner.id)
            { //Console.WriteLine("owner ids not equal");
                return false; }

            return true;
        }

        public override int GetHashCode() 
        {
            int hash = 0;
            hash ^= name.GetHashCode() ^ id.GetHashCode() ^ intBins.GetHashCode();
            hash ^= stringBins.GetHashCode() ^ pointBins.GetHashCode();
            foreach(CCType type in Enum.GetValues(typeof(CCType)))
            {
                if (type != CCType.VIRTUAL) { hash ^= cardBins[type].GetHashCode(); }
            }
            return hash;
        }
       
    }
}
