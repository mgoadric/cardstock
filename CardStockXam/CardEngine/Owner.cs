using System;
using System.Text;
using System.Collections.Generic;
namespace CardEngine
{
    public class Owner
    {
        public DefaultStorage<int> intBins;
        public Dictionary<CCType, DefaultStorage<CardCollection>> cardBins;
        public DefaultStorage<string> stringBins;
        public DefaultStorage<PointMap> pointBins; 

        public readonly string name;
        public readonly int id;

        public Owner(string name, int id)
        {
            intBins = new DefaultStorage<int>(0, this);
            stringBins = new DefaultStorage<string>("", this);
            pointBins = new DefaultStorage<PointMap>(new PointMap(new List<PointAwards>()), this); 
            cardBins = new Dictionary<CCType, DefaultStorage<CardCollection>>();
            foreach (CCType type in Enum.GetValues(typeof(CCType))) {
                if (type != CCType.VIRTUAL)
                {
                    cardBins[type] = new DefaultStorage<CardCollection>(
                          new CardListCollection(type, this), this);
                }
            }

            this.name = name;
            this.id = id;
        }

        // http://blog.chrishowie.com/2013/01/22/object-copying-in-c/
        public Owner Clone()
        {
            return CloneImpl();
        }

        protected virtual Owner CloneImpl() 
        {
            Owner other = new Owner(name, id);
            other.intBins = intBins.Clone(other);
            other.stringBins = stringBins.Clone(other);
            other.pointBins = pointBins.Clone(other);
            other.cardBins = new Dictionary<CCType, DefaultStorage<CardCollection>>();
            foreach (CCType type in Enum.GetValues(typeof(CCType)))
            {
                if (type != CCType.VIRTUAL)
                {
                    other.cardBins[type] = cardBins[type].HollowClone(other);
                }
            }
            return other;
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder(GetType().ToString() + ":\n");
            ret.Append(cardBins.ToString());
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

            if (name != otherplayer.name)
            { return false; }

            return true;
        }
/*
        public override int GetHashCode() // XORs relevant hashcodes
        {
            return name.GetHashCode() ^ team.GetHashCode() ^ intBins.GetHashCode() ^ cardBins.GetHashCode();
        }

*/  }
}
