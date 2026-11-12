namespace CardStock.FreezeFrame.Actions
{
    /************
     * Passing Action
     ********/
    public class PassAction(Logger script) : GameAction("pass", script)
    {
        public override Dictionary<string, object> Execute(bool inChoice = false)
        {
            return Data();
        }

        public override Dictionary<string, object> Data(bool inChoice = false)
        {
            Dictionary<string, object> data = [];
            data["action"] = prefix;
            return data;
        }

        public override void Undo() {}
    }
}