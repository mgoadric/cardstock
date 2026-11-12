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
            return Data();
        }

        public override Dictionary<string, object> Data(bool inChoice = false)
        {
            Dictionary<string, object> data = [];
            data["action"] = prefix;
            data["type"] = "next";
            data["who"] = "p" + (idx + 1);
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
        }
    }
}