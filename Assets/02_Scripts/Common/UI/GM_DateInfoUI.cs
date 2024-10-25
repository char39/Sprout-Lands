using System.Collections;
using UnityEngine;

public class GM_DateInfoUI : MonoBehaviour
{
    [HideInInspector] public Transform DateInfo_Frame;
    [HideInInspector] public CanvasGroup DateInfo_FrameCanvasGroup;
    public bool IsNowChangeAlpha = false;

    void Start()
    {
        DateInfo_Frame = GameObject.Find("UI_Canvas").transform.Find("DateInfo_Frame");
        DateInfo_FrameCanvasGroup = DateInfo_Frame.GetComponent<CanvasGroup>();
    }

    void Update()
    {
        OnMouseDateInfo_Frame();
    }

    private void OnMouseDateInfo_Frame()
    {
        bool OnMouse = GameManager.GM.MousePos.IsOnWeatherUI;

        if (OnMouse)
            StartCoroutine(SlerpFrameAlpha(0.65f));
        else
            StartCoroutine(SlerpFrameAlpha(1f));

    }

    private IEnumerator SlerpFrameAlpha(float value)
    {
        if (IsNowChangeAlpha) yield break;
        IsNowChangeAlpha = true;
        float duration = 0.5f;
        float elapsed = 0f;
        
        static bool IsApproximately(float a, float b, float tolerance) => Mathf.Abs(a - b) < tolerance;
        while (!IsApproximately(DateInfo_FrameCanvasGroup.alpha, value, 0.05f))
        {
            DateInfo_FrameCanvasGroup.alpha = Mathf.Lerp(DateInfo_FrameCanvasGroup.alpha, value, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        DateInfo_FrameCanvasGroup.alpha = value;
        IsNowChangeAlpha = false;
    }
}
