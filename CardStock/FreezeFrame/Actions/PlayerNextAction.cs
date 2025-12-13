using System.Text.Json;
using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Actions
{
    public class PlayerNextAction(StageCycle<Player> playerCycle, int idx, Logger script) : GameAction("cycle", script)
    {
        private readonly StageCycle<Player> playerCycle = playerCycle;
        private readonly int idx = idx;
        private int former = -1;

        public override Dictionary<string, object> Execute(bool inChoice = false)
        {
            // someone already in the queue
            if (playerCycle.queuedNext != -1) {
                former = playerCycle.queuedNext;
			}
            playerCycle.SetNext(idx);
            var data = new Dictionary<string, object>
            {
                ["action"] = prefix,
                ["type"] = "next",
                ["who"] = "p" + (idx + 1),
            };
            //script?.WriteToJSON(data);
            return data;
        }

        public override void Undo()
        {
            if (former != -1)
            {
                playerCycle.SetNext(former);
            } else {
                playerCycle.RevertNext();
            }
            //Console.WriteLine("Reverting: " + former);

        }
		public override string ToString()
		{
            return "PlayerNextAction: Next player: " + idx.ToString();
		}
    }
}