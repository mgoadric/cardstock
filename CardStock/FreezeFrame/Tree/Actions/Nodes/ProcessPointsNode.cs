using System.Text;
using CardStock.CardEngine;
using CardStock.FreezeFrame.Actions;
using CardStock.FreezeFrame.Tree.Storage;

namespace CardStock.FreezeFrame.Tree.Actions.Nodes;

public class ProcessPointsNode : ActionSupplierNode
{
    private readonly StorageNode<PointMap> _pointStorage;

    public ProcessPointsNode(StorageNode<PointMap> point)
    {
        _pointStorage = point;
    }

    public GameAction GetAction(GameContext context)
    {
        return null!;
    }

    private static SetAction<PointMap> _ProcessPoints(GameContext context)
    {
        /// ALL NEEDS TO BE REPLACED WITH A NODE
        /*List<ValueTuple<string, string, int>> temp = [];
        var awards = points.awards();
        foreach (RecycleParser.AwardsContext award in awards)
        {
            StringBuilder key = new();
            StringBuilder value = new();
            int reward = ProcessInt(award.@int());
            var iter = award.subaward();
            foreach (RecycleParser.SubawardContext i in iter)
            {
                // TODO Is this working properly? I don't think so!
                var ii = i.str();
                key.Append(ProcessString(ii[0])).Append(',');
                value.Append(ProcessString(ii[1])).Append(',');
                Debug.WriteLine("*** Found ...)" + value);
            }
            --key.Length;
            --value.Length;
            string k = key.ToString();
            string v = value.ToString();
            temp.Add(new ValueTuple<string, string, int>(k, v, reward));
        }
        var setValue = new PointMap(temp);
        return new SetAction<PointMap>(bin.Storage, bin.Key, setValue, script);*/
        return null!;
    }
}