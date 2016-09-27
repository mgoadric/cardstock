using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using Antlr4.Runtime.Tree;
using CardEngine;

namespace ParseTreeIterator
{
	public class DeckIterator{
		public static Tree ProcessDeck(RecycleParser.DeckContext deck){
			//var attributeCount = deck.ChildCount - 3;
			
			List<Node> childs = new List<Node>();
			for (int i = 0; i < deck.attribute().Count(); ++i){
                var att = ProcessAttribute(deck.attribute(i));
                Console.WriteLine("att " + i + ": " + deck.attribute(i).GetText());
                Console.WriteLine(att.Count);
                for (int idx = 0; idx < att.Count; idx++){
                    Console.WriteLine(att[idx]);
                }
				childs.Add(new Node{
					Value="combo"+i,
					children=ProcessAttribute(deck.attribute(i))
				});
			}
			return new Tree{
				rootNode= new Node{
					Value="Attrs",
					children = childs
				}
			};
		}

        public static List<Node> ProcessAttribute(RecycleParser.AttributeContext attr) //TODO make this array!!
        {
            Console.WriteLine(attr.GetText());
            Console.WriteLine(attr.var() == null);
            if (attr.var() != null) {
                Console.WriteLine(attr.GetText() + " has var");
                return (VarIterator.Get(attr.var()) as Node[]).OfType<Node>().ToList();
            }
            else {
                var ret = new List<Node>();
                if (attr.attribute()[0].attribute().Count() == 0)
                {
                    //base case
                    Console.WriteLine(attr.GetText() + " case 1");
                    var terminalTitle = attr.namegr()[0];
                    var subNode = attr.attribute()[0];
                    Console.WriteLine("subtext: " + subNode.GetText());
                    foreach (var temp in subNode.attribute())
                    {
                        Console.WriteLine("attr: " + attr);
                    }
                    if (subNode.var() == null)
                    {
                        var trueCount = (subNode.ChildCount - 3) / 2 + 1;
                        for (int i = 0; i < trueCount; ++i)
                        {
                            ret.Add(new Node
                            {
                                Key = terminalTitle.GetText(),
                                Value = subNode.namegr(i).GetText()
                            });
                        }
                    }
                    else{
                        var strings = VarIterator.Get(subNode.var()) as string[];
                        foreach (string s in strings){
                            ret.Add(new Node
                            {
                                Key = terminalTitle.GetText(),
                                Value = s
                            });
                        }
                    }
                }
                else
                {
                    Console.WriteLine(attr.GetText() + " case 2");
                    var terminalTitle = attr.namegr()[0];
                    var children = attr.attribute();

                    foreach (var subNode in children)
                    {
                        var childs = new List<Node>();
                        foreach (var att in subNode.attribute())
                        {
                            childs.AddRange(ProcessAttribute(att));
                        }
                        ret.Add(new Node
                        {
                            Key = terminalTitle.GetText(),
                            Value = subNode.namegr()[0].GetText(),
                            children = childs
                        });

                    }
                }
                return ret;
            }
        }
	}
}