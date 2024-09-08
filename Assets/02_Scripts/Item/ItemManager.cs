using System.Collections.Generic;

public static class ItemManager
{
    internal static Dictionary<int, ToolItem> toolItem;
    internal static Dictionary<int, FarmingPlantItem> farmingPlantItem;
    internal static Dictionary<int, FruitItem> fruitItem;
    internal static Dictionary<int, EggItem> eggItem;
    internal static Dictionary<int, MilkItem> milkItem;
    //internal static readonly Dictionary<int, GroundTileItem> groundTileItem;

    static ItemManager()
    {
        toolItem = new Dictionary<int, ToolItem>()
        {
            { 1, new ToolItem(Icons.Tool[0], 1, "Watering Can",     1, 1, false) },
            { 2, new ToolItem(Icons.Tool[1], 2, "Axe",              1, 1, false) },
            { 3, new ToolItem(Icons.Tool[2], 3, "Hoe",              1, 1, false) },
            { 4, new ToolItem(Icons.Tool[3], 4, "Grass",            1, 255, true) },
            { 5, new ToolItem(Icons.Tool[4], 5, "Tree Twigs",       1, 255, true) },
            { 6, new ToolItem(Icons.Tool[5], 6, "Tree Branch",      1, 255, true) },
            { 7, new ToolItem(Icons.Tool[6], 7, "Wood",             1, 255, true) },
            { 8, new ToolItem(Icons.Tool[7], 8, "Stick",            1, 255, true) },
            { 9, new ToolItem(Icons.Tool[8], 9, "Wooden Planks",    1, 255, true) },
            { 10, new ToolItem(Icons.Tool[9], 10, "Stone",          1, 255, true) },
            { 11, new ToolItem(Icons.Tool[10], 11, "Iron Ingot",    1, 255, true) },
            { 12, new ToolItem(Icons.Tool[11], 12, "Small Stone",   1, 255, true) }
        };
        farmingPlantItem = new Dictionary<int, FarmingPlantItem>()
        {
            { 1, new FarmingPlantItem(Icons.FarmingPlant[1], 1, "Corn Seed",            1, 255, false) },
            { 2, new FarmingPlantItem(Icons.FarmingPlant[2], 2, "Corn",                 1, 255, true) },
            { 3, new FarmingPlantItem(Icons.FarmingPlant[3], 3, "Carrot Seed",          1, 255, false) },
            { 4, new FarmingPlantItem(Icons.FarmingPlant[4], 4, "Carrot",               1, 255, true) },
            { 5, new FarmingPlantItem(Icons.FarmingPlant[5], 5, "Cauliflower Seed",     1, 255, false) },
            { 6, new FarmingPlantItem(Icons.FarmingPlant[6], 6, "Cauliflower",          1, 255, true) },
            { 7, new FarmingPlantItem(Icons.FarmingPlant[7], 7, "Tomato Seed",          1, 255, false) },
            { 8, new FarmingPlantItem(Icons.FarmingPlant[8], 8, "Tamato",               1, 255, true) },
            { 9, new FarmingPlantItem(Icons.FarmingPlant[9], 9, "EggPlant Seed",        1, 255, false) },
            { 10, new FarmingPlantItem(Icons.FarmingPlant[10], 10, "EggPlant",          1, 255, true) },
            { 11, new FarmingPlantItem(Icons.FarmingPlant[11], 11, "Flower Seed",       1, 255, false) },
            { 12, new FarmingPlantItem(Icons.FarmingPlant[12], 12, "Flower",            1, 255, true) },
            { 13, new FarmingPlantItem(Icons.FarmingPlant[13], 13, "Lettuce Seed",      1, 255, false) },
            { 14, new FarmingPlantItem(Icons.FarmingPlant[14], 14, "Lettuce",           1, 255, true) },
            { 15, new FarmingPlantItem(Icons.FarmingPlant[15], 15, "Wheat Seed",        1, 255, false) },
            { 16, new FarmingPlantItem(Icons.FarmingPlant[16], 16, "Wheat",             1, 255, true) },
            { 17, new FarmingPlantItem(Icons.FarmingPlant[17], 17, "Pumpkin Seed",      1, 255, false) },
            { 18, new FarmingPlantItem(Icons.FarmingPlant[18], 18, "Pumpkin",           1, 255, true) },
            { 19, new FarmingPlantItem(Icons.FarmingPlant[19], 19, "Radish Seed",       1, 255, false) },
            { 20, new FarmingPlantItem(Icons.FarmingPlant[20], 20, "Radish",            1, 255, true) },
            { 21, new FarmingPlantItem(Icons.FarmingPlant[21], 21, "Amaranth Seed",     1, 255, false) },
            { 22, new FarmingPlantItem(Icons.FarmingPlant[22], 22, "Amaranth",          1, 255, true) },
            { 23, new FarmingPlantItem(Icons.FarmingPlant[23], 23, "Turnip Seed",       1, 255, false) },
            { 24, new FarmingPlantItem(Icons.FarmingPlant[24], 24, "Turnip",            1, 255, true) },
            { 25, new FarmingPlantItem(Icons.FarmingPlant[25], 25, "StarFruit Seed",    1, 255, false) },
            { 26, new FarmingPlantItem(Icons.FarmingPlant[26], 26, "StarFruit",         1, 255, true) },
            { 27, new FarmingPlantItem(Icons.FarmingPlant[27], 27, "Bean Seed",         1, 255, false) },
            { 28, new FarmingPlantItem(Icons.FarmingPlant[28], 28, "Bean",              1, 255, true) }
        };
        fruitItem = new Dictionary<int, FruitItem>()
        {
            { 1, new FruitItem(Icons.Fruit[0], 1, "Apple",          1, 255, true) },
            { 2, new FruitItem(Icons.Fruit[1], 2, "Orange",         1, 255, true) },
            { 3, new FruitItem(Icons.Fruit[2], 3, "Pear",           1, 255, true) },
            { 4, new FruitItem(Icons.Fruit[3], 4, "Peach",          1, 255, true) },
            { 5, new FruitItem(Icons.Fruit[4], 5, "Strawberry",     1, 255, true) },
            { 6, new FruitItem(Icons.Fruit[5], 6, "Grape",          1, 255, true) },
            { 7, new FruitItem(Icons.Fruit[6], 7, "Juniperberry",   1, 255, true) }
        };
        eggItem = new Dictionary<int, EggItem>()
        {
            { 1, new EggItem(Icons.Egg[0], 1, "Egg",        1, 255, false) },
            { 2, new EggItem(Icons.Egg[1], 2, "Brown Egg",  1, 255, false) },
            { 3, new EggItem(Icons.Egg[2], 3, "Red Egg",    1, 255, false) },
            { 4, new EggItem(Icons.Egg[3], 4, "Green Egg",  1, 255, false) },
            { 5, new EggItem(Icons.Egg[4], 5, "Blue Egg",   1, 255, false) }
        };
        milkItem = new Dictionary<int, MilkItem>()
        {
            { 1, new MilkItem(Icons.Milk[0], 1, "Bottle",                               1, 255, false) },
            { 2, new MilkItem(Icons.Milk[1], 2, "Big Bottle",                           1, 255, false) },
            { 3, new MilkItem(Icons.Milk[2], 3, "Light Milk Bottle Half",               1, 255, true) },
            { 4, new MilkItem(Icons.Milk[3], 4, "Light Milk Bottle Half Label",         1, 255, true) },
            { 5, new MilkItem(Icons.Milk[8], 5, "Light Milk Big Bottle Half",           1, 255, true) },
            { 6, new MilkItem(Icons.Milk[9], 6, "Light Milk Big Bottle Half Label",     1, 255, true) },
            { 7, new MilkItem(Icons.Milk[6], 7, "Light Milk Bottle",                    1, 255, true) },
            { 8, new MilkItem(Icons.Milk[7], 8, "Light Milk Bottle Label",              1, 255, true) },
            { 9, new MilkItem(Icons.Milk[4], 9, "Light Milk Big Bottle",                1, 255, true) },
            { 10, new MilkItem(Icons.Milk[5], 10, "Light Milk Big Bottle Label",        1, 255, true) },
            { 11, new MilkItem(Icons.Milk[10], 11, "Brown Milk Bottle Half",            1, 255, true) },
            { 12, new MilkItem(Icons.Milk[11], 12, "Brown Milk Bottle Half Label",      1, 255, true) },
            { 13, new MilkItem(Icons.Milk[12], 13, "Brown Milk Big Bottle Half",        1, 255, true) },
            { 14, new MilkItem(Icons.Milk[13], 14, "Brown Milk Big Bottle Half Label",  1, 255, true) },
            { 15, new MilkItem(Icons.Milk[14], 15, "Brown Milk Bottle",                 1, 255, true) },
            { 16, new MilkItem(Icons.Milk[15], 16, "Brown Milk Bottle Label",           1, 255, true) },
            { 17, new MilkItem(Icons.Milk[16], 17, "Brown Milk Big Bottle",             1, 255, true) },
            { 18, new MilkItem(Icons.Milk[17], 18, "Brown Milk Big Bottle Label",       1, 255, true) },
            { 19, new MilkItem(Icons.Milk[18], 19, "Purple Milk Bottle Half",           1, 255, true) },
            { 20, new MilkItem(Icons.Milk[19], 20, "Purple Milk Bottle Half Label",     1, 255, true) },
            { 21, new MilkItem(Icons.Milk[20], 21, "Purple Milk Big Bottle Half",       1, 255, true) },
            { 22, new MilkItem(Icons.Milk[21], 22, "Purple Milk Big Bottle Half Label", 1, 255, true) },
            { 23, new MilkItem(Icons.Milk[22], 23, "Purple Milk Bottle",                1, 255, true) },
            { 24, new MilkItem(Icons.Milk[23], 24, "Purple Milk Bottle Label",          1, 255, true) },
            { 25, new MilkItem(Icons.Milk[24], 25, "Purple Milk Big Bottle",            1, 255, true) },
            { 26, new MilkItem(Icons.Milk[25], 26, "Purple Milk Big Bottle Label",      1, 255, true) },
            { 27, new MilkItem(Icons.Milk[26], 27, "Pink Milk Bottle Half",             1, 255, true) },
            { 28, new MilkItem(Icons.Milk[27], 28, "Pink Milk Bottle Half Label",       1, 255, true) },
            { 29, new MilkItem(Icons.Milk[28], 29, "Pink Milk Big Bottle Half",         1, 255, true) },
            { 30, new MilkItem(Icons.Milk[29], 30, "Pink Milk Big Bottle Half Label",   1, 255, true) },
            { 31, new MilkItem(Icons.Milk[30], 31, "Pink Milk Bottle",                  1, 255, true) },
            { 32, new MilkItem(Icons.Milk[31], 32, "Pink Milk Bottle Label",            1, 255, true) },
            { 33, new MilkItem(Icons.Milk[32], 33, "Pink Milk Big Bottle",              1, 255, true) },
            { 34, new MilkItem(Icons.Milk[33], 34, "Pink Milk Big Bottle Label",        1, 255, true) },
            { 35, new MilkItem(Icons.Milk[34], 35, "Green Milk Bottle Half",            1, 255, true) },
            { 36, new MilkItem(Icons.Milk[35], 36, "Green Milk Bottle Half Label",      1, 255, true) },
            { 37, new MilkItem(Icons.Milk[36], 37, "Green Milk Big Bottle Half",        1, 255, true) },
            { 38, new MilkItem(Icons.Milk[37], 38, "Green Milk Big Bottle Half Label",  1, 255, true) },
            { 39, new MilkItem(Icons.Milk[38], 39, "Green Milk Bottle",                 1, 255, true) },
            { 40, new MilkItem(Icons.Milk[39], 40, "Green Milk Bottle Label",           1, 255, true) },
            { 41, new MilkItem(Icons.Milk[40], 41, "Green Milk Big Bottle",             1, 255, true) },
            { 42, new MilkItem(Icons.Milk[41], 42, "Green Milk Big Bottle Label",       1, 255, true) }
        };
/*      groundTileItem = new Dictionary<int, GroundTileItem>()
        {
            { 1, new GroundTileItem(Icons.GroundTile[0], 1, "Grass", 1, 255, false) },
            { 2, new GroundTileItem(Icons.GroundTile[1], 2, "Dirt", 1, 255, false) },
            { 3, new GroundTileItem(Icons.GroundTile[2], 3, "Stone", 1, 255, false) },
            { 4, new GroundTileItem(Icons.GroundTile[3], 4, "Wood", 1, 255, false) },
            { 5, new GroundTileItem(Icons.GroundTile[4], 5, "Sand", 1, 255, false) },
            { 6, new GroundTileItem(Icons.GroundTile[5], 6, "Water", 1, 255, false) },
            { 7, new GroundTileItem(Icons.GroundTile[6], 7, "Snow", 1, 255, false) },
            { 8, new GroundTileItem(Icons.GroundTile[7], 8, "Ice", 1, 255, false) },
            { 9, new GroundTileItem(Icons.GroundTile[8], 9, "Lava", 1, 255, false) },
            { 10, new GroundTileItem(Icons.GroundTile[9], 10, "Mud", 1, 255, false) },
            { 11, new GroundTileItem(Icons.GroundTile[10], 11, "Gravel", 1, 255, false) },
            { 12, new GroundTileItem(Icons.GroundTile[11], 12, "Clay", 1, 255, false) }
        }; */
    }

    public static ToolItem GetToolItem(int id, int quantity)
    {
        ToolItem item = toolItem?[id] ?? null;
        item.Stack = quantity;
        return item;
    }

    public static FarmingPlantItem GetFarmingPlantItem(int id, int quantity)
    {
        FarmingPlantItem item = farmingPlantItem?[id] ?? null;
        item.Stack = quantity;
        return item;
    }

    public static FruitItem GetFruitItem(int id, int quantity)
    {
        FruitItem item = fruitItem?[id] ?? null;
        item.Stack = quantity;
        return item;
    }

    public static EggItem GetEggItem(int id, int quantity)
    {
        EggItem item = eggItem?[id] ?? null;
        item.Stack = quantity;
        return item;
    }

    public static MilkItem GetMilkItem(int id, int quantity)
    {
        MilkItem item = milkItem?[id] ?? null;
        item.Stack = quantity;
        return item;
    }
}
