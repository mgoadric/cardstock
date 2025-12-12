using System.Diagnostics;

namespace CardStock.FreezeFrame.Actions
{
    public class GameActionCollection : List<GameAction>
    {

        public void ExecuteAll()
        {
            foreach (var gameColl in this)
            {
                gameColl.Execute();
            }
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