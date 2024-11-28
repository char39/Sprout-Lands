using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Trees))]
public class ChangeTreeValueMatch : Editor
{
    public override void OnInspectorGUI()
    {
        Trees t = (Trees)target;

        DrawDefaultInspector();

        if (!t.SpriteAutoRefresh)
            return;

        ITree.Type tree = t.tree;
        IFruit.Type fruit = t.fruit;
        ITree.State state = t.state;

        if (t.GetComponentInChildren<TreeClass>() != null)
        {
            TreeClass treeClass = t.GetComponentInChildren<TreeClass>();

            if (treeClass.TryGetComponent(out SpriteRenderer sr))
            {
                int index = TreeSprites.Index[(int)tree, (int)state];
                if (index != -1)
                    sr.sprite = Icons.Trees[index];
            }
        }

        if (t.GetComponentInChildren<FruitClass>() != null)
        {
            FruitClass fruitClass = t.GetComponentInChildren<FruitClass>();

            if (fruitClass.TryGetComponent(out SpriteRenderer sr))
            {
                if (tree == ITree.Type.Tree && state == ITree.State.Harvest)
                    sr.sprite = Icons.Fruits[(int)fruit];
                else
                    sr.sprite = Icons.Fruits[0];
            }
        }

        if (GUI.changed)
            EditorUtility.SetDirty(t);
    }
}
