using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Lights_Local : LightCtrl
{
    // Light2D
    private Light2D local_Light;

    protected override void Start()
    {
        base.Start();

        TryGetComponent(out local_Light);
    }

    protected virtual void Update()
    {
        SetLocalLight2D();
    }

    protected void SetLocalLight2D()
    {
        if (local_Light == null) return;
        SetLocalLights(Hour.AM_0, Hour.AM_6, local_Light, 1f, 0.7f);
        SetLocalLights(Hour.AM_6, Hour.AM_7, local_Light, 0.7f, 0.5f);
        SetLocalLights(Hour.AM_7, Hour.AM_8, local_Light, 0.5f, 0.05f);
        SetLocalLights(Hour.AM_8, Hour.AM_9, local_Light, 0.05f, 0f);
        SetLocalLights(Hour.AM_9, Hour.PM_5, local_Light, 0f, 0f);
        SetLocalLights(Hour.PM_5, Hour.PM_6, local_Light, 0f, 0.1f);
        SetLocalLights(Hour.PM_6, Hour.PM_9, local_Light, 0.1f, 0.98f);
        SetLocalLights(Hour.PM_9, Hour.PM_10_30, local_Light, 0.98f, 1f);
        SetLocalLights(Hour.PM_10_30, Hour.AM_12, local_Light, 1f, 1f);
    }
}