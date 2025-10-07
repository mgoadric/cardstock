using System;
using System.Collections.Generic;
using CardStock.CardEngine;

namespace CardStock.FreezeFrame{
	public class StorageReference<T>(DefaultStorage<T> raw, string key)
    {
        public DefaultStorage<T> Storage { get; } = raw;
        public string Key { get; } = key;

        public T Get(){
			return Storage[Key];
		}

        public string GetName()
        {
            return Storage.owner.name + ":" + Key;
        }
	}
}