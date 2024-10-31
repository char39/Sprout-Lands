using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Lights_Global : LightCtrl
{
    // Volume
    private Volume global_Volume;
    private WhiteBalance global_whiteBalance;
    // Light2D
    private Light2D global_Light;

    protected override void Start()
    {
        base.Start();

        transform.GetChild(0).TryGetComponent(out global_Volume);
        transform.GetChild(1).TryGetComponent(out global_Light);

        global_Volume.profile.TryGet(out global_whiteBalance);
    }

    void Update()
    {
        SetLight2D();
    }

    /// <summary> 게임 시간이 min ~ max 사이인 경우, Global Light를 설정 </summary>
    private void SetGlobalLights(float StartTime, float EndTime, float inten_S, float inten_E, float whiteB_S, float whiteB_E)
    {
        if (IsGameTimeTrue(StartTime, EndTime))
        {
            float linearTransformTime = Mathf.Clamp01(LinearTransform(timeRule.GameTime, StartTime, EndTime));
            global_Light.intensity = Mathf.Lerp(inten_S, inten_E, linearTransformTime);
            global_whiteBalance.temperature.value = Mathf.Lerp(whiteB_S, whiteB_E, linearTransformTime);
        }
    }

    private void SetLight2D()
    {
        SetGlobalLights(Hour.AM_0, Hour.AM_6, 0.01f, 0.3f, -20f, -20f);
        SetGlobalLights(Hour.AM_6, Hour.AM_7, 0.3f, 0.5f, -20f, 20f);
        SetGlobalLights(Hour.AM_7, Hour.AM_8, 0.5f, 0.95f, 20f, 10f);
        SetGlobalLights(Hour.AM_8, Hour.AM_9, 0.95f, 1.2f, 10f, 0f);
        SetGlobalLights(Hour.AM_9, Hour.PM_5, 1.2f, 1.2f, 0f, 0f);
        SetGlobalLights(Hour.PM_5, Hour.PM_6, 1.2f, 1f, 0f, 20f);
        SetGlobalLights(Hour.PM_6, Hour.PM_9, 1f, 0.02f, 20f, -10f);
        SetGlobalLights(Hour.PM_9, Hour.PM_10_30, 0.02f, 0.01f, -10f, -20f);
        SetGlobalLights(Hour.PM_10_30, Hour.AM_12, 0.01f, 0.01f, -20f, -20f);
    }
}
