using System;
using System.Collections.Generic;
using CardStock.CardEngine;

namespace CardStock.FreezeFrame
{
    public class PointStorageReference
    {
        public DefaultStorage<PointMap> storage { get; set; }
        public string key { get; set; }
        public PointStorageReference(DefaultStorage<PointMap> raw, string key)
        {
            this.storage = raw;
            this.key = key;
        }
        public PointMap Get()
        {
            return this.storage[this.key];
        }

        public string GetName()
        {
            return storage.owner.name + ":" + key;
        }
    }
}