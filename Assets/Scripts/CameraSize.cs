using UnityEngine;

public class CameraSize : MonoBehaviour
{
    private const float TargetSizeX = 1920.0f;
    private const float TargetSizeY = 1080.0f;
    private const float HalfSize = 200.0f;
 
    private void CameraResize()
    {
        float screenRatio = (float)Screen.width / Screen.height;
        float targetRatio = TargetSizeX / TargetSizeY;

        if (screenRatio >= targetRatio )
        {
            Resize();
        }
        else 
        { 
            float differentSize = targetRatio /screenRatio;
            Resize(differentSize);
        }
    }

    private void Resize(float differentSize = 1.0f)
    {
        Camera.main.orthographicSize = TargetSizeX / HalfSize * differentSize;
    }

    private void Awake()
    {
        CameraResize();
    }
}