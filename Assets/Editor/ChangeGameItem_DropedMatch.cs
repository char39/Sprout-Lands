using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Item_Droped))]
public class ChangeGameItem_DropedMatch : Editor
{
    public override void OnInspectorGUI()
    {
        Item_Droped item = (Item_Droped)target;

        DrawDefaultInspector();

        if (item.TryGetComponent(out SpriteRenderer sr))
        {
            int id = item.ID;
            int index = 0;
            if (id == -1) return;
            
            if (1 <= id && id <= 999)
            {
                Sprite[] Tool = Resources.LoadAll<Sprite>("Item/Tool");
                index = id - 1;
                if (Tool.Length - 1 >= index)
                    sr.sprite = Tool[index];
            }
            else if (1001 <= id && id <= 1999)
            {
                Sprite[] FarmingPlant = Resources.LoadAll<Sprite>("Item/FarmingPlant");
                index = id - 1000;
                if (FarmingPlant.Length - 1 >= index)
                    sr.sprite = FarmingPlant[index];
            }
            else if (2001 <= id && id <= 2999)
            {
                Sprite[] Fruit = Resources.LoadAll<Sprite>("Item/Fruit");
                index = id - 2001;
                if (Fruit.Length - 1 >= index)
                    sr.sprite = Fruit[index];
            }
            else if (3001 <= id && id <= 3999)
            {
                Sprite[] Egg = Resources.LoadAll<Sprite>("Item/Egg");
                index = id - 3001;
                if (Egg.Length - 1 >= index)
                    sr.sprite = Egg[index];
            }
            else if (4001 <= id && id <= 4999)
            {
                Sprite[] Milk = Resources.LoadAll<Sprite>("Item/Milk");
                index = id - 4001;
                if (Milk.Length - 1 >= index)
                    sr.sprite = Milk[index];
            }
        }
        if (GUI.changed)
            EditorUtility.SetDirty(item);
    }
}
