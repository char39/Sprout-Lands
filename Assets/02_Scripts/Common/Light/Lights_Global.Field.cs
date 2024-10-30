using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public partial class Lights_Global : MonoBehaviour
{
    private GM_GameTimeRule timeRule;
    public Volume global_Volume;
    public Light2D global_Main;

    private float ratio;

    private void GetAllComponents()
    {
        timeRule = GameManager.GM.gameTimeRule;
        transform.GetChild(0).TryGetComponent(out global_Volume);
        transform.GetChild(1).TryGetComponent(out global_Main);
    }

    private void GetTimeRuleVars()
    {
        ratio = GM_GameTimeRule.GameTimeRatio;
    }
}
