using System.Text.Json;

namespace CardStock.FreezeFrame.Actions
{
    /************
     * Passing Action
     ********/
    public class PassAction(Logger script) : GameAction("pass", script)
    {
        public override Dictionary<string, object> Execute(bool inChoice = false)
        {
            var data = new Dictionary<string, object>
            {
                ["action"] = prefix,
            };
            //script?.WriteToJSON(data);
            return data;
        }
        public override void Undo()
        {

        }
        public override string ToString()
        {
            return "TurnAction";
        }
    }
}