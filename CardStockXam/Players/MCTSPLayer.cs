using CardEngine;
using CardStockXam;
using FreezeFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players
{
    public class MCTSPLayer : GeneralPlayer
    {
        private int idx;
        private MonteTree choicetree;

        public MCTSPLayer(GameIterator m, int idx) : base(m) // ??
		{
            this.idx = idx;
        }

        public void TreeTrim()
        {

        }

        public override int MakeAction(List<GameActionCollection> possibles, Random rand)
        {
            return Choice(possibles.Count, rand);
        }

        public int Choice(int optioncount, Random random) // FOR NOW, USE A NEW BOARD EACH TIME
        {

            choicetree = new MonteTree();
            choicetree.rootNode.AddChoices(optioncount);


            return 0;
        }

        public Node SelectNodeUsingUCT(List<Node> moves)
        {


            return null;
        }



    }
}
