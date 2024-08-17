using System;
using UnityEngine;

public class RayController : MonoBehaviour
{
    [SerializeField]
    private Sounds _sounds;
    [SerializeField]
    private bool _rayForEnemy;
    [SerializeField]
    private float _laserLength;
    [SerializeField] 
    private LayerMask _hitLayer;
    [SerializeField]
    private AmmoStockpile _ammoStockpile;
    [SerializeField]
    private WeaponSwitcher _weaponSwitcher;

    private Ray2D _laserRay;
    private bool _laserActive;
    private RaycastHit2D _hit;
    private Vector2 _laserStart;
    private Vector2 _laserDirection;
    private KeyCode _activationKey = KeyCode.LeftAlt;
    private LineRenderer _lineRenderer;

    public event Action OnRay;

    public LineRenderer LineRenderer
    { 
        get 
        {
            return _lineRenderer;
        } 
    }

    public bool LaserActive
    {  
        get 
        { 
            return _laserActive;
        } 
    }


    public RaycastHit2D Hit
    {
        get
        { 
            return _hit;
        }
    }

    public bool IsKeyPressed()
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
        if (_rayForEnemy || IsKeyPressed() && _ammoStockpile.LaserCharge > 0.0f )
        {
            if (_rayForEnemy || _ammoStockpile.AllAmmoCountCheck(_weaponSwitcher.CurrentWeaponIndex))
            {
                if (_rayForEnemy)
                {
                    _laserDirection = -transform.up;
                }
                else
                {
                    _laserDirection = transform.up;
                }
                _laserStart = transform.position;

                _laserRay = new Ray2D(_laserStart, _laserDirection);

                _lineRenderer.enabled = true;
                _lineRenderer.SetPosition(0, _laserStart);

                _laserActive = true;

                if (_ammoStockpile != null)
                {
                    _ammoStockpile.DecrementAmmo(_weaponSwitcher.CurrentWeaponIndex);

                    if (_ammoStockpile.LaserCharge > 0.0f)
                    {
                        _sounds.PlayLoopingSound();
                    }
                }
            }
        }
    }

    private void DetectLaserCollision()
    {
        _hit = Physics2D.Raycast(_laserRay.origin, _laserRay.direction, _laserLength, _hitLayer);

        if (_hit.collider != null)
        {
            _lineRenderer.SetPosition(1, _hit.point);
        }
        else
        {
            _lineRenderer.SetPosition(1, _laserStart + _laserDirection * _laserLength);
        }
    }

    private void LaserStop()
    {
        if (_ammoStockpile != null)
        {
            if (_ammoStockpile.LaserCharge < 0.0f || !IsKeyPressed())
            {
                _lineRenderer.enabled = false;
                _laserActive = false;
                _sounds.StopLoopingSound();
            }
        }
    }

    void Awake()
    {
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