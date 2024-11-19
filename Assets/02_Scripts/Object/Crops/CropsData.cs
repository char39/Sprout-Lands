using UnityEngine;

public class CropsData : MonoBehaviour, ICrops
{
    [HideInInspector] public SpriteRenderer sr;
    [HideInInspector] public BoxCollider2D col;
    public ICrops.CropType Type;
    public ICrops.Growth Growth;
    public bool IsWatered { get; private set; }

    void Start()
    {
        TryGetComponent(out sr);
        transform.GetChild(0).TryGetComponent(out col);
    }

    void Update()       // 임시로 Update에 넣어둠
    {
        RefreshAll();
    }

    public void SetWatered(bool isWatered)
    {
        IsWatered = isWatered;
        transform.GetChild(3).GetComponent<SpriteRenderer>().enabled = isWatered;
    }

    public void SetType(ICrops.CropType type) => Type = type;
    public void SetGrowth(ICrops.Growth growth) => Growth = growth;
    public void SetTypeAndGrowth(ICrops.CropType type, ICrops.Growth growth)
    {
        Type = type;
        Growth = growth;
    }

    public void SetSprite()
    {
        if (sr == null || (Type != 0) && (int)Growth == 3)
            return;
        sr.sprite = Icons.FarmingPlant_Crops[CropsSprites.Index[(int)Type, (int)Growth]];
    }

    public void SetMask()
    {
        if (col == null)
            return;
        Vector2? offset = CropsStructureMasks.offsets[(int)Type, (int)Growth];
        Vector2? size = CropsStructureMasks.sizes[(int)Type, (int)Growth];

        if (offset == null || size == null)
            col.enabled = false;
        else
        {
            col.enabled = true;
            col.offset = (Vector2)offset;
            col.size = (Vector2)size;
        }
    }

    public void RefreshAll()
    {
        SetSprite();
        SetMask();
    }

    public void Hoeing()
    {
        GameObject item_droped_pref = Resources.Load<GameObject>("Object/GameItem_Droped");

        if (Growth == ICrops.Growth.Harvest)
        {
            int cropsStack = Random.Range(3, 6);
            int seedStack = (int)Random.Range(1.5f, 4f);
            Vector2 cropsPos = Random.insideUnitCircle.normalized * 0.15f;
            Vector2 seedPos = -cropsPos;
            int cropsID = ((int)Type * 2) + 1002;   // 농작물 ID
            int seedID = ((int)Type * 2) + 1001;    // 씨앗 ID
            GameObject crops = Instantiate(item_droped_pref, transform.position + (Vector3)cropsPos, Quaternion.identity);
            crops.TryGetComponent(out Item_Droped item_droped_crops);
            item_droped_crops.SetItem(ItemManager.GetFarmingPlantItem(cropsID, cropsStack));
            GameObject seed = Instantiate(item_droped_pref, transform.position + (Vector3)seedPos, Quaternion.identity);
            seed.TryGetComponent(out Item_Droped item_droped_seed);
            item_droped_seed.SetItem(ItemManager.GetFarmingPlantItem(seedID, seedStack));

            Destroy(gameObject);
        }
        else
        {
            int seedStack = Random.Range(0, 2);
            if (seedStack != 0)
            {
                int seedID = ((int)Type * 2) + 1001;    // 씨앗 ID
                Vector2 seedPos = Random.insideUnitCircle.normalized * 0.15f;
                GameObject seed = Instantiate(item_droped_pref, transform.position + (Vector3)seedPos, Quaternion.identity);
                seed.TryGetComponent(out Item_Droped item_droped_seed);
                item_droped_seed.SetItem(ItemManager.GetFarmingPlantItem(seedID, seedStack));
            }

            Destroy(gameObject);
        }

    }

    private void OnDrawGizmos()
    {
        // 캐릭터의 움직임이 불가한 구역을 표시
        Gizmos.color = new Color(1, 1, 0, 0.5f);
        Vector2? offset = CropsStructureMasks.offsets[(int)Type, (int)Growth];
        Vector2? size = CropsStructureMasks.sizes[(int)Type, (int)Growth];
        if (offset == null || size == null)
            return;
        Gizmos.DrawWireCube(transform.position + (Vector3)offset, (Vector2)size);
    }
}