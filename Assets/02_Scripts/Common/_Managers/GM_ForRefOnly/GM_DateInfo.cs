using UnityEngine;
using UnityEngine.UI;

public class GM_DateInfo : MonoBehaviour
{
    [HideInInspector] public Transform DateInfo_Frame;
    [HideInInspector] public RectTransform Time_HourHand;

    [HideInInspector] public Image Weather_Now;
    [HideInInspector] public Sprite[] WeatherTexures;
    public enum TimeState { Morning, Afternoon, Night }
    public enum WeatherState { Clear, Cloud, Rain, ShiningSun, Storm, Thunder, Fog }
    public TimeState timeState = TimeState.Morning;
    public WeatherState weatherState = WeatherState.Clear;

    [HideInInspector] public Text Time_Text;
    [HideInInspector] public Text Time_Second;
    [HideInInspector] public Text TimeZone;

    public const float maxAngle = 80f;
    private const string AM = "AM";
    private const string PM = "PM";
    private const string TimeColon = ":";
    [HideInInspector] public float GameTime;
    [HideInInspector] public int GameTimeHour;
    [HideInInspector] public int GameTimeMinute;

    void Start()
    {
        DateInfo_Frame = GameObject.Find("UI_Canvas").transform.GetChild(0);
        Time_HourHand = DateInfo_Frame.GetChild(0).GetChild(0).GetChild(0).GetComponent<RectTransform>();
        Weather_Now = DateInfo_Frame.GetChild(0).GetChild(1).GetChild(1).GetComponent<Image>();
        WeatherTexures = Resources.LoadAll<Sprite>("UI/DateInfo/Weather_Icons_small");
        Time_Text = DateInfo_Frame.GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>();
        Time_Second = Time_Text.transform.GetChild(0).GetComponent<Text>();
        TimeZone = Time_Text.transform.GetChild(1).GetComponent<Text>();
    }

    void Update()
    {
        GameTime = GM.PROCESS.gameTimeRule.GameTime;
        GameTimeHour = GM.PROCESS.gameTimeRule.GameTimeHour;
        GameTimeMinute = GM.PROCESS.gameTimeRule.GameTimeMinute;
        UpdateHourHand();
        UpdateTimeText();
        UpdateTimeState();
        UpdateWeatherImage();
    }

    private void UpdateHourHand()
    {
        // (아침 6시 ~ 저녁 12시) z축 회전값
        float TimeNormal = (GameTime - GM_GameTimeRule.GameTimeRatio * Hour.AM_6) / (GM_GameTimeRule.GameTimeRatio * Hour.PM_6);
        float lerpedAngle = Mathf.LerpAngle(maxAngle, -maxAngle, TimeNormal);
        Time_HourHand.localRotation = Quaternion.Euler(0, 0, lerpedAngle);
    }
    private void UpdateTimeText()
    {
        if (GameTimeMinute % 10 == 0)
            Time_Text.text = GameTimeHour.ToString() + "    " + GameTimeMinute.ToString("00");
        Time_Second.text = (int)(GameTime % 1.5) == 0 ? TimeColon : string.Empty;
        TimeZone.text = GM.PROCESS.gameTimeRule.CheckMorning() ? AM : PM;
    }
    private void UpdateTimeState()
    {
        // 아침(6 ~ 9)[3시간]    낮 (9 ~ 18)[9시간]    저녁 (18 ~ 24)[6시간]
        if (GameTime > GM_GameTimeRule.GameTimeRatio * Hour.PM_6)
            timeState = TimeState.Night;
        else if (GameTime > GM_GameTimeRule.GameTimeRatio * Hour.AM_9)
            timeState = TimeState.Afternoon;
        else
            timeState = TimeState.Morning;

    }
    private void UpdateWeatherImage()
    {
        int[,] TexturesMap = new int[,]             // -1은 변경되지 않음을 의미함.
        {
                // Morning, Afternoon, Night
                { 14,  0,  7 },     // Clear
                { 15,  1,  8 },     // Cloud
                { 16,  3,  9 },     // Rain
                { 17, -1, -1 },     // ShiningSun
                { -1,  6, -1 },     // Storm
                { -1, -1, 10 },     // Thunder
                { 11, 11, 12 }      // Fog
        };

        int weatherIndex = (int)weatherState;
        int timeIndex = (int)timeState;

        if (weatherIndex >= 0 && weatherIndex < TexturesMap.GetLength(0) && timeIndex >= 0 && timeIndex < TexturesMap.GetLength(1))
        {
            int index = TexturesMap[weatherIndex, timeIndex];
            if (index != -1)
                Weather_Now.sprite = WeatherTexures[index];
        }
    }
}
