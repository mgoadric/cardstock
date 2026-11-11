using System.Text.Json;
using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Actions {
    public class SetAction<T> : GameAction {

        private readonly DefaultStorage<T> bins;
        private readonly string key;
        private readonly T value;
        private T oldValue;

        public SetAction(DefaultStorage<T> storage, string bKey, T v, Logger? script) : base("set", script) {
            bins = storage;
            key = bKey;
            value = v;

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
        }

        public override Dictionary<string, object> Execute(bool inChoice = false) {
            oldValue = bins[key];
            bins[key] = value;
            complete = true;
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
