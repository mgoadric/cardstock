using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
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
                var tree = parser.computermoves();
                //Recurse(tree);
                Console.Write(tree.GetText());
                //Console.WriteLine(tree);
                
                
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