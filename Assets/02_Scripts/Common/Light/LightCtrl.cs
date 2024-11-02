using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightCtrl : MonoBehaviour
{
    protected GameTimeRule timeRule;
    protected float ratio;

    protected virtual void Start()
    {
        timeRule = GM.PROCESS.gameTimeRule;
        ratio = GameTimeRule.GameTimeRatio;
    }

    /// <summary> 게임 시간이 min ~ max 사이인지 확인 </summary>
    public bool IsGameTimeTrue(float minGameTimeHour, float maxGameTimeHour) => minGameTimeHour * ratio <= timeRule.GameTime && timeRule.GameTime < maxGameTimeHour * ratio;
    /// <summary> Value를 0(min) ~ 1(max)로 선형 변환 </summary>
    public float LinearTransform(float Value, float min, float max) => (Value - (min * ratio)) / ((max * ratio) - (min * ratio));
    /// <summary> Value를 newMin ~ newMax로 선형 변환 </summary>
    public float LinearTransform(float Value, float min, float max, float newMin, float newMax) => (Value - (min * ratio)) / ((max * ratio) - (min * ratio)) * (newMax - newMin) + newMin;

    /// <summary> 게임 시간이 min ~ max 사이인 경우, Local Light를 설정 </summary>
    protected void SetLocalLights(float StartTime, float EndTime, Light2D LocalLight, float inten_S, float inten_E)
    {
        if (IsGameTimeTrue(StartTime, EndTime))
        {
            float linearTransformTime = Mathf.Clamp01(LinearTransform(timeRule.GameTime, StartTime, EndTime));
            LocalLight.intensity = Mathf.Lerp(inten_S, inten_E, linearTransformTime);
        }
    }
    /// <summary> 게임 시간이 min ~ max 사이인 경우, Local WhiteBalance를 설정 </summary>
    protected void SetLocalLights(float StartTime, float EndTime, WhiteBalance LocalWhiteB, float whiteB_S, float whiteB_E)
    {
        if (IsGameTimeTrue(StartTime, EndTime))
        {
            float linearTransformTime = Mathf.Clamp01(LinearTransform(timeRule.GameTime, StartTime, EndTime));
            LocalWhiteB.temperature.value = Mathf.Lerp(whiteB_S, whiteB_E, linearTransformTime);
        }
    }
    /// <summary> 게임 시간이 min ~ max 사이인 경우, Local Light와 Local WhiteBalance를 설정 </summary>
    protected void SetLocalLights(float StartTime, float EndTime, Light2D LocalLight, float inten_S, float inten_E, WhiteBalance LocalWhiteB, float whiteB_S, float whiteB_E)
    {
        if (IsGameTimeTrue(StartTime, EndTime))
        {
            float linearTransformTime = Mathf.Clamp01(LinearTransform(timeRule.GameTime, StartTime, EndTime));
            LocalLight.intensity = Mathf.Lerp(inten_S, inten_E, linearTransformTime);
            LocalWhiteB.temperature.value = Mathf.Lerp(whiteB_S, whiteB_E, linearTransformTime);
        }
    }
}
