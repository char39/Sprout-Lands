using UnityEngine;

public class ProcessManage : MonoBehaviour
{
    public GM_GameTimeRule gameTimeRule;
    public Lights_Global light_Global;

    void Awake()
    {
        gameTimeRule = gameObject.AddComponent<GM_GameTimeRule>();
    }

    void Start()
    {
        light_Global = FindObjectOfType<Lights_Global>();
    }
}
