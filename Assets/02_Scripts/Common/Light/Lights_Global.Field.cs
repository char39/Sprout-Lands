using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public partial class Lights_Global : MonoBehaviour
{
    private GM_GameTimeRule timeRule;
    // Volume
    private Volume global_Volume;
    private WhiteBalance global_whiteBalance;
    // Light2D
    private Light2D global_Light;

    private float ratio;

    private void GetAllComponents()
    {
        timeRule = GameManager.GM.gameTimeRule;
        transform.GetChild(0).TryGetComponent(out global_Volume);
        transform.GetChild(1).TryGetComponent(out global_Light);

        global_Volume.profile.TryGet(out global_whiteBalance);
    }

    private void GetTimeRuleVars()
    {
        ratio = GM_GameTimeRule.GameTimeRatio;
    }
}
