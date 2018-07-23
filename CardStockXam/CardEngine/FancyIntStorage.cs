using System;
using System.Collections.Generic;

namespace CardEngine{
	public class FancyIntStorage{
        public DefaultStorage<int> storage {get; set;}
		public string key {get; set;}
        public FancyIntStorage(DefaultStorage<int> raw, string key){
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