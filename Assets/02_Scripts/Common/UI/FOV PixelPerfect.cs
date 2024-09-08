using UnityEngine;
using UnityEngine.U2D;

public class FOV_PixelPerfect : MonoBehaviour
{
    private const byte minPPU = 60;
    private const byte maxPPU = 120;

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
