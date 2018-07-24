using System;
using System.Collections.Generic;

namespace FreezeFrame{
	public class IntStorageReference{
        public DefaultStorage<int> storage {get; set;}
		public string key {get; set;}
        public IntStorageReference(DefaultStorage<int> raw, string key){
			this.storage = raw;
			this.key = key;
		}
		public int Get(){
			return this.storage[this.key];
		}

        public string GetName()
        {
            return storage.owner.name + ":" + key;
        }
	}
}