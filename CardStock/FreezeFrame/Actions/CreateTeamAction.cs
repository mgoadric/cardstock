using System.Diagnostics;
using System.Text.Json;
using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Actions
{
        public class CreateTeamAction : GameAction {
        private readonly List<List<int>> teamList;
        public CreateTeamAction(List<List<int>> teamList, CardGame cg, Logger? script) : base("createteams", script)
        {
            this.teamList = teamList;
            this.cg = cg;
        }

        public override Dictionary<string, object> Execute(bool inChoice = false)
        {
            var numTeams = teamList.Count;
            var teams = new List<Dictionary<string, object>>();
            var data = new Dictionary<string, object>()
            {
                ["action"] = prefix,
                ["teams"] = teams
            };

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
                var tdata = new Dictionary<string, object>
                {
                    ["team"] = "t" + (i + 1),
                    ["members"] = teamList[i]
                };                    
                //script?.WriteToJSON(tdata);
                teams.Add(tdata);
            }

            cg.currentTeam.Push(new StageCycle<Team>(cg.teams));
            Debug.WriteLine("NUMTEAMS:" + cg.teams.Count);
            return data;
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