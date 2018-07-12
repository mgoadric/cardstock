﻿using System;
using System.Collections.Generic;
using CardEngine;
using FreezeFrame;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Players
{
    public class PredictablePlayer : GeneralPlayer
    {
        private bool firstMove = true;
        private int toChoose = -1;

        public PredictablePlayer(GameIterator m, int toChoose) : base(m)
        {
            this.toChoose = toChoose;
        }

        public override int MakeAction(List<GameActionCollection> possibles, Random rand)
        {
			if (firstMove)
			{
				firstMove = false;
				return toChoose;
			}

            return rand.Next(0, possibles.Count);
        }

        public override int MakeAction(JObject possibles, Random rand)
        {
            if (firstMove)
            {
                firstMove = false;
                return toChoose;
            }

            var items = (JArray)possibles["items"];
            return rand.Next(0, items.Count);
        }
    }
}