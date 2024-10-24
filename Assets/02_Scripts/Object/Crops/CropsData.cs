using UnityEngine;

public class CropsData : MonoBehaviour, ICrops
{
    private SpriteRenderer sr;
    private BoxCollider2D col;
    public ICrops.CropType Type;
    public ICrops.Growth Growth;

    void Start()
    {
        TryGetComponent(out sr);
        transform.GetChild(0).TryGetComponent(out col);
        UpdateSprite();
    }

    void Update()       // 임시로 Update에 넣어둠
    {
        UpdateSprite();
        UpdateMask();
    }

    public void SetType(ICrops.CropType type) => Type = type;
    public void SetGrowth(ICrops.Growth growth) => Growth = growth;
    public void SetTypeAndGrowth(ICrops.CropType type, ICrops.Growth growth)
    {
        Type = type;
        Growth = growth;
    }

    public void UpdateSprite()
    {
        if (sr == null || (Type != 0) && (int)Growth == 3)
            return;
        sr.sprite = Icons.FarmingPlant_Crops[CropsSprites.Index[(int)Type, (int)Growth]];
    }

    public void UpdateMask()
    {
        if (col == null)
            return;
        Vector2? offset = CropsStructureMasks.offsets[(int)Type, (int)Growth];
        Vector2? size = CropsStructureMasks.sizes[(int)Type, (int)Growth];

        if (offset == null || size == null)
        {
            col.enabled = false;
            return;
        }
        else
        {
            col.enabled = true;
            col.offset = (Vector2)offset;
            col.size = (Vector2)size;
        }
    }
}