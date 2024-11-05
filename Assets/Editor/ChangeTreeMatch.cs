using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TreeData))]
public class ChangeTreeMatch : Editor
{
    public override void OnInspectorGUI()
    {
        TreeData tree = (TreeData)target;

        DrawDefaultInspector();

        int type = (int)tree.type;
        int state = (int)tree.state;

        if (tree.TryGetComponent(out SpriteRenderer sr))
            if (sr != null)
            {
                if (type == 0)
                {
                    if (state == 0)
                        sr.sprite = Icons.Trees[21];
                    else if (state == 1)
                        sr.sprite = Icons.Trees[22];
                }
                else if (type == 1)
                {
                    if (state == 0 || state == 1)
                        sr.sprite = Icons.Trees[7];
                    else if (state == 2)
                        sr.sprite = Icons.Trees[0];
                }
                else if (type == 2)
                {
                    if (state == 0 || state == 1)
                        sr.sprite = Icons.Trees[8];
                    else if (state == 2)
                        sr.sprite = Icons.Trees[1];
                    else if (state == 3)
                        sr.sprite = Icons.Trees[4];
                }
                else if (type == 3)
                {
                    if (state == 0)
                        sr.sprite = Icons.Trees[33];
                    else if (state == 2)
                        sr.sprite = Icons.Trees[2];
                    else if (state == 3)
                        sr.sprite = Icons.Trees[5];
                }
            }
        
        if (GUI.changed)
            EditorUtility.SetDirty(tree);
    }
}
