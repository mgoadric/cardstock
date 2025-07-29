﻿using System.Text;

namespace CardStock.CardEngine
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
        public CardStorage cardBins;

        public readonly string name;  // A string for easy printing
        public readonly int id;   // index of Owner in the CardGame list for its type

        public Owner(string name, int id)
        {
            // Use 0, "", and an empty PointMap for defaults
            intBins = new DefaultStorage<int>(0, this);
            stringBins = new DefaultStorage<string>("", this);
            pointBins = new DefaultStorage<PointMap>(new PointMap([]), this); 
            cardBins = new CardStorage(this);

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
            other.cardBins = new CardStorage(other);
            return other;
        }

        public override string ToString()
        {
            StringBuilder ret = new(); // GetType().ToString() + ":\n");
            ret.Append("Name: " + name + " | ID: " + id.ToString() + "\r\n");
            ret.Append("Listing Storages...\r\n");
            ret.Append(cardBins.ToString());
            ret.Append(intBins.ToString());
            ret.Append(pointBins.ToString());
            return ret.ToString();
        }

        public override bool Equals(object? obj) // USE THIS AS GENERAL OWNER CHECK --
        {
            if (obj != null)
            {
                return BetterEquals(obj, false, -1);
            }
            return false;
        }

        public bool BetterEquals(object obj, bool infoset, int playeridx) { 
            if (obj == null)
            { Console.WriteLine("owner is null"); return false; }
           
            if (obj is not Owner otherowner)
            { Console.WriteLine("owner as owner is null"); return false; }

            if (GetType() != otherowner.GetType())
            { Console.WriteLine("Types not equal"); return false; }

            if (this is Player thisplayer && otherowner is Player otherplayer)
            {
                if (thisplayer.team.id != otherplayer.team.id)
                { Console.WriteLine("Player Specific Owner failure");
                       return false; }
            }

            if (this is Team thisteam && otherowner is Team otherteam)
            {
                for (int i = 0; i < thisteam.teamPlayers.Count; i++)
                {
                    if (thisteam.teamPlayers[i].id != otherteam.teamPlayers[i].id)
                    {
                        //Console.WriteLine("Team player id's not the same");
                        return false;
                    }
                }
            }
            //SPECIAL THINGS FOR OTHER OWNERS??

            if (!(intBins.Equals(otherowner.intBins)))
            { //Console.WriteLine("owner intBins not equal");
                return false; }
            
            if (!(stringBins.Equals(otherowner.stringBins)))
            { //Console.WriteLine("owner stringbins not equal");
                return false;
            }

            if (infoset) {
                if (!cardBins.InfoSetEqual(otherowner.cardBins, playeridx))
                    { return false; } 
            } else if (!(cardBins.Equals(otherowner.cardBins)))
            { //Console.WriteLine("owner stringbins not equal");
                return false;
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
            //Console.WriteLine("Passed all team equality checks.");
            return true;
        }

        public override int GetHashCode() 
        {
            return GetBetterHashCode(false, -1);
        } 
        
        public int GetBetterHashCode(bool infoset, int playeridx)
        {
            int hash = 0;
            hash ^= name.GetHashCode() ^ id.GetHashCode() ^ intBins.GetHashCode();
            hash ^= stringBins.GetHashCode() ^ pointBins.GetHashCode();

            if (infoset)
            {
                hash ^= cardBins.GetInfoSetHashCode(playeridx);
            }
            else
            {
                hash ^= cardBins.GetHashCode();
            }

            return hash;
        }
    }
}
