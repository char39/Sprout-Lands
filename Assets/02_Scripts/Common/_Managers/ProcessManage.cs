using UnityEngine;

public class ProcessManage : MonoBehaviour
{
    public GameTimeRule gameTimeRule;
    public Lights_Global light_Global;

    void Awake()
    {
        gameTimeRule = gameObject.AddComponent<GameTimeRule>();
    }

    void Start()
    {
        light_Global = FindObjectOfType<Lights_Global>();
    }
}
