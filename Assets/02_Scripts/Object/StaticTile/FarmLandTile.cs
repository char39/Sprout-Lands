using UnityEngine;

public class FarmLandTile : MonoBehaviour
{
    public bool isFarmLandObject = true;
    
    public void MadeFarmLand(Vector2 pos)
    {
        GameObject farmLandPref = Resources.Load<GameObject>("Object/FarmLand");
        Instantiate(farmLandPref, pos, Quaternion.identity);
    }

    public void RemoveFarmLand() => Destroy(gameObject);
}
