using System;
using System.Text;
using System.Collections.Generic;
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
            pointBins = new DefaultStorage<PointMap>(new PointMap(new List<PointAwards>()), this); 

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


        // Trying to make the Clone useful in the subclasses of Player and Team
        // http://blog.chrishowie.com/2013/01/22/object-copying-in-c/
        public Owner Clone()
        {
            return CloneImpl();
        }

        // We only want to clone the actual values for the int, string, and 
        // PointMap bins, the CardCollection bins should be hollow
        // so the cards can be filled in from the sourceDeck of the CardGame
        protected virtual Owner CloneImpl() 
        {
            Owner other = new Owner(name, id);
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
            StringBuilder ret = new StringBuilder(GetType().ToString() + ":\n");
            ret.Append(cardBins.ToString());
            // TODO
            // intBins
            // stringBins
            // pointBins
            return ret.ToString();
        }

        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            { return false; }

            Owner otherplayer = obj as Owner;
            if ((System.Object)otherplayer == null)
            { return false; }

            if (!(intBins.Equals(otherplayer.intBins)) || !(cardBins.Equals(otherplayer.cardBins)))
            { return false; }

            // TODO
            // stringBins
            // pointBins

            if (name != otherplayer.name)
            { return false; }

            return true;
        }
/*
        public override int GetHashCode() // XORs relevant hashcodes
        {
            return name.GetHashCode() ^ id.GetHashCode() ^ intBins.GetHashCode() ^ cardBins.GetHashCode();
            // TODO
            // stringBins
            // pointBins


        }

*/  }
}
