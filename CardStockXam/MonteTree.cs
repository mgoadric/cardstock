using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStockXam
{
    public class MonteTree
    {
        public Node rootNode;
        public MonteTree()
        {
            rootNode = new Node();
        }     
    }
    public class Node
    {
        public int rankinversesum;
        public int timesvisited;
        public List<Node> children = new List<Node>();
        public Node()
        {
            // DEFAULT VALUES FOR NEW NODES
            rankinversesum = 0;
            timesvisited = 1;
        }
       
        public void AddChoices(int num)
        {
            for(int i = 0; i <= num; i++)
            {
                Node temp = new Node();
                children.Add(temp);
            }
        }

        public void UpdateFromRank(int rank)
        {
            rankinversesum += 1 / (rank + 1);
            timesvisited++;
        }


        public float GetExpectedValue()
        {
            return rankinversesum / timesvisited;
        }
    }
}
