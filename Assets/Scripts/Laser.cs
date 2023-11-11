using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Weapon
{
    [SerializeField] private LayerMask _hitLayer;
    [SerializeField] private float _laserLength;
    private Vector2 _laserStart;
    private Vector2 _laserDirection;

    private LineRenderer _lineRenderer;
    private bool _isLaserActive;
    public override float Damage => 0.01f;
    private float _damageTimer = 0.0f;

    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.enabled = false;
    }

    void Update()
    {
        if (Input.GetKey(_activationKey))
        {
            _isLaserActive = true;
        }
        else
        {
            _isLaserActive = false;
        }

        if (_isLaserActive)
        {
            _laserStart = transform.position;
            _laserDirection = transform.up;

            Ray2D laserRay = new Ray2D(_laserStart, _laserDirection);
            RaycastHit2D hit = Physics2D.Raycast(laserRay.origin, laserRay.direction, _laserLength, _hitLayer);

            _lineRenderer.enabled = true;
            _lineRenderer.SetPosition(0, _laserStart);

            if (hit.collider != null)
            {
                _lineRenderer.SetPosition(1, hit.point);
                Debug.Log("Столкновение с объектом: " + hit.collider.name);

                _damageTimer += Time.deltaTime;

                if (_damageTimer >= 0.01f && hit.collider.gameObject.GetComponent<Enemy>()) 
                {
                    DealDamage(hit.collider.gameObject.GetComponent<Enemy>());
                    _damageTimer = 0.0f;
                }
            }
            else
            {
                _lineRenderer.SetPosition(1, _laserStart + _laserDirection * _laserLength);
                _damageTimer = 0.0f;
            }
        }
        else
        {
            _lineRenderer.enabled = false;
            _damageTimer = 0.0f;
        }
    }
}
