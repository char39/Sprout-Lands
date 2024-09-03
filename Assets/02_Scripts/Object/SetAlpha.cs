using UnityEngine;
using UnityEngine.Tilemaps;

public class SetAlpha : MonoBehaviour
{
    private Tilemap sr;

    void Start()
    {
        transform.parent.TryGetComponent(out sr);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            SetAlphaLow();
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            SetAlphaOrigin();
    }

    public void SetAlphaLow()
    {
        if (sr != null)
            sr.color = new Color(1, 1, 1, 0.5f);
    }

    public void SetAlphaOrigin()
    {
        if (sr != null)
            sr.color = new Color(1, 1, 1, 1);
    }
}
