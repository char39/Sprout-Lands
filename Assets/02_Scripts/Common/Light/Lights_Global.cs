using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public partial class Lights_Global : MonoBehaviour
{
    void Start()
    {
        GetAllComponents();
        GetTimeRuleVars();
    }

    /*
    globalMain.Intensity
    (AM 6) 0.5f, (PM 12) 1f, (PM 6) 1f, (PM 9)0.7f, (PM 10:30) 0.02f
    */

    void Update()
    {
        SetLight2D();
    }

    private void SetLight2D()
    {
        if (timeRule.GameTime < GameTimeHour.PM_12 * ratio)              // 06 ~ 12
        {
            float linearTransformTime = Mathf.Clamp01(LinearTransform(timeRule.GameTime, GameTimeHour.AM_6 * ratio, GameTimeHour.PM_12 * ratio));
            global_Main.intensity = (0.5f * linearTransformTime) + 0.5f;
            global_Main.intensity = LinearTransform(timeRule.GameTime, GameTimeHour.AM_6 * ratio, GameTimeHour.PM_12 * ratio, 0.5f, 1f);
        }
        else if (timeRule.GameTime < GameTimeHour.PM_6 * ratio)          // 12 ~ 18
        {
            global_Main.intensity = 1;
        }
        else if (timeRule.GameTime < GameTimeHour.PM_9 * ratio)          // 18 ~ 21
        {
            float linearTransformTime = Mathf.Clamp01(LinearTransform(timeRule.GameTime, GameTimeHour.PM_6 * ratio, GameTimeHour.PM_9 * ratio));
            global_Main.intensity = 1 - (0.3f * linearTransformTime);
        }
        else if (timeRule.GameTime < GameTimeHour.AM_12 * ratio)         // 21 ~ 24
        {
            float linearTransformTime = Mathf.Clamp01(LinearTransform(timeRule.GameTime, GameTimeHour.PM_9 * ratio, GameTimeHour.PM_10_30 * ratio));
            global_Main.intensity = (0.68f * (1 - linearTransformTime)) + 0.02f;
        }
        else                                        // 24 ~
        {
            
        }
    }

    /// <summary> Value를 0(min) ~ 1(max)로 선형변환함  </summary>
    public float LinearTransform(float Value, float min, float max) => (Value - min) / (max - min);
    /// <summary> Value를 newMin ~ newMax로 선형변환함  </summary>
    public float LinearTransform(float Value, float min, float max, float newMin, float newMax) => (Value - min) / (max - min) * (newMax - newMin) + newMin;
}
