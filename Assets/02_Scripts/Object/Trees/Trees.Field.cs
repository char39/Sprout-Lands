using UnityEngine;

public partial class Trees : MonoBehaviour
{
    public bool SpriteAutoRefresh = false;      // 스프라이트 자동 갱신 여부

    public TreeClass treeData;      // 클래스 참조
    public FruitClass fruitData;    // 클래스 참조

    public ITree.Type tree;         // 나무 종류
    public IFruit.Type fruit;       // 과일 종류
    public ITree.State state;       // 나무 상태

    private bool treeIsVaild;       // 나무 유효성 검사
    private bool fruitIsVaild;      // 과일 유효성 검사


    public bool isBounceEnable = false;     // 튕김 활성화
    public bool isTreeMoveEnable = false;   // 나무 이동 활성화
    public bool isFruitDropEnable = false;  // 과일 떨어짐 활성화
}