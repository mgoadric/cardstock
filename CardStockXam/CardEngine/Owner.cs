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
        public string name;

        public Owner()
        {
            intBins = new DefaultStorage<int>(0, this);
            cardBins = new Dictionary<CCType, DefaultStorage<CardCollection>>();
            foreach (CCType type in Enum.GetValues(typeof(CCType))) {
                if (type != CCType.VIRTUAL)
                {
                    cardBins[type] = new DefaultStorage<CardCollection>(
                          new CardListCollection(type), this);
                }
            }
            stringBins = new DefaultStorage<string>("", this);
        }
        public Owner Clone()
        {
            Owner other = new Owner
            {
                intBins = intBins.Clone(),
                cardBins = new Dictionary<CCType, DefaultStorage<CardCollection>>(),
                name = name
            };
            foreach (CCType type in Enum.GetValues(typeof(CCType)))
            {
                if (type != CCType.VIRTUAL)
                {
                    other.cardBins[type] = cardBins[type].Clone();
                    other.cardBins[type].owner = other;
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

        public override int GetHashCode() // XORs relevant hashcodes
        {
            return name.GetHashCode() ^ team.GetHashCode() ^ intBins.GetHashCode() ^ cardBins.GetHashCode();
        }

    }
}
