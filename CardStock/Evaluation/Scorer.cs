﻿using System.Diagnostics;
using CardStock.Players;

namespace CardStock.Evaluation
{
    class Scorer{
        private readonly List<Experiment> exps = [];

        public static World gameWorld;
        public string text;

        public Scorer(string game, int players = 2, int numRndvRnd = 100,
                int numAIvRnd = 100, int numAIvAI = 100, PlayerType ai = PlayerType.PIPMC)
        {

            text = "Scoring " + game + ":p" + players + ":\n";

            exps.Add(new Experiment()
            {
                Game = game,
                PlayerCount = players,
                NumGames = numRndvRnd,
                NumEpochs = numRndvRnd,
                ai = PlayerType.RANDOM,
            });


            exps.Add(new Experiment()
            {
                Game = game,
                PlayerCount = players,
                NumGames = numAIvRnd,
                NumEpochs = numAIvRnd,
                type = GameType.RndandAI,
                ai = ai,
            });


            exps.Add(new Experiment()
            {
                Game = game,
                PlayerCount = players,
                NumGames = numAIvAI,
                NumEpochs = numAIvAI,
                type = GameType.AllAI,
                ai = ai,
            });

            gameWorld = new World();

        }

        // define heuristics here
        public List<double> Score(){
            
            List<double> empty = [0.0];
            for (int i = 0; i < exps.Count; i++){
                Debug.WriteLine("Experiment " + i);
                GameSimulator engine = new(exps[i], gameWorld);
                var tup = engine.Loader();

                if (!tup.Item1) { Debug.WriteLine("not shuffling"); return empty; }
                if (!tup.Item2) { Debug.WriteLine("no choice"); return empty; }

                var compiling = engine.Experimenter();
                if (!compiling) {Debug.WriteLine("not compiling"); return empty; }
            }

            Debug.WriteLine("passed reasonable");
            List<double> total = [];
            return total;
        }
    }
}
