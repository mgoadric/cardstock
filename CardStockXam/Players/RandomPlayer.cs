using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreezeFrame;

namespace Players
{
    public class RandomPlayer : AIPlayer
    {
        public RandomPlayer(GameIterator m) : base(m) { }

        public override int MakeAction(List<GameActionCollection> possibles, Random rand)
        {
            return rand.Next(0,possibles.Count);
        }
    }
}
