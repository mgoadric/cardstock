using System;
using System.Collections.Generic;
using CardStock.CardEngine;

namespace CardStock.FreezeFrame
{
    public class StrStorageReference(DefaultStorage<string> raw, string key)
    {
        public DefaultStorage<string> Storage { get; set; } = raw;
        public string Key { get; set; } = key;

        public string Get()
        {
            return this.Storage[this.Key];
        }

        public string GetName()
        {
            return Storage.owner.name + ":" + Key;
        }
    }
}