using System.Collections.Generic;
using System;

namespace CardEngine{
	public class RawStorage{
		public int this[string key]
		{
		    get
		    {
		        return storage[binDict[key]];
		    }
		    set
		    {
				
	       		storage[binDict[key]] = value;
				Analytics.StorageValues.Instance.AddCount(value,this.GetHashCode() + key);
				if (triggerDict.ContainsKey(key)){
					foreach (var trigger in triggerDict[key]){
						trigger.Evaluate(storage[binDict[key]]);
					}
				}
	    	}
		}
		public int[] storage;
		int binCounter = 0;
		Dictionary<string,List<Trigger>> triggerDict = new Dictionary<string, List<Trigger>>();
		Dictionary<string,int> binDict = new Dictionary<string,int>();
		public RawStorage(){
			storage = new int[32];
		}
		public void AddTrigger(Trigger trig, string key){
			if (!triggerDict.ContainsKey(key)){
				triggerDict[key] = new List<Trigger>();
			}
			triggerDict[key].Add(trig);
		}
		public void AddKey(string key){
			binDict.Add(key,binCounter);
			binCounter++;
		}
	}
	public class Trigger{
		public TriggerException exception;
		public string op;
		public int value;
		public void Evaluate(int v){
			var shouldTrigger = false;
			if (op == ">="){
				if (v >= value){
					shouldTrigger = true;
				}
			}
			if (shouldTrigger){
				throw exception;
			}
		}
		
	}
	public class TriggerException : Exception
    {
		public string Level {get; set;}
        public TriggerException()
            : base() { }

        public TriggerException(string message)
            : base(message) { }

        public TriggerException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public TriggerException(string message, Exception innerException)
            : base(message, innerException) { }

        public TriggerException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }
}