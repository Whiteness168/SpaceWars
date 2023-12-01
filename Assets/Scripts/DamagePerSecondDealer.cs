using UnityEngine;

public class DamagePerSecondDealer : DamageDealer
{
    private float _damageTimer;

    private void DetectedCollision()
    {
        Collider2D collider = gameObject.GetComponent<RayController>().Hit.collider;

        if (collider != null && collider.GetComponent<Health>() != null)
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

    void Start()
    {
        _damageTimer = 0.0f;
    }

    void Update()
    {
        DetectedCollision();
    }
}
