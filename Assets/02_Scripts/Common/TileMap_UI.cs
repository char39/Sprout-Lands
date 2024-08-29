using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap_UI : MonoBehaviour
{
    private static TileMap_UI Instance_;
    public static TileMap_UI Instance { get { return Instance_; } }

    void Start()
    {
        if (Instance_ == null)
            Instance_ = this;
        else if (Instance_ != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        GameManager.Instance.SetUIFollowTarget(transform);
    }
}
