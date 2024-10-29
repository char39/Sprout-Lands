using UnityEngine;

public class FarmLandTile : MonoBehaviour
{
    public bool isFarmLandObject = true;
    
    public void MadeFarmLand(Vector2 pos)
    {
        GameObject farmLandPref = Resources.Load<GameObject>("Object/FarmLand");
        GameObject farmLandObj = Instantiate(farmLandPref, pos, Quaternion.identity);
        if (!isFarmLandObject)
            farmLandObj.transform.SetParent(transform);
    }

    public void RemoveFarmLand() => Destroy(gameObject);
}
