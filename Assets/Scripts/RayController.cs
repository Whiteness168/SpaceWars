using UnityEngine;

public class RayController : WeaponController
{
    [SerializeField] 
    private LayerMask _hitLayer;
    [SerializeField] 
    private float _laserLength;
    private Vector2 _laserStart;
    private Vector2 _laserDirection;
    private LineRenderer _lineRenderer;
    private Ray2D _laserRay;
    private RaycastHit2D _hit;
    public RaycastHit2D Hit
    {
        get { return _hit; }
    }


    protected override bool IsKeyPressed()
    {
        if (Input.GetKey(_activationKey))
        {
            return true;
        }
        else
        {         
            return false;
        }
    }
     
    private void LaserShooting()
    {
        if (IsKeyPressed())
        {
            _laserStart = transform.position;
            _laserDirection = transform.up;

            _laserRay = new Ray2D(_laserStart, _laserDirection);

            _lineRenderer.enabled = true;
            _lineRenderer.SetPosition(0, _laserStart);
        }
        else
        {
            _lineRenderer.enabled = false;
        }
    }

    private void DetectLaserCollision()
    {
        _hit = Physics2D.Raycast(_laserRay.origin, _laserRay.direction, _laserLength, _hitLayer);

        if (_hit.collider != null)
        {
            _lineRenderer.SetPosition(1, _hit.point);
            Debug.Log("Столкновение с объектом: " + _hit.collider.name);
        }
        else
        {
            _lineRenderer.SetPosition(1, _laserStart + _laserDirection * _laserLength);
        }
    }

    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.enabled = false;
    }

    void Update()
    {
        LaserShooting();
        DetectLaserCollision();
    }
}
