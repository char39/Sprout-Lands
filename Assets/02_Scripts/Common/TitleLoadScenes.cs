using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleLoadScenes : MonoBehaviour
{
    private const string TileMap = "TileMap";
    void Start()
    {
        SceneManager.LoadScene(TileMap, LoadSceneMode.Additive);
        Destroy(gameObject);
    }
}
