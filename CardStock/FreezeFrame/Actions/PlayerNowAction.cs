using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Actions
{
        public class PlayerNowAction : GameAction
    {
        private readonly int idx;
        private int former;
        public PlayerNowAction(int idx, CardGame cg, Logger script) : base('T', script)
        {
            this.idx = idx;
            this.cg = cg;
        }

        public override void Execute()
        {
            former = cg.CurrentPlayer().Current().id;
            cg.CurrentPlayer().SetMember(idx);
            script?.WriteToFile(prefix + ":" + cg.CurrentPlayer().CurrentName());
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