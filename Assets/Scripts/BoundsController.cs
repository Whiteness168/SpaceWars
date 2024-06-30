using UnityEngine;

public class BoundsController : MonoBehaviour
{
    [SerializeField]
    private bool _bottomStart;

    private float screenHeight;
    private float objectHeight;

    private Camera _camera;
    private DeathController _deathController;

    private void DestroyOutOfBounds()
    {
        if(_bottomStart)
        {
            Vector3 screenToWorldPoint = _camera.ScreenToWorldPoint(new Vector3(0, 0, 0));

            if (transform.position.y < screenToWorldPoint.y)
            {
                _deathController.Delete();
            }
        }
        else
        {
            Vector3 screenToWorldPoint = _camera.ScreenToWorldPoint(new Vector3(0, screenHeight, 0));

            if (transform.position.y > screenToWorldPoint.y + objectHeight / 2)
            {
                _deathController.Delete();
            }
        }
    }

    private void Awake()
    {
        _camera = Camera.main;
        _deathController = GetComponent<DeathController>();
        screenHeight = Screen.height;
        objectHeight = GetComponent<Renderer>().bounds.size.y;
    }

    void Update()
    {
        DestroyOutOfBounds();
    }
}