using System.Collections.Generic;

public static class ItemManager
{
    internal readonly static Dictionary<int, Item> toolItem;
    internal readonly static Dictionary<int, Item> farmingPlantItem;
    internal readonly static Dictionary<int, Item> fruitItem;
    internal readonly static Dictionary<int, Item> eggItem;
    internal readonly static Dictionary<int, Item> milkItem;
    //internal static readonly Dictionary<int, GroundTileItem> groundTileItem;

    static ItemManager()
    {
        toolItem = new Dictionary<int, Item>()
        {
            { 1, new ToolItem(Icons.Tool[0], 1, "Watering Can",     1, 1, false, 30, 30) },
            { 2, new ToolItem(Icons.Tool[1], 2, "Axe",              1, 1, false, 0, -1) },
            { 3, new ToolItem(Icons.Tool[2], 3, "Hoe",              1, 1, false, 0, -1) },
            { 4, new ToolItem(Icons.Tool[3], 4, "Grass",            1, 255, false) },
            { 5, new ToolItem(Icons.Tool[4], 5, "Tree Twigs",       1, 255, false) },
            { 6, new ToolItem(Icons.Tool[5], 6, "Tree Branch",      1, 255, false) },
            { 7, new ToolItem(Icons.Tool[6], 7, "Wood",             1, 255, false) },
            { 8, new ToolItem(Icons.Tool[7], 8, "Stick",            1, 255, false) },
            { 9, new ToolItem(Icons.Tool[8], 9, "Wooden Planks",    1, 255, false) },
            { 10, new ToolItem(Icons.Tool[9], 10, "Stone",          1, 255, false) },
            { 11, new ToolItem(Icons.Tool[10], 11, "Iron Ingot",    1, 255, false) },
            { 12, new ToolItem(Icons.Tool[11], 12, "Small Stone",   1, 255, false) }
        };
        farmingPlantItem = new Dictionary<int, Item>()
        {
            { 1001, new FarmingPlantItem(Icons.FarmingPlant[1], 1001, "Corn Seed",            1, 255, false) },
            { 1002, new FarmingPlantItem(Icons.FarmingPlant[2], 1002, "Corn",                 1, 255, true) },
            { 1003, new FarmingPlantItem(Icons.FarmingPlant[3], 1003, "Carrot Seed",          1, 255, false) },
            { 1004, new FarmingPlantItem(Icons.FarmingPlant[4], 1004, "Carrot",               1, 255, true) },
            { 1005, new FarmingPlantItem(Icons.FarmingPlant[5], 1005, "Cauliflower Seed",     1, 255, false) },
            { 1006, new FarmingPlantItem(Icons.FarmingPlant[6], 1006, "Cauliflower",          1, 255, true) },
            { 1007, new FarmingPlantItem(Icons.FarmingPlant[7], 1007, "Tomato Seed",          1, 255, false) },
            { 1008, new FarmingPlantItem(Icons.FarmingPlant[8], 1008, "Tamato",               1, 255, true) },
            { 1009, new FarmingPlantItem(Icons.FarmingPlant[9], 1009, "EggPlant Seed",        1, 255, false) },
            { 1010, new FarmingPlantItem(Icons.FarmingPlant[10], 1010, "EggPlant",            1, 255, true) },
            { 1011, new FarmingPlantItem(Icons.FarmingPlant[11], 1011, "Flower Seed",         1, 255, false) },
            { 1012, new FarmingPlantItem(Icons.FarmingPlant[12], 1012, "Flower",              1, 255, true) },
            { 1013, new FarmingPlantItem(Icons.FarmingPlant[13], 1013, "Lettuce Seed",        1, 255, false) },
            { 1014, new FarmingPlantItem(Icons.FarmingPlant[14], 1014, "Lettuce",             1, 255, true) },
            { 1015, new FarmingPlantItem(Icons.FarmingPlant[15], 1015, "Wheat Seed",          1, 255, false) },
            { 1016, new FarmingPlantItem(Icons.FarmingPlant[16], 1016, "Wheat",               1, 255, true) },
            { 1017, new FarmingPlantItem(Icons.FarmingPlant[17], 1017, "Pumpkin Seed",        1, 255, false) },
            { 1018, new FarmingPlantItem(Icons.FarmingPlant[18], 1018, "Pumpkin",             1, 255, true) },
            { 1019, new FarmingPlantItem(Icons.FarmingPlant[19], 1019, "Radish Seed",         1, 255, false) },
            { 1020, new FarmingPlantItem(Icons.FarmingPlant[20], 1020, "Radish",              1, 255, true) },
            { 1021, new FarmingPlantItem(Icons.FarmingPlant[21], 1021, "Amaranth Seed",       1, 255, false) },
            { 1022, new FarmingPlantItem(Icons.FarmingPlant[22], 1022, "Amaranth",            1, 255, true) },
            { 1023, new FarmingPlantItem(Icons.FarmingPlant[23], 1023, "Turnip Seed",         1, 255, false) },
            { 1024, new FarmingPlantItem(Icons.FarmingPlant[24], 1024, "Turnip",              1, 255, true) },
            { 1025, new FarmingPlantItem(Icons.FarmingPlant[25], 1025, "StarFruit Seed",      1, 255, false) },
            { 1026, new FarmingPlantItem(Icons.FarmingPlant[26], 1026, "StarFruit",           1, 255, true) },
            { 1027, new FarmingPlantItem(Icons.FarmingPlant[27], 1027, "Bean Seed",           1, 255, false) },
            { 1028, new FarmingPlantItem(Icons.FarmingPlant[28], 1028, "Bean",                1, 255, true) }
        };
        fruitItem = new Dictionary<int, Item>()
        {
            { 2001, new FruitItem(Icons.Fruit[0], 2001, "Apple",          1, 255, true) },
            { 2002, new FruitItem(Icons.Fruit[1], 2002, "Orange",         1, 255, true) },
            { 2003, new FruitItem(Icons.Fruit[2], 2003, "Pear",           1, 255, true) },
            { 2004, new FruitItem(Icons.Fruit[3], 2004, "Peach",          1, 255, true) },
            { 2005, new FruitItem(Icons.Fruit[4], 2005, "Strawberry",     1, 255, true) },
            { 2006, new FruitItem(Icons.Fruit[5], 2006, "Grape",          1, 255, true) },
            { 2007, new FruitItem(Icons.Fruit[6], 2007, "Juniperberry",   1, 255, true) }
        };
        eggItem = new Dictionary<int, Item>()
        {
            { 3001, new EggItem(Icons.Egg[0], 3001, "Egg",        1, 255, false) },
            { 3002, new EggItem(Icons.Egg[1], 3002, "Brown Egg",  1, 255, false) },
            { 3003, new EggItem(Icons.Egg[2], 3003, "Red Egg",    1, 255, false) },
            { 3004, new EggItem(Icons.Egg[3], 3004, "Green Egg",  1, 255, false) },
            { 3005, new EggItem(Icons.Egg[4], 3005, "Blue Egg",   1, 255, false) }
        };
        milkItem = new Dictionary<int, Item>()
        {
            { 4001, new MilkItem(Icons.Milk[0], 4001, "Bottle",                               1, 255, false) },
            { 4002, new MilkItem(Icons.Milk[1], 4002, "Big Bottle",                           1, 255, false) },
            { 4003, new MilkItem(Icons.Milk[2], 4003, "Light Milk Bottle Half",               1, 255, true) },
            { 4004, new MilkItem(Icons.Milk[3], 4004, "Light Milk Bottle Half Label",         1, 255, true) },
            { 4005, new MilkItem(Icons.Milk[8], 4005, "Light Milk Big Bottle Half",           1, 255, true) },
            { 4006, new MilkItem(Icons.Milk[9], 4006, "Light Milk Big Bottle Half Label",     1, 255, true) },
            { 4007, new MilkItem(Icons.Milk[6], 4007, "Light Milk Bottle",                    1, 255, true) },
            { 4008, new MilkItem(Icons.Milk[7], 4008, "Light Milk Bottle Label",              1, 255, true) },
            { 4009, new MilkItem(Icons.Milk[4], 4009, "Light Milk Big Bottle",                1, 255, true) },
            { 4010, new MilkItem(Icons.Milk[5], 4010, "Light Milk Big Bottle Label",          1, 255, true) },
            { 4011, new MilkItem(Icons.Milk[10], 4011, "Brown Milk Bottle Half",              1, 255, true) },
            { 4012, new MilkItem(Icons.Milk[11], 4012, "Brown Milk Bottle Half Label",        1, 255, true) },
            { 4013, new MilkItem(Icons.Milk[12], 4013, "Brown Milk Big Bottle Half",          1, 255, true) },
            { 4014, new MilkItem(Icons.Milk[13], 4014, "Brown Milk Big Bottle Half Label",    1, 255, true) },
            { 4015, new MilkItem(Icons.Milk[14], 4015, "Brown Milk Bottle",                   1, 255, true) },
            { 4016, new MilkItem(Icons.Milk[15], 4016, "Brown Milk Bottle Label",             1, 255, true) },
            { 4017, new MilkItem(Icons.Milk[16], 4017, "Brown Milk Big Bottle",               1, 255, true) },
            { 4018, new MilkItem(Icons.Milk[17], 4018, "Brown Milk Big Bottle Label",         1, 255, true) },
            { 4019, new MilkItem(Icons.Milk[18], 4019, "Purple Milk Bottle Half",             1, 255, true) },
            { 4020, new MilkItem(Icons.Milk[19], 4020, "Purple Milk Bottle Half Label",       1, 255, true) },
            { 4021, new MilkItem(Icons.Milk[20], 4021, "Purple Milk Big Bottle Half",         1, 255, true) },
            { 4022, new MilkItem(Icons.Milk[21], 4022, "Purple Milk Big Bottle Half Label",   1, 255, true) },
            { 4023, new MilkItem(Icons.Milk[22], 4023, "Purple Milk Bottle",                  1, 255, true) },
            { 4024, new MilkItem(Icons.Milk[23], 4024, "Purple Milk Bottle Label",            1, 255, true) },
            { 4025, new MilkItem(Icons.Milk[24], 4025, "Purple Milk Big Bottle",              1, 255, true) },
            { 4026, new MilkItem(Icons.Milk[25], 4026, "Purple Milk Big Bottle Label",        1, 255, true) },
            { 4027, new MilkItem(Icons.Milk[26], 4027, "Pink Milk Bottle Half",               1, 255, true) },
            { 4028, new MilkItem(Icons.Milk[27], 4028, "Pink Milk Bottle Half Label",         1, 255, true) },
            { 4029, new MilkItem(Icons.Milk[28], 4029, "Pink Milk Big Bottle Half",           1, 255, true) },
            { 4030, new MilkItem(Icons.Milk[29], 4030, "Pink Milk Big Bottle Half Label",     1, 255, true) },
            { 4031, new MilkItem(Icons.Milk[30], 4031, "Pink Milk Bottle",                    1, 255, true) },
            { 4032, new MilkItem(Icons.Milk[31], 4032, "Pink Milk Bottle Label",              1, 255, true) },
            { 4033, new MilkItem(Icons.Milk[32], 4033, "Pink Milk Big Bottle",                1, 255, true) },
            { 4034, new MilkItem(Icons.Milk[33], 4034, "Pink Milk Big Bottle Label",          1, 255, true) },
            { 4035, new MilkItem(Icons.Milk[34], 4035, "Green Milk Bottle Half",              1, 255, true) },
            { 4036, new MilkItem(Icons.Milk[35], 4036, "Green Milk Bottle Half Label",        1, 255, true) },
            { 4037, new MilkItem(Icons.Milk[36], 4037, "Green Milk Big Bottle Half",          1, 255, true) },
            { 4038, new MilkItem(Icons.Milk[37], 4038, "Green Milk Big Bottle Half Label",    1, 255, true) },
            { 4039, new MilkItem(Icons.Milk[38], 4039, "Green Milk Bottle",                   1, 255, true) },
            { 4040, new MilkItem(Icons.Milk[39], 4040, "Green Milk Bottle Label",             1, 255, true) },
            { 4041, new MilkItem(Icons.Milk[40], 4041, "Green Milk Big Bottle",               1, 255, true) },
            { 4042, new MilkItem(Icons.Milk[41], 4042, "Green Milk Big Bottle Label",         1, 255, true) }
        };
    }

    public static ToolItem GetToolItem(int id, int quantity = 1)
    {
        ToolItem item = (ToolItem)toolItem?[id] ?? null;
        item?.SetStack(quantity);
        return item;
    }

    public static FarmingPlantItem GetFarmingPlantItem(int id, int quantity = 1)
    {
        FarmingPlantItem item = (FarmingPlantItem)farmingPlantItem?[id] ?? null;
        item?.SetStack(quantity);
        return item;
    }

    public static FruitItem GetFruitItem(int id, int quantity = 1)
    {
        FruitItem item = (FruitItem)fruitItem?[id] ?? null;
        item?.SetStack(quantity);
        return item;
    }

    public static EggItem GetEggItem(int id, int quantity = 1)
    {
        EggItem item = (EggItem)eggItem?[id] ?? null;
        item?.SetStack(quantity);
        return item;
    }

    public static MilkItem GetMilkItem(int id, int quantity = 1)
    {
        MilkItem item = (MilkItem)milkItem?[id] ?? null;
        item?.SetStack(quantity);
        return item;
    }
}
