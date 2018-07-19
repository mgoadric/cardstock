using System;
using System.Collections.Generic;

namespace CardEngine{
	public class FancyIntStorage{
		public IntStorage storage {get; set;}
		public string key {get; set;}
		public FancyIntStorage(IntStorage raw, string key){
			this.storage = raw;
			this.key = key;
		}
		public int Get(){
			return this.storage[this.key];
		}

        public string GetName()
        {
            return storage.GetOwnerName() + ":" + key;
        }
	}
}