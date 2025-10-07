using System.Text;

namespace CardStock.CardEngine
{
    public class AttributeNode
    {
        public string Value;
        public string Key;
        public List<AttributeNode> children = [];
        public AttributeNode()
        {

        }
        public AttributeNode(AttributeNode copy, bool useChildren = true)
        {
            Value = copy.Value;
            Key = copy.Key;
            children = [];
            if (useChildren)
            {
                foreach (var c in copy.children)
                {
                    children.Add(new AttributeNode(c));
                }
            }
        }
        public void AddLeaf(AttributeNode n)
        {
            AttributeNode temp = this;
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

    public class CardTree
    {
        public AttributeNode rootNode;
        public CardTree()
        {

        }
        public override string ToString()
        {
            return rootNode.ToString();
        }

        public List<List<AttributeNode>> UniqueOptions()
        {
            var retList = new List<List<AttributeNode>>();
            foreach (var node in rootNode.children)
            {
                retList.Add(Recurse(node));
            }
            return retList;
        }
        public static List<AttributeNode> Recurse(AttributeNode parent)
        {
            var ret = new List<AttributeNode>();
            foreach (var node in parent.children)
            {
                if (node.children is null || node.children.Count == 0)
                {


                    var temp = new AttributeNode(node);
                    temp.children.Add(new AttributeNode(parent, false));
                    ret.Add(temp);

                }
                else
                {

                    var temp = Recurse(node);
                    foreach (var tempChild in temp)
                    {
                        tempChild.AddLeaf(new AttributeNode(parent, false));
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

        public List<AttributeNode> Combinations()
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
                var ret = new List<AttributeNode>();
                foreach (var node in latestIter)
                {
                    ret.Add(
                        new AttributeNode { Value = "treeRoot", children = [node] }
                    );
                }
                return ret;
            }
        }

        public static List<AttributeNode> Perm(List<AttributeNode> thingOne, List<AttributeNode> thingTwo, bool first)
        {

            var permu = new List<AttributeNode>();
            foreach (var node1 in thingOne)
            {
                foreach (var node2 in thingTwo)
                {
                    if (first)
                    {
                        var tempNode = new AttributeNode { Value = "treeRoot", children = [node1, node2] };
                        permu.Add(tempNode);
                    }
                    else
                    {
                        var tempNode = new AttributeNode(node1);
                        tempNode.children.Add(new AttributeNode(node2));
                        permu.Add(tempNode);
                    }
                }
            }
            return permu;
        }
    }
}