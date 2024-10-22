using UnityEngine;

public class CropsData : MonoBehaviour, ICrops
{
    public ICrops.CropType Type { get; set; }
    public ICrops.Growth Growth { get; set; }
}


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
}