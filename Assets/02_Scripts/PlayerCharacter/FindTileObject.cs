using System.Collections;
using UnityEngine;

public class FindTileObject : MonoBehaviour
{
    private SpriteRenderer sr;

    void Start()
    {
        TryGetComponent(out sr);
        StartCoroutine(RepeatAlphaChange());
    }

    private IEnumerator RepeatAlphaChange()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.75f);
            sr.color = new Color(1, 1, 1, 0.85f);
            transform.localScale = new Vector3(0.95f, 0.95f, 1);
            yield return new WaitForSeconds(0.75f);
            sr.color = new Color(1, 1, 1, 0.5f);
            transform.localScale = new Vector3(0.9f, 0.9f, 1);
        }
    }
}
