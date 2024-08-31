using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleLoadScenes : MonoBehaviour
{
    private const string UI = "UI_Playing";
    private const string TileMap = "TileMap";
    void Start()
    {
        SceneManager.LoadScene(UI, LoadSceneMode.Additive);
        SceneManager.LoadScene(TileMap, LoadSceneMode.Additive);
        
    }
}
