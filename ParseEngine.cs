using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using Antlr4.Runtime.Tree;
using ParseTreeIterator;
public class ParseEngine{
        StringBuilder builder = new StringBuilder();
	public ParseEngine(){
                var regex = new Regex("(;;)(.*?)(\n)");
                var fileName = "SpadesTest";
                var f = File.ReadAllText(fileName + ".gdl");
                var file = f;
                //Console.WriteLine(file);
                file = regex.Replace(file,"\n");
                //Console.WriteLine(file);
		        AntlrInputStream stream = new AntlrInputStream(file);
                ITokenSource lexer = new CardLanguageLexer(stream);
                ITokenStream tokens = new CommonTokenStream(lexer);
                var parser = new CardLanguageParser(tokens);
        
               	parser.BuildParseTree = true;
                var tree = parser.stage();
                //Recurse(tree);
                
                //Console.Write(tree.ToStringTree());
                builder.Append("graph tree{");
                builder.AppendLine("NODE0 [label=\"Stage\" style=filled fillcolor=\"red\"]");
                DOTMaker(tree,"NODE0");
                builder.Append("}");
                var fs = File.Create(fileName + ".gv");
                var bytes = Encoding.UTF8.GetBytes(builder.ToString());
                fs.Write(bytes,0,bytes.Length);
                fs.Close();
                //Console.WriteLine(tree);
                
                StageIterator.ProcessStage(tree);
                
	}
        public void DOTMaker(IParseTree node, string nodeName){
                
                for (int i = 0; i < node.ChildCount; ++i){
                        var dontCreate = false;
                        var newNodeName = nodeName + "_" + i;
                        var contextName = node.GetChild(i).GetType().ToString().Replace("CardLanguageParser+","").Replace("Context","");
                        if (node.GetChild(i).ChildCount > 0 && contextName != "Namegr" && contextName != "Name" && contextName != "Trueany"){
                                var extra = "";
                                if (contextName == "Stage") {
                                    extra = " style=filled fillcolor=\"red\"";
                                } else if (contextName == "Computermoves") {
                                    extra = " style=filled shape=box fillcolor=\"yellow\"";
                                } else if (contextName == "Playermoves") {
                                    extra = " style=filled shape=diamond fillcolor=\"orange\"";
                                }
                                builder.AppendLine(newNodeName + " [label=\"" + node.GetChild(i).GetType().ToString().Replace("CardLanguageParser+","").Replace("Context","") + "\" " + extra + "]");
                                DOTMaker(node.GetChild(i),newNodeName);                             
                        }
                        else if (node.GetChild(i).ChildCount > 0){
                                builder.AppendLine(newNodeName + " [fillcolor=\"green\" style=filled label=\"" + node.GetChild(i).GetText() + "\"]");
                        }
                        else if (node.GetChild(i).GetText() == "(" || node.GetChild(i).GetText() == ")" || node.GetChild(i).GetText() == "," ||
                                node.GetChild(i).GetText() == "end" || node.GetChild(i).GetText() == "stage" || node.GetChild(i).GetText() == "comp" || 
                                node.GetChild(i).GetText() == "create" || node.GetChild(i).GetText() == "sto" || node.GetChild(i).GetText() == "loc" || 
                                node.GetChild(i).GetText() == "initialize" || node.GetChild(i).GetText() == "move" || node.GetChild(i).GetText() == "copy" || 
                                node.GetChild(i).GetText() == "inc" || node.GetChild(i).GetText() == "dec" || node.GetChild(i).GetText() == "shuffle" || 
                                node.GetChild(i).GetText() == "remove" || 
                               node.GetChild(i).GetText() == "choice"){
                                dontCreate = true;
                        }
                        else{
                                builder.AppendLine(newNodeName + " [label=\"" + node.GetChild(i).GetText() + "\"]");
                                //DOTMaker(node.GetChild(i),newNodeName);
                        }
                        if (!dontCreate){
                                builder.AppendLine(nodeName + " -- " + newNodeName);
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