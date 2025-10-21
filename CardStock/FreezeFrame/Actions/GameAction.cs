using System.Diagnostics;
using System.Net.NetworkInformation;
using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Actions {

    public abstract class GameAction(char prefix, Logger? script) {
        public bool inChoice = false;
        public bool complete;
        public CardGame cg;
        public Logger? script = script;
        public char prefix = prefix;
        public void ExecuteActual()
        {
            inChoice = false;
            prefix = char.ToUpper(prefix);
            Execute();
        }
        public void TempExecute()
        {
            inChoice = true;
            prefix = char.ToLower(prefix);
            Execute();
        }
        public abstract void Execute();
        public abstract void Undo();
    }
    
    // NOT A REAL GAME ACTION, USED IN RECURSEDO FOR GENERATING CHOICES...
    public class LoopAction(string v, object item, int level) : GameAction('L', null){
        public string var = v;
        public object item = item;
        public int level = level;

        public override void Execute()
        {
            throw new Exception();
        }

        public override void Undo()
        {
            throw new Exception();
        }
		public override string ToString()
		{
            return "LoopAction: " + var;
		}
    }
}