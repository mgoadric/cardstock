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
        private readonly List<Experiment> exps = [];
        private ParseEngine engine;

        public static World gameWorld;
        public string text;

        public Scorer(string game, int players = 2, int numRndvRnd = 100, int numAIvRnd = 100, int numAIvAI = 100)
        {

            text = "Scoring " + game + ":p" + players + ":\n";

            exps.Add(new Experiment()
            {
                Game = game,
                PlayerCount = players,
                NumGames = numRndvRnd,
                NumEpochs = numRndvRnd,
                Logging = false,
                Evaluating = true,

            });


            exps.Add(new Experiment()
            {
                Game = game,
                PlayerCount = players,
                NumGames = numAIvRnd,
                NumEpochs = numAIvRnd,
                Logging = false,
                Evaluating = true,
                type = GameType.RndandAI

            });


            exps.Add(new Experiment()
            {
                Game = game,
                PlayerCount = players,
                NumGames = numAIvAI,
                NumEpochs = numAIvAI,
                Logging = false,
                Evaluating = true,
                type = GameType.AllAI
            });
            gameWorld = new World();

        }

        // list of heuristic values
        private readonly List<Heuristic> hs = [
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
        ];

        // define heuristics here
        public List<double> Score(){
            
            //var path = Path.Combine("Gamepool", "Scoring" + name + ".txt");
            List<double> empty = [0.0];
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
            List<double> total = [];
            var cleanoutput = "";
            StreamWriter heurfile = new("output/" + exps[0].Game + "/" + exps[0].PlayerCount + "/heuristics.txt");

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
        public static bool ParseBool(string line)
        {
            return line.Split(':')[1] == "T";
        }
    }
}
