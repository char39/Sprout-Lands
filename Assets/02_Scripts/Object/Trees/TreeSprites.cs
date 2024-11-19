public static class TreeSprites
{
    public static int[,] Index;

    static TreeSprites()
    {
        Index = new int[,]
        {
            { -1, 21, 22, 22, -1, -1 }, // Bush
            { -1, -1,  7, -1,  0, -1 }, // SmallTree
            { 34,  7,  8,  8,  1,  4 }, // Tree
            { -1, -1, 33, -1,  2,  5 }, // BigTree
            { -1, -1, -1, -1,  3, -1 }, // GiantTree
        };
    }
}