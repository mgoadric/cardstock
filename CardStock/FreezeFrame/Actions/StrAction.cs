using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Actions
{
    
    public class StrAction(DefaultStorage<string> storage, string bKey, string v, Transcript script) : GameAction('G', script) {

        readonly DefaultStorage<string> bins = storage;
        readonly string key = bKey;
        readonly string value = v;
        string oldValue;

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
            return "StrAction: value: " + value.ToString();
		}
    }
}