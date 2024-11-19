using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SetAlpha : MonoBehaviour
{
    private SpriteRenderer spr;
    private Tilemap tile;
    private bool IsAlphaOrigin = false;
    private bool IsStartCoroutine = false;

    void OnEnable()
    {
        transform.parent.TryGetComponent(out spr);
        transform.parent.TryGetComponent(out tile);
    }

    /// <summary> Alpha값을 0.5로 설정. </summary>
    public void SetAlphaLow() => StartCoroutine(StartAlphaLow());
    private IEnumerator StartAlphaLow()
    {
        if ((tile != null || spr != null) && !IsStartCoroutine)
        {
            IsAlphaOrigin = false;
            IsStartCoroutine = true;
            if (spr != null)
            {
                Color color = spr.color;
                while (spr.color.a > 0.65f)
                {
                    spr.color = color;
                    color.a -= 0.05f;
                    yield return new WaitForSeconds(0.02f);
                }
            }
            else if (tile != null)
            {
                Color color = tile.color;
                while (tile.color.a > 0.65f)
                {
                    tile.color = color;
                    color.a -= 0.05f;
                    yield return new WaitForSeconds(0.02f);
                }
            }
            IsStartCoroutine = false;
        }
    }
    /// <summary> Alpha값을 1로 설정. </summary>
    public void SetAlphaOrigin() => StartCoroutine(StartAlphaOrigin());
    private IEnumerator StartAlphaOrigin()
    {
        if ((tile != null || spr != null) && !IsStartCoroutine && !IsAlphaOrigin)
        {
            IsStartCoroutine = true;
            if (spr != null)
            {
                Color color = spr.color;
                while (spr.color.a < 1)
                {
                    spr.color = color;
                    color.a += 0.05f;
                    yield return new WaitForSeconds(0.02f);
                }
            }
            else if (tile != null)
            {
                Color color = tile.color;
                while (tile.color.a < 1)
                {
                    tile.color = color;
                    color.a += 0.05f;
                    yield return new WaitForSeconds(0.02f);
                }
            }
            IsAlphaOrigin = true;
            IsStartCoroutine = false;
        }
    }
}