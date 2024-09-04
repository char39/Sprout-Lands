using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    private static GameManager Instance_;
    public static GameManager Instance { get { return Instance_; } }

    public GM_CameraSetting CameraSetting;
    public GameTimeRule gameTimeRule;
    public GM_DateInfo DateInfo;

    void Awake()
    {
        if (Instance_ == null)
            Instance_ = this;
        else if (Instance_ != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        AddComponent();
    }

    private void AddComponent()
    {
        CameraSetting = gameObject.AddComponent<GM_CameraSetting>();
        gameTimeRule = gameObject.AddComponent<GameTimeRule>();
        DateInfo = gameObject.AddComponent<GM_DateInfo>();
    }

    void Start()
    {
        CameraSetting.MainCam = Camera.main.transform;
    }

    void Update()
    {
        CameraSetting.ResetCameraPosLimit();
        CameraSetting.CameraFollow();
    }
}
