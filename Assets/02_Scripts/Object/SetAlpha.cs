using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SetAlpha : MonoBehaviour
{
    private Tilemap sr;
    private bool IsAlphaOrigin = false;
    private bool IsStartCoroutine = false;

    void Start()
    {
        transform.parent.TryGetComponent(out sr);
    }

    /// <summary> Alpha값을 0.5로 설정. </summary>
    public void SetAlphaLow() => StartCoroutine(StartAlphaLow());
    private IEnumerator StartAlphaLow()
    {
        if (sr != null && !IsStartCoroutine)
        {
            IsAlphaOrigin = false;
            IsStartCoroutine = true;
            Color color = sr.color;
            while (sr.color.a > 0.5f)
            {
                sr.color = color;
                color.a -= 0.05f;
                yield return new WaitForSeconds(0.02f);
            }
            IsStartCoroutine = false;
        }
    }
    /// <summary> Alpha값을 1로 설정. </summary>
    public void SetAlphaOrigin() => StartCoroutine(StartAlphaOrigin());
    private IEnumerator StartAlphaOrigin()
    {
        if (sr != null && !IsStartCoroutine && !IsAlphaOrigin)
        {
            IsStartCoroutine = true;
            Color color = sr.color;
            while (sr.color.a < 1)
            {
                sr.color = color;
                color.a += 0.05f;
                yield return new WaitForSeconds(0.02f);
            }
            IsAlphaOrigin = true;
            IsStartCoroutine = false;
        }
    }



}
