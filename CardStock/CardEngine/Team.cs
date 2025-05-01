namespace CardStock.CardEngine{
    /**********
     * Teams are Owners that have a list of Players who form a team in the game.
     */
    public class Team(string name, int id) : Owner(name, id)
    {
        public List<Player> teamPlayers = [];

        public bool IsMember(int playerIdx) {
            foreach (Player p in teamPlayers) {
                if (p.id == playerIdx) {
                    return true;
                }
            }
            return false;
        }

        public new Team Clone()
        {
            Team other = new(name, id);
            other.intBins = intBins.Clone(other);
            other.stringBins = stringBins.Clone(other);
            other.pointBins = pointBins.Clone(other);
            other.cardBins = new CardStorage(other);
            other.teamPlayers = [];
            return other;
        }
    }
}