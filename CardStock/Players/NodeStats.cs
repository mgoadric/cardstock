namespace CardStock.Players
{   
    public record NodeStats(int NumPlayers)
    {
        public int plays;
        public double[] scores = new double[NumPlayers];
        public double[] ranks = new double[NumPlayers];
    }
}