using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Antlr4.Runtime.Tree;

namespace CardStock
{
    public class DotVisualization
    {

        /*********
         * Output the parsed game for graphviz dot
         *********/
        public static void DOTMakerTop(IParseTree node, string fileName)
        {
            StringBuilder builder = new();
            builder.Append("graph tree{");
            builder.AppendLine("NODE0 [label=\"Stage\" style=filled fillcolor=\"red\"]");
            DOTMaker(node, "NODE0", builder);
            builder.Append('}');
            try
            {
                var fs = File.Create(fileName + ".gv");
                var bytes = Encoding.UTF8.GetBytes(builder.ToString());
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
                Debug.WriteLine("wrote " + fileName + ".gv");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        /*********
         * Recurisve call to output the parsed game for graphviz dot
         *********/
        public static void DOTMaker(IParseTree node, string nodeName, StringBuilder builder)
        {
            for (int i = 0; i < node.ChildCount; ++i)
            {
                var dontCreate = false;
                var newNodeName = nodeName + "_" + i;
                var contextName = node.GetChild(i).GetType().ToString().Replace("RecycleParser+", "").Replace("Context", "");
                if (node.GetChild(i).ChildCount > 0 && contextName == "Int")
                {
                    var text = node.GetChild(i).GetText();
                    int myi = 0;
                    while (myi < text.Length && char.IsDigit(text[myi]))
                    {
                        myi++;
                    }
                    if (myi != text.Length)
                    {
                        builder.AppendLine(newNodeName + " [label=\"" + node.GetChild(i).GetType().ToString().Replace("RecycleParser+", "").Replace("Context", "") + "\" ]");
                        DOTMaker(node.GetChild(i), newNodeName, builder);
                    }
                    else
                    {
                        builder.AppendLine(newNodeName + " [label=\"" + node.GetChild(i).GetText() + "\" style=filled fillcolor=\"lightblue\"]");
                    }
                }
                else if (node.GetChild(i).ChildCount > 0 && contextName != "Namegr" && contextName != "Name" && contextName != "Trueany")
                {
                    var extra = "";
                    if (contextName == "Stage")
                    {
                        extra = " style=filled fillcolor=\"red\"";
                    }
                    else if (contextName == "Computermoves")
                    {
                        extra = " style=filled shape=box fillcolor=\"yellow\"";
                    }
                    else if (contextName == "Playermoves")
                    {
                        extra = " style=filled shape=diamond fillcolor=\"orange\"";
                    }
                    builder.AppendLine(newNodeName + " [label=\"" + node.GetChild(i).GetType().ToString().Replace("RecycleParser+", "").Replace("Context", "") + "\" " + extra + "]");
                    DOTMaker(node.GetChild(i), newNodeName, builder);
                }
                else if (node.GetChild(i).ChildCount > 0)
                {
                    builder.AppendLine(newNodeName + " [fillcolor=\"green\" style=filled label=\"" + node.GetChild(i).GetText() + "\"]");
                }
                else if (node.GetChild(i).GetText() == "(" || node.GetChild(i).GetText() == ")" || node.GetChild(i).GetText() == "," ||
                                            node.GetChild(i).GetText() == "end" || node.GetChild(i).GetText() == "stage" || node.GetChild(i).GetText() == "comp" ||
                                            node.GetChild(i).GetText() == "create" || node.GetChild(i).GetText() == "sto" || node.GetChild(i).GetText() == "loc" ||
                                            node.GetChild(i).GetText() == "initialize" || node.GetChild(i).GetText() == "move" || node.GetChild(i).GetText() == "copy" ||
                                            node.GetChild(i).GetText() == "inc" || node.GetChild(i).GetText() == "dec" || node.GetChild(i).GetText() == "shuffle" ||
                                            node.GetChild(i).GetText() == "remove" ||
                                            node.GetChild(i).GetText() == "choice")
                {
                    dontCreate = true;
                }
                else
                {
                    builder.AppendLine(newNodeName + " [label=\"" + node.GetChild(i).GetText() + "\"]");
                }
                if (!dontCreate)
                {
                    builder.AppendLine(nodeName + " -- " + newNodeName);
                }
            }
        }
    }
}
