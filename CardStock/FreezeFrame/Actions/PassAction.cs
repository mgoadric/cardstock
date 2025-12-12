using System.Text.Json;

namespace CardStock.FreezeFrame.Actions
{
    /************
     * Passing Action
     ********/
    public class PassAction(Logger script) : GameAction("pass", script)
    {
        public override void Execute()
        {
            var data = new Dictionary<string, string>
            {
                ["action"] = prefix,
            };
            script?.WriteToFile(JsonSerializer.Serialize(data));
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