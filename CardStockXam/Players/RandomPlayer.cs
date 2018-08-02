using System;
using System.Collections.Generic;
using FreezeFrame;

namespace Players
{
    /********
     * An AIPlayer that will choose a random action from their options
     */
    public class RandomPlayer : AIPlayer
    {
        public RandomPlayer(Perspective perspective) : base(perspective) { }

        /*****
         * Use the provided RNG to pick a random action
         */
        public override int MakeAction(List<GameActionCollection> possibles, Random rand)
        {

            return rand.Next(0,possibles.Count);
        }
    }
}
