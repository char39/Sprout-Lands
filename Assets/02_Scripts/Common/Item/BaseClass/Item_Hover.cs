using UnityEngine;

public class Item_Hover : MonoBehaviour
{
    private float timer = 0f;
    internal float yorigin;
    private float ypos;

    void Start()
    {
        yorigin = transform.localPosition.y;
    }

    void Update()
    {
        timer += Time.deltaTime * 3;
        ypos = Mathf.Sin(timer);
        transform.localPosition = new Vector2(transform.localPosition.x, yorigin + (ypos * 0.1f));
    }
}