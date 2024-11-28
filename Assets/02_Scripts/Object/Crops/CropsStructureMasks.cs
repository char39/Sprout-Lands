using UnityEngine;

public static class CropsStructureMasks
{
    public static Vector2?[,] offsets;
    public static Vector2?[,] sizes;

    static CropsStructureMasks() => SetVars();

    private static void SetVars()
    {
        offsets = new Vector2?[,]
        {
            { new(0.0f, 0.125f), new(0.0f, 0.125f), new(0.0f, 0.125f), new(0.0f, 0.125f), new(0.0f, 0.125f) },
            { new(0.0f, 0.125f), new(0.0f, 0.125f), new(0.0f, 0.125f),              null, new(0.0f, 0.125f) },
            { new(0.0f, 0.125f), new(0.0f, 0.125f), new(0.0f, 0.125f),              null, new(0.0f, 0.125f) },
            { new(0.0f, 0.125f), new(0.0f, 0.125f), new(0.0f, 0.125f),              null, new(0.0f, 0.125f) },
            { new(0.0f, 0.125f), new(0.0f, 0.125f), new(0.0f, 0.125f),              null, new(0.0f, 0.125f) },
            { new(0.0f, 0.125f), new(0.0f, 0.125f), new(0.0f, 0.125f),              null, new(0.0f, 0.125f) },
            { new(0.0f, 0.125f), new(0.0f, 0.125f), new(0.0f, 0.125f),              null, new(0.0f, 0.125f) },
            { new(0.0f, 0.125f), new(0.0f, 0.125f), new(0.0f, 0.125f),              null, new(0.0f, 0.125f) },
            { new(0.0f, 0.125f), new(0.0f, 0.125f), new(0.0f, 0.125f),              null, new(0.0f, 0.125f) },
            { new(0.0f, 0.125f), new(0.0f, 0.125f), new(0.0f, 0.125f),              null, new(0.0f, 0.125f) },
            { new(0.0f, 0.125f), new(0.0f, 0.125f), new(0.0f, 0.125f),              null, new(0.0f, 0.125f) },
            { new(0.0f, 0.125f), new(0.0f, 0.125f), new(0.0f, 0.125f),              null, new(0.0f, 0.125f) },
            { new(0.0f, 0.125f), new(0.0f, 0.125f), new(0.0f, 0.125f),              null, new(0.0f, 0.125f) },
            { new(0.0f, 0.125f), new(0.0f, 0.125f), new(0.0f, 0.125f),              null, new(0.0f, 0.125f) },
        };

        sizes = new Vector2?[,]
        {
            {              null,              null,              null,  new(0.5f, 0.25f),  new(0.5f, 0.25f) },
            {              null,              null, new(0.25f, 0.25f),              null,  new(0.5f, 0.25f) },
            {              null,              null,  new(0.5f, 0.25f),              null,  new(0.5f, 0.25f) },
            {              null,              null,  new(0.5f, 0.25f),              null,  new(0.5f, 0.25f) },
            {              null,              null,  new(0.5f, 0.25f),              null,  new(0.5f, 0.25f) },
            {              null,              null,              null,              null,              null },
            {              null,              null,              null,              null,  new(0.5f, 0.25f) },
            {              null,              null,              null,              null,              null },
            {              null,  new(0.5f, 0.25f),  new(0.5f, 0.25f),              null,  new(0.5f, 0.25f) },
            {              null,              null, new(0.25f, 0.25f),              null,  new(0.5f, 0.25f) },
            {              null,              null, new(0.25f, 0.25f),              null,  new(0.5f, 0.25f) },
            {              null,              null, new(0.25f, 0.25f),              null,  new(0.5f, 0.25f) },
            {              null,              null,  new(0.5f, 0.25f),              null,  new(0.5f, 0.25f) },
            {              null,  new(0.5f, 0.25f),  new(0.5f, 0.25f),              null,  new(0.5f, 0.25f) },
        };
    }
}