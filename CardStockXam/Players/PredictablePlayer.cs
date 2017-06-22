﻿using System;
using System.Collections.Generic;
using CardEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Players
{
    public class PredictablePlayer : GeneralPlayer
    {
        bool firstMove = true;
        public int toChoose = -1;
        public PredictablePlayer()
        {
        }
        public override int MakeAction(List<GameActionCollection> possibles, Random rand, int idx)
        {
            // Bad fix TODO :(
			if (firstMove)
			{
				firstMove = false;
                System.Diagnostics.Debug.WriteLine("here is choice: " + toChoose);
				return toChoose;
			}

            return rand.Next(0, possibles.Count);
        }
        public override int MakeAction(JObject possibles, Random rand, int idx)
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