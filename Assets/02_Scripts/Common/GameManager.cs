using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public GM_CameraSetting CameraSetting;
    public GM_GameTimeRule gameTimeRule;
    public GM_DateInfo DateInfo;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        AddComponent();
    }

    private void AddComponent()
    {
        CameraSetting = gameObject.AddComponent<GM_CameraSetting>();
        gameTimeRule = gameObject.AddComponent<GM_GameTimeRule>();
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
