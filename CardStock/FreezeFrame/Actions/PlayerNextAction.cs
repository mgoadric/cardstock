using System.Text.Json;
using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Actions
{
    public class PlayerNextAction : GameAction
    {
        private readonly StageCycle<Player> playerCycle;
        private readonly int idx;
        private int former = -1;

        public PlayerNextAction(StageCycle<Player> playerCycle, int idx, Logger script) : base("cycle", script)
        {
            this.playerCycle = playerCycle;
            this.idx = idx;

            data["action"] = prefix;
            data["type"] = "next";
            data["who"] = "p" + (idx + 1);
        }

        public override Dictionary<string, object> Execute(bool inChoice = false)
        {
            // someone already in the queue
            if (playerCycle.queuedNext != -1) {
                former = playerCycle.queuedNext;
			}
            playerCycle.SetNext(idx);
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