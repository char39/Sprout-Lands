using UnityEngine;

public partial class Lights_Global : MonoBehaviour
{
    void Start()
    {
        GetAllComponents();
        GetTimeRuleVars();
    }

    void Update()
    {
        SetLight2D();
    }

    public bool IsGameTimeTrue(float nowGameTime, float minGameTimeHour, float maxGameTimeHour, float ratio)
    {
        return minGameTimeHour * ratio <= nowGameTime && nowGameTime < maxGameTimeHour * ratio;
    }

    /// <summary> Value를 0(min) ~ 1(max)로 선형변환함  </summary>
    public float LinearTransform(float Value, float min, float max) => (Value - min) / (max - min);
    /// <summary> Value를 newMin ~ newMax로 선형변환함  </summary>
    public float LinearTransform(float Value, float min, float max, float newMin, float newMax) => (Value - min) / (max - min) * (newMax - newMin) + newMin;

    private void SetLightOverTime(float StartTime, float startIntensity, float startWhiteBalace, float EndTime, float endIntensity, float endWhiteBalance)
    {
        float linearTransformTime = Mathf.Clamp01(LinearTransform(timeRule.GameTime, StartTime * ratio, EndTime * ratio));
        global_Light.intensity = Mathf.Lerp(startIntensity, endIntensity, linearTransformTime);
        global_whiteBalance.temperature.value = Mathf.Lerp(startWhiteBalace, endWhiteBalance, linearTransformTime);
    }

    private void SetLight2D()
    {
        if (IsGameTimeTrue(timeRule.GameTime, Hour.AM_0, Hour.AM_6, ratio))
            SetLightOverTime(Hour.AM_0, 0.5f, -20f, Hour.AM_6, 0.5f, -20f);

        else if (IsGameTimeTrue(timeRule.GameTime, Hour.AM_6, Hour.AM_7, ratio))
            SetLightOverTime(Hour.AM_6, 0.5f, -20f, Hour.AM_7, 0.8f, 20f);

        else if (IsGameTimeTrue(timeRule.GameTime, Hour.AM_7, Hour.AM_8, ratio))
            SetLightOverTime(Hour.AM_7, 0.8f, 20f, Hour.AM_8, 0.95f, 10f);

        else if (IsGameTimeTrue(timeRule.GameTime, Hour.AM_8, Hour.AM_9, ratio))
            SetLightOverTime(Hour.AM_8, 0.95f, 10f, Hour.AM_9, 1f, 0f);

        else if (IsGameTimeTrue(timeRule.GameTime, Hour.AM_9, Hour.PM_5, ratio))
            SetLightOverTime(Hour.AM_9, 1f, 0f, Hour.PM_5, 1f, 0f);

        else if (IsGameTimeTrue(timeRule.GameTime, Hour.PM_5, Hour.PM_6, ratio))
            SetLightOverTime(Hour.PM_5, 1f, 0f, Hour.PM_6, 0.9f, 20f);

        else if (IsGameTimeTrue(timeRule.GameTime, Hour.PM_6, Hour.PM_9, ratio))
            SetLightOverTime(Hour.PM_6, 0.9f, 20f, Hour.PM_9, 0.3f, 0f);

        else if (IsGameTimeTrue(timeRule.GameTime, Hour.PM_9, Hour.PM_10_30, ratio))
            SetLightOverTime(Hour.PM_9, 0.3f, 0f, Hour.PM_10_30, 0.02f, -20f);
    }
}
