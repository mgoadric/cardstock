﻿using CardStock.Scoring;
using System.Diagnostics;
using CardStock.Scoring.Heuristics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CardStock.Scoring
{
    class Scorer{
        private List<Experiment> exps = new List<Experiment>();
        private ParseEngine engine;

        public static World gameWorld;
        public string text;

        public Scorer(string fileName, int numRndvRnd = 100, int numAIvRnd = 100, int numAIvAI = 100)
        {

            text = "Scoring " + fileName + ":\n";

            exps.Add(new Experiment()
            {
                fileName = fileName,
                numGames = numRndvRnd,
                numEpochs = numRndvRnd,
                logging = false,
                evaluating = true,

            });


            exps.Add(new Experiment()
            {
                fileName = fileName,
                numGames = numAIvRnd,
                numEpochs = numAIvRnd,
                logging = false,
                evaluating = true,
                type = GameType.RndandAI

            });


            exps.Add(new Experiment()
            {
                fileName = fileName,
                numGames = numAIvAI,
                numEpochs = numAIvAI,
                logging = false,
                evaluating = true,
                type = GameType.AllAI
            });

        }

        // list of heuristic values
        private List<Heuristic> hs = new List<Heuristic>() {
            new Fairness(),
            // TODO ADD CONVERGENCE
            new MeaningfulMoves(),
            //new Variance(),
            //new Depth(),
            //new ExcessRules(),
            //new GameLength(),
            //new NoTies(),
            new Drama(),
            new Decisiveness(),
            // FIX ME!new Stability(),
            //new Clarity(),
            new Coolness()
        };

        // define heuristics here
        public List<double> Score(){
            
            //var path = Path.Combine("Gamepool", "Scoring" + name + ".txt");
            gameWorld = new World();
            List<double> empty = new List<double>();
            empty.Add(0.0);
            for (int i = 0; i < exps.Count; i++){
                Debug.WriteLine("Experiment " + i);
                engine = new ParseEngine(exps[i]);
                engine.setWorld(gameWorld);
                var tup = engine.Loader();

           
               
                if (!tup.Item1) { Debug.WriteLine("not shuffling"); return empty; }
                if (!tup.Item2) { Debug.WriteLine("no choice"); return empty; }

                var compiling = engine.Experimenter();
                if (!compiling) {Debug.WriteLine("not compiling"); return empty; }
            }

            //gameWorld.EvalOver();
            Debug.WriteLine("passed reasonable");
            List<double> total = new List<double>();
            var cleanoutput = "";
            StreamWriter heurfile = new StreamWriter(exps[0].fileName + "-heuristics.txt");

            foreach (Heuristic h in hs){
                var score = h.Eval(gameWorld);
                var output = h.ToString().Substring(32) + "\t" + (score / h.Weight()) +
                        "\t" + h.Weight() + "\t" + score;
                var split = h.ToString().Split('.');
                var heuristic = split[split.Length - 1];
                cleanoutput += heuristic + ": " + score + "\n";
                text += "    " + output;
               
				
                Console.WriteLine(output);
                heurfile.WriteLine(output);
                total.Add(score);
            }
            heurfile.Close();
            /*
			if (!File.Exists(path))
			{
				File.WriteAllText(path, cleanoutput + "\n\n----\n\n\t");
			}
			else
			{
				using (StreamWriter file = new StreamWriter(path, true))
				{
					file.WriteLine(cleanoutput + "\n\n----\n\n");
				}
			}*/
			
            return total;
        }
        public bool parseBool(string line)
        {
            return line.Split(':')[1] == "T";
        }
    }
}
