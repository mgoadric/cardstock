﻿using System;
using System.Collections.Generic;
using CardEngine;
using CardStockXam.Scoring;
using FreezeFrame;
namespace Players
{
    public class PredictablePlayer : AIPlayer
    {
        private bool firstMove = true;
        private int toChoose = -1;

        public PredictablePlayer (Perspective perspective, int choice) : base(perspective)
        { toChoose = choice; }

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