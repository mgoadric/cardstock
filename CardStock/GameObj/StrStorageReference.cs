using CardStock.CardEngine;

namespace CardStock.GameObj
{
    public class StrStorageReference(DefaultStorage<string> raw, IString key) : IString
    {
        public DefaultStorage<string> Storage { get; set; } = raw;
        public IString Key { get; set; } = key;

        public string Get()
        {
            return this.Storage[Key.Get()];
        }

        public string GetName()
        {
            return Storage.owner.name + ":" + Key;
        }
    }
}