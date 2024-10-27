using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    private Animator ani;
    private SpriteRenderer sr;

    private const string ANI_DIRECTION = "Direction";
    private const string ACTION_TRIGGER = "ActionTrigger";

    void Start()
    {
        TryGetComponent(out ani);
        TryGetComponent(out sr);

        sr.enabled = false;
    }

    // Player.cs에서 호출
    public void WaterDropTrigger(int state)
    {
        sr.enabled = true;
        ani.SetFloat(ANI_DIRECTION, state);
        ani.SetTrigger(ACTION_TRIGGER);
    }

    // Animation Event
    public void TurnOffWaterDrop() => sr.enabled = false;
}
