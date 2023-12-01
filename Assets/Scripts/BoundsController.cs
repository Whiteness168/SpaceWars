using UnityEngine;

public class BoundsController : MonoBehaviour
{
    private float screenHeight;
    private float objectHeight;
    private Camera _camera;
    [SerializeField]
    private bool _bottomStart;

    private void DestroyOutOfBounds()
    {
        if(_bottomStart)
        {
            Vector3 screenToWorldPoint = _camera.ScreenToWorldPoint(new Vector3(0, 0, 0));

            if (transform.position.y < screenToWorldPoint.y /*+ /*objectHeight*/)
            {
                GetComponent<DeathController>().Die();
            }
        }
        else
        {
            Vector3 screenToWorldPoint = _camera.ScreenToWorldPoint(new Vector3(0, screenHeight, 0));

            if (transform.position.y > screenToWorldPoint.y + objectHeight / 2)
            {
                GetComponent<DeathController>().Die();
            }
        }
    }    

    void Start()
    {
        _camera = Camera.main;
        screenHeight = Screen.height;
        objectHeight = GetComponent<Renderer>().bounds.size.y;
    }

    void Update()
    {
        DestroyOutOfBounds();
    }
}
