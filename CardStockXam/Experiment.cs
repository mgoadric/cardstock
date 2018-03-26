using System;
using System.Collections.Generic;

namespace CardGames
{
    public class Experiment
    {
        public string fileName;
        public int numGames;
        public int numEpochs;
        public bool logging;
        public bool evaluating;
        public bool ai1 = false;
        public bool ai2 = false;
        public GameType type = GameType.AllRnd;
        public System.Text.StringBuilder builder = new System.Text.StringBuilder();


    }

    public enum GameType {
        AllAI, AllRnd, RndandAI
    }


}
