using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI : MonoBehaviour
{
    private static GUI Instance_;
    public static GUI Instance { get { return Instance_; } }

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
