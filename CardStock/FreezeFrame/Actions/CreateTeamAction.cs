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

            var teams = new List<Dictionary<string, object>>();
            data["action"] = prefix;
            data["teams"] = teams;

            for (int i = 0; i < teamList.Count; i++)
            {  
                var tdata = new Dictionary<string, object>
                {
                    ["team"] = "t" + (i + 1),
                    ["members"] = teamList[i]
                };                    
                teams.Add(tdata);
            }
        }

        public override Dictionary<string, object> Execute(bool inChoice = false)
        {

            for (int i = 0; i < teamList.Count; i++)
            {
                var newTeam = new Team("t" + (i + 1), i);
                for (int j = 0; j < teamList[i].Count; j++)
                {
                    newTeam.teamPlayers.Add(cg.players[teamList[i][j] - 1]);
                    cg.players[teamList[i][j] - 1].team = newTeam;
                }
                cg.teams.Add(newTeam);
            }

            cg.currentTeam.Push(new StageCycle<Team>(cg.teams));
            return data;
		}

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}