using System.Diagnostics;

namespace CardStock.FreezeFrame.Actions
{
    public class GameActionCollection : List<GameAction>
    {

        public List<Dictionary<string, object>> ExecuteAll()
        {
            var coll = new List<Dictionary<string, object>>();
            foreach (var gameColl in this)
            {
                var data = gameColl.Execute();
                coll.Add(data);
            }
            return coll;
        }
        
        public void UndoAll()
        {
            foreach (var gameColl in this)
            {
                Debug.WriteLine("Undoing actions in gameActionCollection" + gameColl);
                gameColl.Undo();
            }
        }
        public override string ToString()
        {
            string toReturn = "";
            foreach (var g in this)
            {
                toReturn += g.ToString();
            }
            return toReturn;
        }
    }
}