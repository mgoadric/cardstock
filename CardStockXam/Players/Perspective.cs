using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardEngine;
using CardStockXam.Scoring;
using FreezeFrame;
namespace Players
{
    public class Perspective
    {
        private int idx;
        private GameIterator actualgameiterator;

        // Perspective class: This class privitizes the actual game, while giving privileges to the player to 
        // do whatever it wants with the cloned game and cloned game iterator.
        // A player who has a 'perspective' doesn't have privilege to accesss the gameiterator or cardgame.

        public Perspective(int idx, GameIterator actualgameiterator)
        {
            this.idx = idx;
            this.actualgameiterator = actualgameiterator;
        }

        public Tuple<CardGame, GameIterator> GetPrivateGame()
        {
            CardGame privategame = actualgameiterator.game.CloneSecret(idx);
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

            GameIterator g1 = new GameIterator(actualgameiterator.rules, cg, actualgameiterator.gameWorld, "blah", false);
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

            GameIterator g1 = new GameIterator(actualgameiterator.rules, cg, actualgameiterator.gameWorld, "blah", false);
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
