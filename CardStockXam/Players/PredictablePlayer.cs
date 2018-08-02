﻿using System;
using System.Collections.Generic;
using FreezeFrame;
namespace Players
{
    /********
     * An AIPlayer that will make one defined move, and then player
     * randomly thereafter. Used by the PIPMCPlayer.
     */
    public class PredictablePlayer : AIPlayer
    {
        public bool firstMove = true;
        public int toChoose = -1;

        public PredictablePlayer (Perspective perspective, int choice) : base(perspective)
        { toChoose = choice; }

        /*********
         * The first time it is asked for a choice, it will know what to do,
         * then set its boolean flag false and be random
         */
        public override int MakeAction(List<GameActionCollection> possibles, Random rand)
        {
            
			if (firstMove)
			{

                firstMove = false;
				return toChoose;
			}

            return rand.Next(0, possibles.Count);
        }
    }
}