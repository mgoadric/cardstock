using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Actions {
    public class SetAction<T>(DefaultStorage<T> storage, string bKey, T v, Transcript script) : GameAction('S', script) {

        readonly DefaultStorage<T> bins = storage;
        readonly string key = bKey;
        readonly T value = v;
        T oldValue;

        public override void Execute() {
            oldValue = bins[key];
            bins[key] = value;
            complete = true;
            script?.WriteToFile(prefix + ":" + bins.owner.name + " " + key + " " + value);
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
