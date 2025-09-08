namespace CardStockXam.Scoring.Heuristics
{
    class NoTies : Heuristic
    {
        public override double Get(World w)
        {
            if (w.numTies == 0) { return 1.0; }
            return 1.0 / (w.numTies * 3);
        }

        public override double Weight()
        {
            return 0.5;
        }
    }
}
