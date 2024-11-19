public interface ITree
{
    public enum Type
    {
        Bush,
        SmallTree,
        Tree,
        BigTree,
        GiantTree
    }

    public enum State
    {
        Sprout,
        Small,
        Normal,
        Harvest,
        Stump,
        Wood
    }

    public const string BounceTrigger = "Bounce";
    public const string TreeMoveTrigger = "TreeMove";
    public const string FruitDropTrigger = "FruitDrop";
}
