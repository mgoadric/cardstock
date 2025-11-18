using System.Diagnostics;
using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Actions
{
        public class CreateTeamAction : GameAction {
        private readonly List<List<int>> teamList;
        public CreateTeamAction(List<List<int>> teamList, CardGame cg, Logger? script) : base('E', script)
        {
            this.teamList = teamList;
            this.cg = cg;
        }

        public override void Execute()
        {
            var numTeams = teamList.Count;
            for (int i = 0; i < numTeams; i++)
            {
                var newTeam = new Team("t" + (i + 1), i);
                var teamStr = prefix + ":t" + (i + 1) + "-> ";
                for (int j = 0; j < teamList[i].Count; j++)
                {
                    newTeam.teamPlayers.Add(cg.players[teamList[i][j] - 1]);
                    cg.players[teamList[i][j] - 1].team = newTeam;
                    teamStr +=  teamList[i][j] + ",";
                }
                cg.teams.Add(newTeam);
                script?.WriteToFile(teamStr);
            }

            cg.currentTeam.Push(new StageCycle<Team>(cg.teams));
            Debug.WriteLine("NUMTEAMS:" + cg.teams.Count);
		}

        public override void Undo()
        {
            throw new NotImplementedException();
        }
		public override string ToString()
		{
            return "CreateTeamAction: " + teamList.ToString();
		}
    }
}