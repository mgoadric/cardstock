using System.Collections.Generic;
public class Tree{
	public Node rootNode;
	public Tree(){
		
	}
	public override string ToString(){
		return rootNode.ToString();
	}
	public List<List<Node>> uniqueOptions(){
		var retList = new List<List<Node>>();
		foreach (var node in rootNode.children){
			retList.Add(recurse(node,true));
		}
		return retList;
	}
	public List<Node> recurse(Node parent, bool level1){
		var ret = new List<Node>();
		foreach (var node in parent.children){
			if (node.children == null || node.children.Count == 0){
				
				
				var temp = new Node(node);
				temp.children.Add(new Node(parent,false));
				ret.Add(temp);
				
			}
			else{
				
				var temp = recurse(node,false);
				foreach (var tempChild in temp){
					tempChild.AddLeaf(new Node(parent,false));
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
	public List<Node> combinations(){
		var unique = uniqueOptions();
		var latestIter = unique[0];
		for (int i = 0; i < unique.Count - 1; ++i){
			latestIter = perm(latestIter,unique[i + 1],(i == 0));
		}
		return latestIter;
	}
	public List<Node> perm(List<Node> thingOne, List<Node> thingTwo,bool first){
		
		var perm = new List<Node>();
		foreach (var node1 in thingOne){
			foreach (var node2 in thingTwo){
				if (first){
					var tempNode = new Node{Value="treeRoot",children = new List<Node>{node1,node2}};
					perm.Add(tempNode);
				}
				else{
					var tempNode = new Node(node1);
					tempNode.children.Add(new Node(node2));
					perm.Add(tempNode);
				}
			}
		}
		return perm;
	}
}
public class Node{
	public string Value;
	public string Key;
	public List<Node> children = new List<Node>();
	public Node(){
		
	}
	public Node(Node copy){
		Value = copy.Value;
		Key = copy.Key;
		children = new List<Node>();
		foreach (var c in copy.children){
			children.Add(new Node(c));
		}
	}
	public Node(Node copy, bool useChildren){
		Value = copy.Value;
		Key = copy.Key;
		children = new List<Node>();
		
	}
	public void AddLeaf(Node n){
		Node temp = this;
		while (temp.children != null && temp.children.Count > 0){
			temp = temp.children[0];
		}
		temp.children = new List<Node>{n};
	}
	public override string ToString(){
		string ret = "";
		if (children != null){
			foreach (var node in children){
				
				ret += node.ToString() + " ";
			}
		}
		if (Value != null){
			return Value + "(" + Key +  ")" +  " {" + ret + "}";
		}
		else{
			return "";
		} 
 	}
}