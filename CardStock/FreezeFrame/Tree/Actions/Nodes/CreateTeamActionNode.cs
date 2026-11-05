using CardStock.CardEngine;
using CardStock.FreezeFrame.Actions;

namespace CardStock.FreezeFrame.Tree.Actions.Nodes;

public class CreateTeamActionNode : ActionSupplierNode
{
    private readonly List<List<int>> _arrangements;

    public CreateTeamActionNode(RecycleParser.TeamcreateContext context, CardGame game)
    {
        this._arrangements = _ProcessTeamCreate(
            context, context is null ? game.players.Length : context.teams().Length, context is null
        );
    }

    public GameAction GetAction(GameContext context)
    {
        return new CreateTeamAction(_arrangements, context.Game(), context.Script());
    }

    /*
        Ripped from game iterator; cachable I THINK
    */
    private static List<List<int>> _ProcessTeamCreate(RecycleParser.TeamcreateContext? context, int teamCount, bool individual)
    {
        var ret = new List<List<int>>();

        if (!individual)
        {
            for (int i = 0; i < teamCount; i++)
            {
                ret.Add([]);
                foreach (var p in context!.teams(i).INTNUM())
                {
                    int t = int.Parse(p.GetText());
                    ret[i].Add(t);
                    //Console.WriteLine(t);
                }
            }
        }
        else
        {
            for (int i = 0; i < teamCount; i++)
            {
                ret.Add([i + 1]);
            }
        }

        return ret;
    }
}