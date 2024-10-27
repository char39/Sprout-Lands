public interface ICrops
{
    public enum CropType
    {
        Corn,
        Carrot,
        Cauliflower,
        Tomato,
        EggPlant,
        Flower,
        Lettuce,
        Wheat,
        Pumpkin,
        Radish,
        Amaranth,
        Turnip,
        StarFruit,
        Bean
    }
    
    public enum Growth
    {
        Sprout,
        Growth1,
        Growth2,
        Growth3,
        Harvest
    }

    public bool IsWatered { get; }

    public void SetType(CropType type);
    public void SetGrowth(Growth growth);
    public void SetTypeAndGrowth(CropType type, Growth growth);
    public void SetSprite();
    public void SetMask();
}