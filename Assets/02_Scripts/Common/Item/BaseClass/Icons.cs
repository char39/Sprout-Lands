using UnityEngine;

public static class Icons
{
    public static Sprite[] Tool;
    public static Sprite[] FarmingPlant;
    public static Sprite[] Fruit;
    public static Sprite[] Egg;
    public static Sprite[] Milk;
    public static Sprite[] GroundTile;
    public static Sprite ItemShadow;

    public static Sprite[] FarmingPlant_Crops;
    public static Sprite[] InventorySpritesheet;
    public static Sprite[] DurabilityBar;

    static Icons()
    {
        LoadSprites();
    }

    private static void LoadSprites()
    {
        Tool = Resources.LoadAll<Sprite>("Item/Tool");
        FarmingPlant = Resources.LoadAll<Sprite>("Item/FarmingPlant");
        Fruit = Resources.LoadAll<Sprite>("Item/Fruit");
        Egg = Resources.LoadAll<Sprite>("Item/Egg");
        Milk = Resources.LoadAll<Sprite>("Item/Milk");
        GroundTile = Resources.LoadAll<Sprite>("Item/GroundTile");
        ItemShadow = Resources.Load<Sprite>("Item/ItemShadow");

        FarmingPlant_Crops = Resources.LoadAll<Sprite>("Item/Farming Plants");
        InventorySpritesheet = Resources.LoadAll<Sprite>("UI/Inventory/Inventory_Spritesheet");
        DurabilityBar = Resources.LoadAll<Sprite>("UI/Inventory/DurabilityBar");
    }
}