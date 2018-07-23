using System;
using System.Text;
using Players;
namespace CardEngine
{
    public class Owner
    {
        public IntStorage storage;
        public CardStorage cardBins;
        public string name;

        public Owner()
        {
            storage = new IntStorage();
            cardBins = new CardStorage();
            cardBins.owner = this;
        }
        public Owner Clone()
        {
            Owner other = new Owner();
            other.storage = storage.Clone();
            other.cardBins = cardBins.Clone();
            other.name = name;
            other.cardBins.owner = other;
            return other;
        }
        public override string ToString()
        {
            StringBuilder ret = new StringBuilder("Owner:\n");
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

            if (!(storage.Equals(otherplayer.storage)) || !(cardBins.Equals(otherplayer.cardBins)))
            { return false; }

            if (name != otherplayer.name || team.id != otherplayer.team.id)
            { return false; }

            return true;
        }

        public override int GetHashCode() // XORs relevant hashcodes
        {
            return name.GetHashCode() ^ team.GetHashCode() ^ storage.GetHashCode() ^ cardBins.GetHashCode();
        }

    }
}
