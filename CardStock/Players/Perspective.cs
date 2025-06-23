using CardStock.CardEngine;
using CardStock.Scoring;
using CardStock.FreezeFrame;
using System.Diagnostics;
namespace CardStock.Players
{
    public class Perspective(int idx, GameIterator actualgameiterator)
    {
        private readonly int idx = idx;
        private readonly GameIterator actualgameiterator = actualgameiterator;

        public Tuple<CardGame, GameIterator> GetPrivateGame()
        {
            Debug.WriteLine("Original Game!!!");
            Debug.WriteLine(actualgameiterator.game);

            CardGame privategame = actualgameiterator.game.CloneSecret(idx);

            Debug.WriteLine("Cloned Game!!!");
            Debug.WriteLine(privategame);

            GameIterator privategameiterator = actualgameiterator.Clone(privategame);
            return new Tuple<CardGame, GameIterator>(privategame, privategameiterator);
        }

        public int NumberOfPlayers()
        { return actualgameiterator.game.players.Length; }

        public void AddLeadsList(Tuple<int, double[]> leads) {
            actualgameiterator.AddLeadsList(leads);
        }

        public void AddSpreadList(Tuple<int, double> spreads)
        {
            actualgameiterator.AddSpreadList(spreads);
        }

        public int GetIdx()
        { return idx; }

        public World GetWorld()
        { return actualgameiterator.gameWorld; }

        public bool TestingClone()
        {
            CardGame cg = actualgameiterator.game.Clone();
            if (!cg.Equals(actualgameiterator.game))
            { Console.WriteLine("Clone CardGame Not Equal -- Returning false"); return false; }

            GameIterator g1 = new(actualgameiterator.rules, cg, actualgameiterator.gameWorld, "blah", false);
            GameIterator g2 = actualgameiterator.Clone(cg);
            if (!g2.Equals(actualgameiterator))
            { Console.WriteLine("Clone GameIterator Not Equal -- Returning false"); return false; }

            return true;
        }
        public bool TestingCloneSecret()
        {
            CardGame cg = actualgameiterator.game.CloneSecret(0);
            

            if (!cg.Equals(actualgameiterator.game))
            { Console.WriteLine("CloneSecret CardGame not equal -- Returning False"); return false; }

            GameIterator g1 = new(actualgameiterator.rules, cg, actualgameiterator.gameWorld, "blah", false);
            GameIterator g2 = actualgameiterator.Clone(cg);
            if (!g2.Equals(actualgameiterator))
            { Console.WriteLine("CloneSecret GameIterator not equal -- Returning False"); return false; }

            return true;
        }
        public bool TestCloneSecretClone()
        {
            CardGame cg = actualgameiterator.game.CloneSecret(0);
            CardGame clone = cg.Clone();
            CardGame clone2 = clone.Clone();
            if (clone.Equals(cg))
            { Console.WriteLine("Clonesecret equals Cloned CloneSecret"); }
            else { Console.WriteLine("Clonesecret Clone fail"); }
            if (clone2.Equals(clone))
            { Console.WriteLine("CloneSecret's Clone Clone equals CloneSecret's Clone"); }
            return true;
        }
       
    }
}
