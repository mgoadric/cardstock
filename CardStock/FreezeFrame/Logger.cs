using System;
using System.IO;
using System.IO.Compression;
using CardStock.CardEngine;
using CardStock.Evaluation;
using static System.Net.Mime.MediaTypeNames;

namespace CardStock.FreezeFrame
{
    public class Logger
    {
        private readonly Dictionary<Tuple<string, string>, int> edges = [];
        private readonly HashSet<Tuple<string, CCType, string>> locations = [];
        private readonly HashSet<string> starting = [];

        // For writing the game transcript
        private readonly string? fileName;
        private readonly Experiment exp;

        public Logger(string? fileName, Experiment exp)
        {
            this.fileName = fileName;
            this.exp = exp;
            using StreamWriter file = new(fileName + ".txt");
            file.WriteLine("{\"name\":\"" + exp.Game + "\",\"actions\":[");
        }

        public void WriteToFile(string text)
        {
            using StreamWriter file = new(fileName + ".txt", true);
            file.WriteLine(text);
        }

        private void AddLocation(CardCollection cc)
        {
            var cctup = Tuple.Create(cc.owner.owner.name, cc.type, cc.name);
            locations.Add(cctup);
        }

        public void AddStart(string s)
        {
            starting.Add(s);
        }

        public void AddToMovementFile(CardCollection start, CardCollection end)
        {
            var t = Tuple.Create(start.MovementName(), end.MovementName());
            if (!edges.TryGetValue(t, out int value))
            {
                edges[t] = 1;
            }
            else
            {
                edges[t] = ++value;
            }
            AddLocation(start);
            AddLocation(end);
        }

        public void WriteMovementFile()
        {
            var gs = exp.Game.Split("/");
            string name = gs.Length == 1 ? gs[0] : gs[1];
            using StreamWriter file = new(fileName + ".dot");
            file.WriteLine("digraph {");
            file.WriteLine("overlap=scale;");
            file.WriteLine("labelloc=\"t\";");
            file.WriteLine("label=\"" + name + "\";");
            file.WriteLine("fontname=\"Futura\";");


            Dictionary<string, List<Tuple<string, CCType, string>>> who = [];
            foreach (var cc in locations)
            {
                if (!who.TryGetValue(cc.Item1, out List<Tuple<string, CCType, string>>? value))
                {
                    value = [];
                    who[cc.Item1] = value;
                }

                value.Add(cc);
            }

            foreach (var w in who)
            {
                file.WriteLine("subgraph cluster_" + w.Key + " {");
                file.WriteLine("style=filled;fillcolor=ghostwhite;label=\"" + w.Key + "\"");
                foreach (var loc in w.Value)
                {
                    string color = "blue";
                    string style = "filled,rounded";
                    switch (loc.Item2)
                    {
                        case CCType.INVISIBLE:
                            color = "lightblue";
                            if (w.Key.Equals("table"))
                            {
                                color = "khaki";
                            }
                            break;
                        case CCType.HIDDEN:
                            color = "khaki";
                            break;
                        case CCType.OTHERS:
                            color = "plum1";
                            if (w.Key.Equals("table"))
                            {
                                color = "lightgreen";
                            }
                            break;
                        case CCType.VISIBLE:
                            color = "lightgreen";
                            break;
                        case CCType.MEMORY:
                            color = "grey90";
                            style += ",dotted";
                            break;
                    }
                    var node = w.Key + "_" + loc.Item2 + "_" + loc.Item3;
                    string border = "";
                    if (starting.Contains(node))
                    {
                        border = "penwidth=3,";
                    }
                    var s = loc.Item3.Split("_");
                    string label = s[0];
                    if (s[1] != "0")
                    {
                        label = "<" + s[0] + "<SUB>" + s[1] + "</SUB>>";
                    }
                    file.WriteLine(node + " [fontname=Futura," + border + "fillcolor=" + color + ",style=\"" +
                                    style + "\",shape=box,label=" + label + "];");
                    
                }
                file.WriteLine("}");
            }

            foreach (var kvp in edges)
            {
                string edgecolor = "black";
                if (!kvp.Key.Item1.Contains("INVISIBLE") && kvp.Key.Item1.Contains("VISIBLE") &&
                   (kvp.Key.Item2.Contains("INVISIBLE") || kvp.Key.Item2.Contains("HIDDEN"))) {
                    edgecolor = "red,penwidth=3,";
                }
                if (kvp.Key.Item1.Contains("INVISIBLE") && (kvp.Key.Item1[1] != 'a') && (kvp.Key.Item1[1] != kvp.Key.Item2[1]) &&
                   (kvp.Key.Item2.Contains("INVISIBLE") || kvp.Key.Item2.Contains("HIDDEN"))) {
                    edgecolor = "blue,penwidth=3";
                }
                if (!kvp.Key.Item2.Contains("INVISIBLE") && kvp.Key.Item2.Contains("VISIBLE")) {
                    edgecolor = "green,penwidth=3,";
                }
                file.WriteLine(kvp.Key.Item1 + " -> " + kvp.Key.Item2 + " [fontname=Futura,fontsize=11,color=" + edgecolor + "];");
            }
            file.WriteLine("}");
        }
    }
}
