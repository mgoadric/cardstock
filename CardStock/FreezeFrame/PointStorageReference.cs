using System;
using System.Collections.Generic;
using CardStock.CardEngine;

namespace CardStock.FreezeFrame
{
    public class PointStorageReference(DefaultStorage<PointMap> raw, string key)
    {
        public DefaultStorage<PointMap> Storage { get; set; } = raw;
        public string Key { get; set; } = key;

        public PointMap Get()
        {
            return this.Storage[this.Key];
        }

        public string GetName()
        {
            return Storage.owner.name + ":" + Key;
        }
    }
}