using System.Text.Json;
using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Actions {
    public class SetAction<T>(DefaultStorage<T> storage, string bKey, T v, Logger? script) : GameAction("set", script) {

        private readonly DefaultStorage<T> bins = storage;
        private readonly string key = bKey;
        private readonly T value = v;
        private T oldValue;

        public override Dictionary<string, object> Execute(bool inChoice = false) {
            oldValue = bins[key];
            bins[key] = value;
            complete = true;
            return Data();
        }

        public override Dictionary<string, object> Data(bool inChoice = false)
        {
            Dictionary<string, object> data = [];
            data["action"] = prefix;
            data["owner"] = bins.owner.name;
            data["key"] = key;

            if (value is int || value is string) 
            {
                if (value is int) {
                    data["type"] = "int";
                } else
                {
                    data["type"] = "string";
                }
                data["value"] = value;
            } else if (value is PointMap pm)
            {
                data["type"] = "pointmap";
                data["value"] = pm.ToJSON();
            } else
            {
                Console.WriteLine("THIS IS WEIRD!");
                throw new Exception();
            }
            return data;
        }

        public override void Undo() {
            if (complete)
            {
                bins[key] = oldValue;
                complete = false;
            }
            else {
                throw new UnauthorizedAccessException();
            }
        }
    }
}
