using System;
using UnityEngine;

public class RayController : MonoBehaviour
{
    [SerializeField] 
    private LayerMask _hitLayer;
    [SerializeField] 
    private float _laserLength;
    private Vector2 _laserStart;
    private Vector2 _laserDirection;
    private LineRenderer _lineRenderer;
    public LineRenderer LineRenderer
    {  get { return _lineRenderer; } }
    private Ray2D _laserRay;
    private bool _laserActive;
    public bool LaserActive
    {  get { return _laserActive; } }
    private RaycastHit2D _hit;
    public RaycastHit2D Hit
    {
        get { return _hit; }
    }
    private KeyCode _activationKey = KeyCode.LeftAlt;

    private AmmoStockpile _ammoStockpile;
    private WeaponSwitcher _weaponSwitcher;
    private Sounds _sounds;

    public event Action OnRay;

    private bool IsKeyPressed()
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
            if (_ammoStockpile.AllAmmoCountCheck(_weaponSwitcher.CurrentWeaponIndex))
            {
                _laserStart = transform.position;
                _laserDirection = transform.up;

                _laserRay = new Ray2D(_laserStart, _laserDirection);

                _lineRenderer.enabled = true;
                _lineRenderer.SetPosition(0, _laserStart);

                _laserActive = true;

                _ammoStockpile.DecrementAmmo(_weaponSwitcher.CurrentWeaponIndex);

                if (_ammoStockpile.LaserCharge > 0.0f)
                {
                    _sounds.PlayLoopingSound();
                }
            }
        }
        else
        {
            _lineRenderer.enabled = false;
            _laserActive = false;
            _sounds.StopLoopingSound();
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

    private void LaserStop()
    {
        if (_ammoStockpile.LaserCharge < 0.0f)
        {
            _lineRenderer.enabled = false;
            _sounds.StopLoopingSound();
        }
    }

    void Awake()
    {
        _ammoStockpile = GameObject.Find("SpaceShip").GetComponent<AmmoStockpile>();
        _weaponSwitcher = GameObject.Find("Ship's Armament").GetComponent<WeaponSwitcher>();
        _sounds = GetComponent<Sounds>();
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
        LaserStop();

        if (gameObject == true)
        {
            OnRay?.Invoke();
        }
    }
}