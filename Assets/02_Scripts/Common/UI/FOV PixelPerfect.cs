using System;
using UnityEngine;
using UnityEngine.U2D;

public class FOV_PixelPerfect : MonoBehaviour
{
    private const byte minPPU = 60;
    private const byte maxPPU = 120;

    // URP 2D 설치 후에 작동이 안되어서 잠시 보류
    [Obsolete]  // ui 버튼에 할당되어있음
    public void FOV_Up()
    {
        GameManager.GM.cameraSetting.MainCam.TryGetComponent(out PixelPerfectCamera camera);
        camera.assetsPPU += 10;
        camera.assetsPPU = Mathf.Clamp(camera.assetsPPU, minPPU, maxPPU);
    }

    [Obsolete]
    public void FOV_Down()
    {
        GameManager.GM.cameraSetting.MainCam.TryGetComponent(out PixelPerfectCamera camera);
        camera.assetsPPU -= 10;
        camera.assetsPPU = Mathf.Clamp(camera.assetsPPU, minPPU, maxPPU);
    }
}
