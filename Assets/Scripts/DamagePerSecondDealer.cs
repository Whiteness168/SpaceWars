using UnityEngine;
public class DamagePerSecondDealer : DamageDealer
{
    private float _damageTimer;
    private RayController _rayController;

    private void DetectedCollision()
    {
        Collider2D collider = gameObject.GetComponent<RayController>().Hit.collider;

        if (collider != null && collider.GetComponent<Health>() != null && _rayController.LineRenderer.enabled)
        {
            Health health = collider.GetComponent<Health>();
            _damageTimer += Time.deltaTime;

            if (_damageTimer >= 0.01f)
            {
                DealDamage(health);
                _damageTimer = 0.0f;
            }
        }
        else _damageTimer = 0.0f;
    }

    protected override void Awake()
    {
        _rayController = GameObject.Find("Laser").GetComponent<RayController>();
    }
    void Start()
    {
        _damageTimer = 0.0f;
    }

    void Update()
    {
        DetectedCollision();
    }
}