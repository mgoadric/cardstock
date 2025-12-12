using System.Text.Json;
using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Actions
{
    public class PlayerNextAction(StageCycle<Player> playerCycle, int idx, Logger script) : GameAction("cycle", script)
    {
        private readonly StageCycle<Player> playerCycle = playerCycle;
        private readonly int idx = idx;
        private int former = -1;

        public override void Execute()
        {
            // someone already in the queue
            if (playerCycle.queuedNext != -1) {
                former = playerCycle.queuedNext;
			}
            playerCycle.SetNext(idx);
            var data = new Dictionary<string, string>
            {
                ["action"] = prefix,
                ["type"] = "next",
                ["who"] = "p" + (idx + 1),
            };
            script?.WriteToFile(JsonSerializer.Serialize(data));
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