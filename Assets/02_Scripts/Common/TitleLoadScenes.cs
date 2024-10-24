using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleLoadScenes : MonoBehaviour
{
    private const string OutsideSceneName = "Outside";
    void Start()
    {
        SceneManager.LoadScene(OutsideSceneName, LoadSceneMode.Additive);
        Destroy(gameObject);
    }
}
