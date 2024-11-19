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
                if (treeType == ITree.Type.Bush)
                {
                    if (treeState == ITree.State.Sprout)
                        sr.sprite = Icons.Trees[21];
                    else
                        sr.sprite = Icons.Trees[22];
                }
                else if (treeType == ITree.Type.SmallTree)
                {
                    if (treeState == ITree.State.Stump)
                        sr.sprite = Icons.Trees[0];
                    else
                        sr.sprite = Icons.Trees[7];
                }
                else if (treeType == ITree.Type.Tree)
                {
                    if (treeState == ITree.State.Sprout)
                        sr.sprite = Icons.Trees[34];
                    else if (treeState == ITree.State.Normal || treeState == ITree.State.Harvest)
                        sr.sprite = Icons.Trees[8];
                    else if (treeState == ITree.State.Stump)
                        sr.sprite = Icons.Trees[1];
                    else if (treeState == ITree.State.Wood)
                        sr.sprite = Icons.Trees[4];
                }
                else if (treeType == ITree.Type.BigTree)
                {
                    if (treeState == ITree.State.Stump)
                        sr.sprite = Icons.Trees[2];
                    else if (treeState == ITree.State.Wood)
                        sr.sprite = Icons.Trees[5];
                    else
                        sr.sprite = Icons.Trees[33];
                }
            }
        }

        if (t.GetComponentInChildren<FruitClass>() != null)
        {
            FruitClass fruit = t.GetComponentInChildren<FruitClass>();

            if (fruit.TryGetComponent(out SpriteRenderer sr))
            {
                if (fruitType == IFruit.Type.None)
                    sr.sprite = Icons.Fruits[0];
                else if (fruitType == IFruit.Type.Apple)
                    sr.sprite = Icons.Fruits[1];
                else if (fruitType == IFruit.Type.Orange)
                    sr.sprite = Icons.Fruits[2];
                else if (fruitType == IFruit.Type.Pear)
                    sr.sprite = Icons.Fruits[3];
                else if (fruitType == IFruit.Type.Peach)
                    sr.sprite = Icons.Fruits[4];
            }
        }

        if (GUI.changed)
            EditorUtility.SetDirty(t);
    }
}
