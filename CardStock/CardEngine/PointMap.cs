using System.Diagnostics;

namespace CardStock.CardEngine
{
    public readonly struct PointMap : ICloneable
    {

        private readonly Dictionary<string, Dictionary<string, int>> pointLookups;

        public PointMap(List<ValueTuple<string, string, int>> input)
        {

            pointLookups = [];
            foreach (var award in input)
            {
                if (pointLookups.TryGetValue(award.Item1, out Dictionary<string, int>? value))
                {
                    if (!value.TryAdd(award.Item2, award.Item3))
                    {
                        value[award.Item2] += award.Item3;
                    }
                }
                else
                {
                    pointLookups[award.Item1] = new Dictionary<string, int>{
                        {award.Item2, award.Item3}
                    };
                }
            }
        }

        public int GetScore(Card c)
        {
            int total = 0;
            foreach (var key in pointLookups.Keys)
            {
                var arrAtts = key.Split(',');
                var attStr = "";
                foreach (var att in arrAtts)
                {
                    Debug.WriteLine("Card: " + c);
                    var val = c.ReadAttribute(att);
                    attStr += val + ",";
                }
                attStr = attStr[..^1];
                if (pointLookups[key].TryGetValue(attStr, out int value))
                {
                    total += value;
                }
            }
            return total;
        }

        // This is a readonly struct, so no cloning necessary.
        public object Clone()
        {
            return this;
        }

        public override bool Equals(object? obj)
        {

            if (obj is null)
            { return false; }

            if (obj is not PointMap p)
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
        public static bool operator ==(PointMap left, PointMap right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PointMap left, PointMap right)
        {
            return !(left == right);
        }
    }
}