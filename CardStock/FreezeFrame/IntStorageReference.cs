using System;
using System.Collections.Generic;
using CardStock.CardEngine;

namespace CardStock.FreezeFrame{
	public class IntStorageReference(DefaultStorage<int> raw, string key)
    {
        public DefaultStorage<int> Storage { get; set; } = raw;
        public string Key { get; set; } = key;

        public int Get(){
			return this.Storage[this.Key];
		}

        public string GetName()
        {
            return Storage.owner.name + ":" + Key;
        }
	}
}