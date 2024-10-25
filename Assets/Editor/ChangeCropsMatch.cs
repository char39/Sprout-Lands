using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CropsData))]
public class ChangeCropsMatch : Editor
{
    public override void OnInspectorGUI()
    {
        CropsData crops = (CropsData)target;

        DrawDefaultInspector();

        if (crops.TryGetComponent(out SpriteRenderer sr))
            if (!(sr == null || (crops.Type != 0) && (int)crops.Growth == 3))   // 이건 옥수수만 3단계가 있어서 나머지는 갱신 못하게 막음.
                sr.sprite = Icons.FarmingPlant_Crops[CropsSprites.Index[(int)crops.Type, (int)crops.Growth]];
        
        if (crops.transform.GetChild(0).TryGetComponent(out BoxCollider2D col))
            if (col != null)
            {
                Vector2? offset = CropsStructureMasks.offsets[(int)crops.Type, (int)crops.Growth];
                Vector2? size = CropsStructureMasks.sizes[(int)crops.Type, (int)crops.Growth];

                if (offset == null || size == null)
                    col.enabled = false;
                else
                {
                    col.enabled = true;
                    col.offset = (Vector2)offset;
                    col.size = (Vector2)size;
                }
            }

        if (GUI.changed)
            EditorUtility.SetDirty(crops);
    }
}