﻿using System;
using System.Collections.Generic;
using CardEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Players
{
	public class GeneralPlayer
	{
		
        public virtual List<double> GetLead() {
            return new List<double>();
        }

        public virtual int MakeAction(List<GameActionCollection> possibles,Random rand){
			return rand.Next(0,possibles.Count);
		}

		public virtual int MakeAction(JObject possibles, Random rand){
			var items = (JArray)possibles ["items"];
			return rand.Next (0,items.Count);
		}
	}
}

