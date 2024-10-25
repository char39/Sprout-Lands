using UnityEngine;

public class FindTileObject : MonoBehaviour
{
    private SpriteRenderer sr;

    private float timer = 0f;
    private readonly float repeatTime = 1.5f;

    private readonly float scale = 0.95f;
    private readonly float scaleChange = 0.9f;
    private readonly float alpha = 0.35f;
    private readonly float alphaChange = 0.2f;
    private float Alpha;
    private Vector3 scaleVec;
    private readonly float scaleD = 1.1f;
    private readonly float scaleChangeD = 1.0f;
    private readonly float alphaD = 1f;
    private readonly float alphaChangeD = 0.9f;
    private float AlphaD;
    private Vector3 scaleChangeVec;

    public bool itemDetected = false;

    void Start()
    {
        TryGetComponent(out sr);
    }

    void Update()
    {
        if (GameManager.GM.player != null)
            itemDetected = GameManager.GM.player.IsObjectDetected();

        scaleVec = itemDetected ? new Vector3(scaleD, scaleD, 1) : new Vector3(scale, scale, 1);
        scaleChangeVec = itemDetected ? new Vector3(scaleChangeD, scaleChangeD, 1) : new Vector3(scaleChange, scaleChange, 1);
        Alpha = itemDetected ? alphaD : alpha;
        AlphaD = itemDetected ? alphaChangeD : alphaChange;

        OnAlphaChange();
        OnSpriteChange();
    }

    private void OnAlphaChange()
    {
        timer += Time.deltaTime;

        if (timer < repeatTime * 0.5f)
        {
            sr.color = new Color(1, 1, 1, Alpha);
            transform.localScale = scaleVec;
        }
        else if (timer < repeatTime)
        {
            sr.color = new Color(1, 1, 1, AlphaD);
            transform.localScale = scaleChangeVec;
        }
        else
            timer = 0f;
    }

    private void OnSpriteChange()
    {
        if (itemDetected)
            sr.sprite = Icons.InventorySpritesheet[12];
        else
            sr.sprite = Icons.InventorySpritesheet[13];
    }
}
