using System;
using System.Collections.Generic;

namespace CardStock.Players
{
    /********
     * An AIPlayer that will choose a random action from their options
     */
    public class RandomPlayer(Perspective perspective) : AIPlayer(perspective)
    {

        private int numChoices;

        public override void Explore(int numChoices)
        {
            this.numChoices = numChoices;
        }
        
        /*****
         * Use the provided RNG to pick a random action
         */
        public override int Choose()
        {
            return ThreadSafeRandom.Next(0, numChoices);
        }
    }
}
