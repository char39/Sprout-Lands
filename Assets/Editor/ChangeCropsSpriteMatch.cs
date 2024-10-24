using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CropsData))]
public class ChangeCropsSpriteMatch : Editor
{
    public override void OnInspectorGUI()
    {
        CropsData crops = (CropsData)target;

        DrawDefaultInspector();

        if (crops.TryGetComponent(out SpriteRenderer sr))
            if (!(sr == null || (crops.Type != 0) && (int)crops.Growth == 3))   // 이건 옥수수만 3단계가 있어서 나머지는 갱신 못하게 막음.
                sr.sprite = Icons.FarmingPlant_Crops[CropsSprites.Index[(int)crops.Type, (int)crops.Growth]];

        if (GUI.changed)
            EditorUtility.SetDirty(crops);
    }
}