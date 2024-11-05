public interface ITree
{
    public enum Type
    {
        Bush,
        SmallTree,
        Tree,
        BigTree
    }

    public enum State
    {
        Normal,
        Harvest,
        Stump,
        Wood
    }

    public const string BounceTrigger = "Bounce";
    public const string TreeMoveTrigger = "TreeMove";
    public const string FruitDropTrigger = "FruitDrop";
}
