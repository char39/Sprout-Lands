using UnityEngine;
using UnityEngine.UI;

public class GM_DateInfo : MonoBehaviour
{
    public Transform DateInfo_Frame;
    public RectTransform Time_HourHand;

    public Image Weather_Now;
    public Sprite[] WeatherTexures;
    public enum TimeState { Morning, Afternoon, Night }
    public enum WeatherState { Clear, Cloud, Rain, ShiningSun, Storm, Thunder, Fog }
    public TimeState timeState = TimeState.Morning;
    public WeatherState weatherState = WeatherState.Clear;

    public Text Time_Text;
    public Text Time_Second;
    public Text TimeZone;

    internal const float maxAngle = 80f;
    private const string AM = "AM";
    private const string PM = "PM";
    private const string TimeColon = ":";
    internal float GameTime;
    internal int GameTimeHour;
    internal int GameTimeMinute;

    void Start()
    {
        DateInfo_Frame = GameObject.Find("UI_Canvas").transform.GetChild(0).GetChild(0);
        Time_HourHand = DateInfo_Frame.GetChild(0).GetChild(0).GetComponent<RectTransform>();
        Weather_Now = DateInfo_Frame.GetChild(1).GetChild(1).GetComponent<Image>();
        WeatherTexures = Resources.LoadAll<Sprite>("UI/DateInfo/Weather_Icons_small");
        Time_Text = DateInfo_Frame.GetChild(1).GetChild(0).GetComponent<Text>();
        Time_Second = Time_Text.transform.GetChild(0).GetComponent<Text>();
        TimeZone = Time_Text.transform.GetChild(1).GetComponent<Text>();
    }

    void Update()
    {
        GameTime = GameManager.Instance.gameTimeRule.GameTime;
        GameTimeHour = GameManager.Instance.gameTimeRule.GameTimeHour;
        GameTimeMinute = GameManager.Instance.gameTimeRule.GameTimeMinute;
        UpdateHourHand();
        UpdateTimeText();
        UpdateTimeState();
        UpdateWeatherImage();
    }

    private void UpdateHourHand()
    {
        // (아침 6시 ~ 저녁 12시) z축 회전값
        float TimeNormal = (GameTime - GM_GameTimeRule.GameTimeRatio * 6) / (GM_GameTimeRule.GameTimeRatio * 18);
        float lerpedAngle = Mathf.LerpAngle(maxAngle, -maxAngle, TimeNormal);
        Time_HourHand.localRotation = Quaternion.Euler(0, 0, lerpedAngle);
    }
    private void UpdateTimeText()
    {
        if (GameTimeMinute % 10 == 0)
            Time_Text.text = GameTimeHour.ToString() + "    " + GameTimeMinute.ToString("00");
        Time_Second.text = (int)(GameTime % 1.5) == 0 ? TimeColon : string.Empty;
        TimeZone.text = GameManager.Instance.gameTimeRule.CheckMorning() ? AM : PM;
    }
    private void UpdateTimeState()
    {
        // 아침(6 ~ 9)[3] 낮 (9 ~ 18)[9] 저녁 (18 ~ 24)[6]
        if (GameTime > GM_GameTimeRule.GameTimeRatio * 18)
            timeState = TimeState.Night;
        else if (GameTime > GM_GameTimeRule.GameTimeRatio * 9)
            timeState = TimeState.Afternoon;
        else
            timeState = TimeState.Morning;

    }
    private void UpdateWeatherImage()
    {
        int[,] TexturesMap = new int[,]
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
