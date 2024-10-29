using UnityEngine;

public class GM_GameTimeRule : MonoBehaviour
{
    public const float GameTimeRatio = 30f;      // GameTimeRatio 초 = 게임시간 1시간
    public const float StartTime = 6f;
    public float GameTime;          // 게임시간
    public int GameTimeHour;        // 게임시간 시
    public int GameTimeMinute;      // 게임시간 분

    public bool IsGameTimeFreeze = false;       // 게임시간 멈춤

    void Start()
    {
        GameTime = StartTime * GameTimeRatio;
    }

    void Update()
    {
        IncreaseGameTime();
        ConvertTime();
    }

    private void IncreaseGameTime() => GameTime += IsGameTimeFreeze ? 0 : Time.deltaTime;
    private void ConvertTime()
    {
        int hour = (int)(GameTime / GameTimeRatio);
        GameTimeHour = (hour % 12) == 0 ? 12 : (hour % 12);
        GameTimeMinute = (int)(GameTime / GameTimeRatio * 60) % 60;
    }
    public bool CheckMorning() => GameTime % (GameTimeRatio * 24) < GameTimeRatio * 12;
}
