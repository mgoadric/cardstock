using System.Text.Json;
using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Actions {
    public class SetAction<T>(DefaultStorage<T> storage, string bKey, T v, Logger? script) : GameAction("set", script) {

        readonly DefaultStorage<T> bins = storage;
        readonly string key = bKey;
        readonly T value = v;
        T oldValue;

        public override Dictionary<string, object> Execute(bool inChoice = false) {
            oldValue = bins[key];
            bins[key] = value;
            complete = true;

            var data = new Dictionary<string, object>
            {
                ["action"] = prefix,
                ["owner"] = bins.owner.name,
                ["key"] = key,
            };
            if (value is int || value is string) 
            {
                data["value"] = value;
            } else if (value is PointMap pm)
            {
                data["value"] = pm.ToJSON();
            }

            //script?.WriteToJSON(data);
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
		public override string ToString()
		{
            return value.GetType() + "Action: value: " + value.ToString();
		}
    }
}
