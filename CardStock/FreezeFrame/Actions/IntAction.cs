using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Actions
{
    public class IntAction(DefaultStorage<int> storage, string bKey, int v, Transcript script) : GameAction('S', script)
    {

        readonly DefaultStorage<int> bins = storage;
        readonly string key = bKey;
        readonly int value = v;
        int oldValue;

        public override void Execute()
        {
            oldValue = bins[key];
            bins[key] = value;
            complete = true;
            script?.WriteToFile(prefix + ":" + bins.owner.name + " " + key + " " + value);
        }
        public override void Undo()
        {
            if (complete)
            {
                bins[key] = oldValue;
                complete = false;
            }
            else
            {
                throw new UnauthorizedAccessException();
            }
        }
        public override string ToString()
        {
            return "IntAction: value: " + value.ToString();
        }
    }
}
