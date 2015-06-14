using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using Antlr4.Runtime.Tree;
public class ParseEngine{
	public ParseEngine(){
                var regex = new Regex("(;;)(.*?)(\n)");
                var f = File.ReadAllText("SpadesTest.gdl");
                var file = f;
                Console.WriteLine(file);
                file = regex.Replace(file,"\n");
                Console.WriteLine(file);
		        AntlrInputStream stream = new AntlrInputStream(file);
                ITokenSource lexer = new CardLanguageLexer(stream);
                ITokenStream tokens = new CommonTokenStream(lexer);
                var parser = new CardLanguageParser(tokens);
        
               	parser.BuildParseTree = true;
                var tree = parser.stage();
                //Recurse(tree);
                Console.Write(tree.ToStringTree());
                Recurse(tree,"NODE0");
                //Console.WriteLine(tree);
                
                
	}
        public void Recurse(IParseTree node, string nodeName){
                
                for (int i = 0; i < node.ChildCount; ++i){
                        var dontCreate = false;
                        var newNodeName = nodeName + "_" + i;
                        var contextName = node.GetChild(i).GetType().ToString().Replace("CardLanguageParser+","").Replace("Context","");
                        if (node.GetChild(i).ChildCount > 0&& contextName != "Name" && contextName != "Trueany"){
                                Console.WriteLine(newNodeName + " [label=\"" + node.GetChild(i).GetType().ToString().Replace("CardLanguageParser+","").Replace("Context","") + "\"]");
                                Recurse(node.GetChild(i),newNodeName);
                        }
                        else if (node.GetChild(i).ChildCount > 0){
                                Console.WriteLine(newNodeName + " [label=\"" + node.GetChild(i).GetText() + "\"]");
                        }
                        else if (node.GetChild(i).GetText() == "(" || node.GetChild(i).GetText() == ")"){
                                dontCreate = true;
                        }
                        else{
                                Console.WriteLine(newNodeName + " [label=\"" + node.GetChild(i).GetText() + "\"]");
                                Recurse(node.GetChild(i),newNodeName);
                        }
                        if (!dontCreate){
                                Console.WriteLine(nodeName + " -- " + newNodeName);
                        }
                }
        }
/*        public void Recurse(CardLanguageParser.BodyContext con){
                Recurse(con.childNode());
        }
        public void Recurse(CardLanguageParser.ChildNodeContext con){
                Console.Write("{ ");
                if (con.ChildCount == 4){
                        Recurse((CardLanguageParser.ChildNodeContext)con.children[1]);
                        Recurse((CardLanguageParser.ChildNodeContext)con.children[3]);
                }
                else if (con.ChildCount == 3){
                        Recurse((CardLanguageParser.ChildNodeContext)con.children[1]);
                }
                else{
                        Console.Write(con.GetText());
                }
                Console.Write(" }");
        }
        */
}