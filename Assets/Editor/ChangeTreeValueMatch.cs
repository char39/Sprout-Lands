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

        ITree.Type treeType = t.tree;
        IFruit.Type fruitType = t.fruit;
        ITree.State treeState = t.state;

        if (t.GetComponentInChildren<TreeClass>() != null)
        {
            TreeClass tree = t.GetComponentInChildren<TreeClass>();

            if (tree.TryGetComponent(out SpriteRenderer sr))
            {
                int index = TreeSprites.Index[(int)treeType, (int)treeState];
                if (index != -1)
                    sr.sprite = Icons.Trees[index];
            }
        }

        if (t.GetComponentInChildren<FruitClass>() != null)
        {
            FruitClass fruit = t.GetComponentInChildren<FruitClass>();

            if (fruit.TryGetComponent(out SpriteRenderer sr))
            {
                if (treeType == ITree.Type.Tree && treeState == ITree.State.Harvest)
                    sr.sprite = Icons.Fruits[(int)fruitType];
                else
                    sr.sprite = Icons.Fruits[0];
            }
        }

        if (GUI.changed)
            EditorUtility.SetDirty(t);
    }
}
