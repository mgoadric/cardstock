using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Text.Json;
using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Actions {

    public abstract class GameAction(string prefix, Logger? script) {
        protected bool complete;
        protected CardGame cg;
        protected Logger? script = script;
        protected string prefix = prefix;

        public abstract Dictionary<string, object> Execute(bool inChoice = false);
        public abstract void Undo();

        public abstract Dictionary<string, object> Data(bool inChoice = false);
        public override string ToString()
        {
            return JsonSerializer.Serialize(Data());
        }
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

        public override Dictionary<string, object> Data(bool inChoice = false)
        {
            throw new Exception();
            return null;
        }

        public override void Undo()
        {
            throw new Exception();
        }
    }
}