using UnityEngine;

public static class TreesStructureMasks
{
    public static Vector2?[,] maskOffsets;
    public static Vector2?[,] maskSizes;
    public static Vector2?[,] orderOffsets;
    public static Vector2?[,] orderSizes;
    public static Vector2?[,] alphaOffsets;
    public static Vector2?[,] alphaSizes;


    static TreesStructureMasks() => SetVars();

    private static void SetVars()
    {
        maskOffsets = new Vector2?[,]
        {
            {              null,              null,              null,              null,              null,              null },
            {              null,              null, new(0.0f, 0.125f),              null, new(0.0f, 0.125f),              null },
            {              null, new(0.0f, 0.125f), new(0.0f, 0.125f), new(0.0f, 0.125f), new(0.0f, 0.125f), new(0.0f, 0.125f) },
            {              null,              null, new(0.0f, 0.125f),              null, new(0.0f, 0.125f),new(0.0f, 0.0625f) },
            {              null,              null,              null,              null, new(0.0f, 0.125f),              null },
        };

        maskSizes = new Vector2?[,]
        {
            {              null,              null,              null,              null,              null,              null },
            {              null,              null,  new(0.5f, 0.25f),              null,  new(0.5f, 0.25f),              null },
            {              null,  new(0.5f, 0.25f),  new(0.5f, 0.25f),  new(0.5f, 0.25f),  new(0.5f, 0.25f),new(0.875f, 0.25f) },
            {              null,              null,  new(0.5f, 0.25f),              null,  new(0.5f, 0.25f), new(1.25f, 0.25f) },
            {              null,              null,              null,              null, new(0.85f, 0.25f),              null },
        };

        orderOffsets = new Vector2?[,]
        {
            {              null,   new(0.0f, 0.9f),   new(0.0f, 0.9f),   new(0.0f, 0.9f),              null,              null },
            {              null,              null,   new(0.0f, 1.2f),              null,   new(0.0f, 1.0f),              null },
            {   new(0.0f, 1.0f),   new(0.0f, 1.2f),   new(0.0f, 1.0f),   new(0.0f, 1.0f),   new(0.0f, 1.0f),   new(0.0f, 1.0f) },
            {              null,              null,  new(0.0f, 1.69f),              null,   new(0.0f, 1.0f),   new(0.0f, 1.0f) },
            {              null,              null,              null,              null,   new(0.0f, 1.0f),              null },
        };

        orderSizes = new Vector2?[,]
        {
            {              null,   new(2.5f, 2.0f),   new(2.5f, 2.0f),   new(2.5f, 2.0f),              null,              null },
            {              null,              null,   new(2.5f, 2.4f),              null,   new(2.5f, 2.0f),              null },
            {   new(2.5f, 2.0f),   new(2.5f, 2.4f),   new(2.5f, 2.0f),   new(2.5f, 2.0f),   new(2.5f, 2.0f),   new(2.5f, 2.0f) },
            {              null,              null,   new(5.0f, 3.5f),              null,   new(2.5f, 2.0f),   new(2.5f, 2.0f) },
            {              null,              null,              null,              null,   new(2.5f, 2.0f),              null },
        };

        alphaOffsets = new Vector2?[,]
        {
            {              null, new(0.0f, 0.025f), new(0.0f, 0.025f), new(0.0f, 0.025f),              null,              null },
            {              null,              null, new(0.0f, 0.625f),              null,              null,              null },
            { new(0.0f, -0.05f), new(0.0f, 0.625f), new(0.0f, 0.625f), new(0.0f, 0.625f),              null,              null },
            {              null,              null,  new(0.0f, 1.35f),              null,              null,              null },
            {              null,              null,              null,              null,              null,              null },
        };

        alphaSizes = new Vector2?[,]
        {
            {              null,  new(0.75f, 0.7f),  new(1.25f, 0.7f),  new(1.25f, 0.7f),              null,              null },
            {              null,              null, new(0.75f, 1.25f),              null,              null,              null },
            {  new(0.5f, 0.65f), new(0.75f, 1.25f), new(1.25f, 1.25f), new(1.25f, 1.25f),              null,              null },
            {              null,              null,  new(2.75f, 2.5f),              null,              null,              null },
            {              null,              null,              null,              null,              null,              null },
        };
    }
}