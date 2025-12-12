using System.Text.Json;
using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Actions
{
        public class PlayerNowAction : GameAction
    {
        private readonly int idx;
        private int former;
        public PlayerNowAction(int idx, CardGame cg, Logger script) : base("cycle", script)
        {
            this.idx = idx;
            this.cg = cg;
        }

        public override void Execute(bool inChoice = false)
        {
            former = cg.CurrentPlayer().Current().id;
            cg.CurrentPlayer().SetMember(idx);
            var data = new Dictionary<string, object>
            {
                ["action"] = prefix,
                ["type"] = "now",
                ["who"] = "p" + (idx + 1),
            };
            script?.WriteToJSON(data);
        }

        public override void Undo()
        {
            cg.CurrentPlayer().SetMember(former);
            //script.WriteToFile(prefix + ": " + cg.CurrentPlayer().CurrentName());
        }

		public override string ToString()
		{
            return "PlayerNowAction: Set player: " + idx.ToString();
		}
    }
}