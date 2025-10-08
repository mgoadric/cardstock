namespace CardStock.FreezeFrame.Actions
{
    /************
     * Passing Action
     ********/
    public class PassAction(Logger script) : GameAction('Y', script)
    {
        public override void Execute()
        {
            script?.WriteToFile(prefix + ":passing");
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