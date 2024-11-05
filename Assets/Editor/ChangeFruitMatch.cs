using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FruitData))]
public class ChangeFruitMatch : Editor
{
    public override void OnInspectorGUI()
    {
        FruitData fruit = (FruitData)target;

        DrawDefaultInspector();

        int type = (int)fruit.type;

        if (fruit.TryGetComponent(out SpriteRenderer sr))
            if (sr != null)
            {
                if (type == 0)
                    sr.sprite = Icons.Fruits[0];
                else if (type == 1)
                    sr.sprite = Icons.Fruits[1];
                else if (type == 2)
                    sr.sprite = Icons.Fruits[2];
                else if (type == 3)
                    sr.sprite = Icons.Fruits[3];
                else if (type == 4)
                    sr.sprite = Icons.Fruits[4];
            }
    }
}
