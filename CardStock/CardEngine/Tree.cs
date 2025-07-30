using System.Text;

namespace CardStock.CardEngine
{
    public class Tree
    {
        public Node rootNode;
        public Tree()
        {

        }
        public override string ToString()
        {
            return rootNode.ToString();
        }

        public Dictionary<string, string> Flatten() {
            return rootNode.Flatten();
        }
        public List<List<Node>> UniqueOptions()
        {
            var retList = new List<List<Node>>();
            foreach (var node in rootNode.children)
            {
                retList.Add(Recurse(node));
            }
            return retList;
        }
        public static List<Node> Recurse(Node parent)
        {
            var ret = new List<Node>();
            foreach (var node in parent.children)
            {
                if (node.children is null || node.children.Count == 0)
                {


                    var temp = new Node(node);
                    temp.children.Add(new Node(parent, false));
                    ret.Add(temp);

                }
                else
                {

                    var temp = Recurse(node);
                    foreach (var tempChild in temp)
                    {
                        tempChild.AddLeaf(new Node(parent, false));
                        /*if (level1){
                            ret.Add(new Node{Value="treeRoot",children = new List<Node>{tempChild}});
                        }
                        else{*/
                        ret.Add(tempChild);
                        //}
                    }

                }
            }

            return ret;
        }

        public List<Node> Combinations()
        {

            var unique = UniqueOptions();
            if (unique.Count > 1)
            {
                var latestIter = unique[0];
                for (int i = 0; i < unique.Count - 1; ++i)
                {
                    latestIter = Perm(latestIter, unique[i + 1], (i == 0));
                }
                return latestIter;
            }
            else
            {//single attribute case

                var latestIter = unique[0];
                var ret = new List<Node>();
                foreach (var node in latestIter)
                {
                    ret.Add(
                        new Node { Value = "treeRoot", children = [node] }
                    );
                }
                return ret;
            }
        }
        public static List<Node> Perm(List<Node> thingOne, List<Node> thingTwo, bool first)
        {

            var permu = new List<Node>();
            foreach (var node1 in thingOne)
            {
                foreach (var node2 in thingTwo)
                {
                    if (first)
                    {
                        var tempNode = new Node { Value = "treeRoot", children = [node1, node2] };
                        permu.Add(tempNode);
                    }
                    else
                    {
                        var tempNode = new Node(node1);
                        tempNode.children.Add(new Node(node2));
                        permu.Add(tempNode);
                    }
                }
            }
            return permu;
        }
    }
    public class Node
    {
        public string Value;
        public string Key;
        public List<Node> children = [];
        public Node()
        {

        }
        public Node(Node copy, bool useChildren = true)
        {
            Value = copy.Value;
            Key = copy.Key;
            children = [];
            if (useChildren)
            {
                foreach (var c in copy.children)
                {
                    children.Add(new Node(c));
                }
            }
        }
        public void AddLeaf(Node n)
        {
            Node temp = this;
            while (temp.children != null && temp.children.Count > 0)
            {
                temp = temp.children[0];
            }
            temp.children = [n];
        }

        private void FlattenHelper(Dictionary<string, string> ret) {
            if (children != null)
            {
                foreach (var node in children)
                {
                    node.FlattenHelper(ret);
                }
            }
            if (Value != null && !Value.Contains("Root") && !Value.Contains("combo"))
            {
                //Console.WriteLine("flat." + Key + ":" + Value);
                ret[Key] = Value;
            }
        }

        public Dictionary<string, string> Flatten() 
        {
            Dictionary<string, string> ret = [];
            FlattenHelper(ret);
            return ret;
        }

        public override string ToString()
        {
            StringBuilder ret = new();
            if (children != null)
            {
                foreach (var node in children)
                {

                    ret.Append(node + " ");
                }
            }
            if (Value != null)
            {
                StringBuilder temp = new();
                temp.Append(Value);
                temp.Append('(');
                temp.Append(Key);
                temp.Append(") {");
                temp.Append(ret);
                temp.Append('}');
                return temp.ToString();
            }
            else
            {
                return "";
            }
        }
    }
}