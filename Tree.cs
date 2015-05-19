using System.Collections.Generic;
public class Tree{
	public Node rootNode;
	public Tree(){
		
	}
	public override string ToString(){
		return rootNode.ToString();
	}
	
}
public class Node{
	public string Value;
	public List<Node> children;
	public Node(){
		
	}
	public override string ToString(){
		string ret = "";
		if (children != null){
			foreach (var node in children){
				
				ret += node.ToString() + " ";
			}
		}
		if (Value != null){
			return Value + " {" + ret + "}";
		}
		else{
			return "";
		} 
 	}
}