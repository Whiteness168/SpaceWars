using UnityEngine;

public class BoundsController : MonoBehaviour
{
    [SerializeField]
    private bool _bottomStart;

    private float _screenHeight;
    private float _objectHeight;

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
            Vector3 screenToWorldPoint = _camera.ScreenToWorldPoint(new Vector3(0, _screenHeight, 0));

            if (transform.position.y > screenToWorldPoint.y + _objectHeight / 2)
            {
                _deathController.Delete();
            }
        }
    }

    private void Awake()
    {
        _camera = Camera.main;
        _deathController = GetComponent<DeathController>();
        _screenHeight = Screen.height;
        _objectHeight = GetComponent<Renderer>().bounds.size.y;
    }

    void Update()
    {
        DestroyOutOfBounds();
    }
}