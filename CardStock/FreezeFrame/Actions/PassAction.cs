namespace CardStock.FreezeFrame.Actions
{
    /************
     * Passing Action
     ********/
    public class PassAction : GameAction
    {

        public PassAction(Logger script) : base("pass", script)
        {
            data["action"] = prefix;
        }

        public override Dictionary<string, object> Execute(bool inChoice = false)
        {
            return data;
        }
        public override void Undo() {}
    }
}