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

        public override Dictionary<string, object> Execute(bool inChoice = false)
        {
            former = cg.CurrentPlayer().Current().id;
            cg.CurrentPlayer().SetMember(idx);
            return Data();
        }

        public override Dictionary<string, object> Data(bool inChoice = false)
        {
            Dictionary<string, object> data = [];
            data["action"] = prefix;
            data["type"] = "now";
            data["who"] = "p" + (idx + 1);
            return data;
        }

        public override void Undo()
        {
            cg.CurrentPlayer().SetMember(former);
        }
    }
}