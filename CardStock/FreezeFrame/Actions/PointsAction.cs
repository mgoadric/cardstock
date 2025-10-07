using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Actions
{
    public class PointsAction(DefaultStorage<PointMap> storage, string bKey, PointMap v, Transcript script) : GameAction('P', script)
    {

        private readonly DefaultStorage<PointMap> bins = storage;
        private readonly string key = bKey;
        private readonly PointMap value = v;
        private PointMap oldValue;

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
            return "PointsAction: value: " + value.ToString();
        }
    }
}