using System;
using System.Collections.Generic;
using CardEngine;

namespace FreezeFrame
{
    public class StrStorageReference
    {
        public DefaultStorage<string> storage { get; set; }
        public string key { get; set; }
        public StrStorageReference(DefaultStorage<string> raw, string key)
        {
            this.storage = raw;
            this.key = key;
        }
        public string Get()
        {
            return this.storage[this.key];
        }

        public string GetName()
        {
            return storage.owner.name + ":" + key;
        }
    }
}