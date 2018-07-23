using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardEngine;
using FreezeFrame;
namespace Players
{
    public class Perspective
    {
        private int idx;
        private CardGame cardgame;
        private GameIterator actualgameiterator;

        // Perspective class: This class privitizes the actual game, while giving privileges to the player to 
        // do whatever it wants with the cloned game and cloned game iterator.
        // A player who has a 'perspective' doesn't have privilege to accesss the gameiterator or cardgame.

        public Perspective(int idx, CardGame cardgame, GameIterator actualgameiterator)
        {
            this.idx = idx;
            this.cardgame = cardgame;
            this.actualgameiterator = actualgameiterator;
        }


        public Tuple<CardGame, GameIterator> GetPrivateGame()
        {
            CardGame privategame = cardgame.CloneSecret(idx);
            GameIterator privategameiterator = actualgameiterator.Clone(privategame);
            return new Tuple<CardGame, GameIterator> (privategame, privategameiterator);
        }

        public int numberofPlayers() // RETURNS NUMBER OF PLAYERS IN GAME
        {
            return cardgame.players.Count;
        }
        public int GetIdx()
        { return idx; }
    }
}
