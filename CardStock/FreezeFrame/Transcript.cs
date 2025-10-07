using System;
using System.IO;
using CardStock.CardEngine;
using static System.Net.Mime.MediaTypeNames;

namespace CardStock.FreezeFrame
{
    public class Transcript
    {
        private readonly Dictionary<Tuple<string, string>, int> edges = [];
        private readonly HashSet<Tuple<string, CCType, string>> locations = [];

        // For writing the game transcript
        private readonly string? fileName;

        public Transcript(string? fileName)
        {
            this.fileName = fileName;
            using StreamWriter file = new(fileName + ".txt");
            file.WriteLine(";; Starting Transcript");
        }

        // TODO Can we move this to another location and call it a Logging class?
        public void WriteToFile(string text)
        {
            using StreamWriter file = new(fileName + ".txt", true);
            file.WriteLine(text);
        }

        private void AddLocation(CardCollection cc)
        {
            var cctup = Tuple.Create(cc.owner.owner.name, cc.type, cc.name);
            if (!locations.Contains(cctup))
            {
                locations.Add(cctup);
            }
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
            using StreamWriter file = new(fileName + ".dot");
            file.WriteLine("digraph {");

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
                file.WriteLine("color = red;label=\"" + w.Key + "\"");
                foreach (var loc in w.Value)
                {
                    string color = "grey";
                    switch (loc.Item2)
                    {
                        case CCType.INVISIBLE:
                            color = "lightblue";
                            break;
                        case CCType.VISIBLE:
                            color = "lightgreen";
                            break;
                        case CCType.HIDDEN:
                            color = "khaki";
                            break;
                    }
                    var s = loc.Item3.Split("_");
                    file.WriteLine(w.Key + "_" + loc.Item2 + "_" + loc.Item3 +
                        "[fillcolor=" + color + ",style=\"filled,rounded\",shape=\"box\",label=<" + s[0] + "<SUB>" + s[1] + "</SUB>" + ">]");
                }
                file.WriteLine("}");
            }

            foreach (var kvp in edges)
            {
                file.WriteLine(kvp.Key.Item1 + " -> " + kvp.Key.Item2 + " [label=\"" + kvp.Value + "\"];");
            }
            file.WriteLine("}");
        }
    }
}
