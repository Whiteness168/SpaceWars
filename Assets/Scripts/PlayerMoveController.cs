using UnityEngine;

public class PlayerMoveController : MoveController
{
    private float _horizontalMovement;
    public float HorizontalMovement
    {
        get { return _horizontalMovement; }
    }
    private float _verticalMovement;
    public float VerticalMovement
    {
        get { return _verticalMovement; }
    }
    private Camera _camera;

    private void PlayfieldConstriction(float horizontalMovement, float verticalMovement)
    {
        var min = _camera.ViewportToWorldPoint(new Vector2(0, 0));
        var max = _camera.ViewportToWorldPoint(new Vector2(1, 1));

        if (transform.position.x > max.x || transform.position.x < min.x)
        {
            transform.position -= new Vector3(horizontalMovement, 0, 0) * _speed * Time.deltaTime;
        }

        if (transform.position.y > max.y || transform.position.y < min.y)
        {
            transform.position -= new Vector3(0, verticalMovement, 0) * _speed * Time.deltaTime;
        }
    }

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        _horizontalMovement = Input.GetAxis("Horizontal");
        _verticalMovement = Input.GetAxis("Vertical");

        transform.position += new Vector3(_horizontalMovement, _verticalMovement, 0) * _speed * Time.deltaTime;

        PlayfieldConstriction(_horizontalMovement, _verticalMovement);
    }
}
