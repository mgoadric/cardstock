using System.Diagnostics;
using System.Net.NetworkInformation;
using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Actions {

    public abstract class GameAction(string prefix, Logger? script) {
        public bool complete;
        public CardGame cg;
        public Logger? script = script;
        public string prefix = prefix;

        public abstract Dictionary<string, object> Execute(bool inChoice = false);
        public abstract void Undo();
    }
    
    // NOT A REAL GAME ACTION, USED IN RECURSEDO FOR GENERATING CHOICES...
    public class LoopAction(string v, object item, int level) : GameAction("loop", null){
        public string var = v;
        public object item = item;
        public int level = level;

        public override Dictionary<string, object> Execute(bool inChoice = false)
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