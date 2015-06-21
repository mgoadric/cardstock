using System;
using System.Collections.Generic;

namespace CardEngine{
	public class FancyRawStorage{
		public RawStorage storage {get; set;}
		public string key {get; set;}
		public FancyRawStorage(RawStorage raw, string key){
			this.storage = raw;
			this.key = key;
		}
		public int Get(){
			return this.storage[this.key];
		}
	}
}