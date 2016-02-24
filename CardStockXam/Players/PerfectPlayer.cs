using System;
using System.Collections.Generic;
using CardEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Players
{
	public class PerfectPlayer : GeneralPlayer
	{
		public PerfectPlayer ()
		{
		}
		public override int MakeAction(List<GameActionCollection> possibles,Random rand){

			return rand.Next(0,possibles.Count);
		}
		public override int MakeAction(JObject possibles, Random rand){
			var items = (JArray)possibles ["items"];
			return rand.Next (0,items.Count);
		}
	}
}

