using System;
using System.Collections.Generic;
using System.Text;
namespace CardEngine
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
        public List<List<Node>> uniqueOptions()
        {
            var retList = new List<List<Node>>();
            foreach (var node in rootNode.children)
            {
                retList.Add(recurse(node));
            }
            return retList;
        }
        public List<Node> recurse(Node parent)
        {
            var ret = new List<Node>();
            foreach (var node in parent.children)
            {
                if (node.children == null || node.children.Count == 0)
                {


                    var temp = new Node(node);
                    temp.children.Add(new Node(parent, false));
                    ret.Add(temp);

                }
                else
                {

                    var temp = recurse(node);
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

        public List<Node> combinations()
        {

            var unique = uniqueOptions();
            if (unique.Count > 1)
            {
                var latestIter = unique[0];
                for (int i = 0; i < unique.Count - 1; ++i)
                {
                    latestIter = perm(latestIter, unique[i + 1], (i == 0));
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
                        new Node { Value = "treeRoot", children = new List<Node> { node } }
                    );
                }
                return ret;
            }
        }
        public List<Node> perm(List<Node> thingOne, List<Node> thingTwo, bool first)
        {

            var permu = new List<Node>();
            foreach (var node1 in thingOne)
            {
                foreach (var node2 in thingTwo)
                {
                    if (first)
                    {
                        var tempNode = new Node { Value = "treeRoot", children = new List<Node> { node1, node2 } };
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
        public List<Node> children = new List<Node>();
        public Node()
        {

        }
        public Node(Node copy, bool useChildren = true)
        {
            Value = copy.Value;
            Key = copy.Key;
            children = new List<Node>();
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
            temp.children = new List<Node> { n };
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
            Dictionary<string, string> ret = new Dictionary<string, string>();
            FlattenHelper(ret);
            return ret;
        }

        public string Serialize()
        {
            string ret = "";
            if (children != null)
            {
                foreach (var node in children)
                {

                    ret += node.Serialize() + ", ";
                }
                if (ret.Length > 0)
                {
                    ret = ret.Remove(ret.Length - 1);
                }
            }
            if (Value != null)
            {
                StringBuilder temp = new StringBuilder();
                temp.Append("{");
                temp.Append((Key != null ? Key : "anon"));
                temp.Append(" : \"");
                temp.Append(Value);
                temp.Append("\", children : [");
                temp.Append(ret);
                temp.Append("]}");
                return temp.ToString();//"{ "+(Key != null?Key : "anon")+" : \""+Value+"\", children : [" + ret + "]}";//Value + "(" + Key +  ")" +  " {" + ret + "}";
            }
            else
            {
                return "";
            }
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();
            if (children != null)
            {
                foreach (var node in children)
                {

                    ret.Append(node + " ");
                }
            }
            if (Value != null)
            {
                StringBuilder temp = new StringBuilder();
                temp.Append(Value);
                temp.Append("(");
                temp.Append(Key);
                temp.Append(") {");
                temp.Append(ret);
                temp.Append("}");
                return temp.ToString();
            }
            else
            {
                return "";
            }
        }
        public string ToOutputString()
        {
            StringBuilder ret = new StringBuilder();
            if (children != null)
            {
                foreach (var node in children)
                {
                    var output = node.ToOutputString();
                    if (!output.Contains("combo"))
                    {
                        ret.Append(output);
                    }
                }
            }
            if (Value != null && !Value.Contains("Root"))
            {
                StringBuilder temp = new StringBuilder();
                temp.Append(Value);
                temp.Append("-");
                temp.Append(Key);
                temp.Append("|");
                temp.Append(ret);
                return temp.ToString();
            }
            else
            {
                return ret.ToString();
            }
        }
    }
}