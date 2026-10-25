namespace CardStock.FreezeFrame.Tree.Strings;

public interface StringNode : IGameNode
{
    string GetString(GameContext context);
}