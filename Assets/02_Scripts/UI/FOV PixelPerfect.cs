using UnityEngine;
using UnityEngine.U2D;

public class FOV_PixelPerfect : MonoBehaviour
{
    private const int minPPU = 60;
    private const int maxPPU = 120;

    public void FOV_Up()
    {
        PixelPerfectCamera camera = Camera.main.GetComponent<PixelPerfectCamera>();
        camera.assetsPPU += 10;
        camera.assetsPPU = Mathf.Clamp(camera.assetsPPU, minPPU, maxPPU);
    }

    public void FOV_Down()
    {
        PixelPerfectCamera camera = Camera.main.GetComponent<PixelPerfectCamera>();
        camera.assetsPPU -= 10;
        camera.assetsPPU = Mathf.Clamp(camera.assetsPPU, minPPU, maxPPU);
    }
}
