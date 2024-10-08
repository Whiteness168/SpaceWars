using UnityEngine;

public abstract class DamageDealer : MonoBehaviour
{
    [SerializeField]
    protected float _damage;

    private float _bonusDamage;

    protected DeathController _deathController;

    protected void DealDamage(Health health)
    {
        health.TakeDamage(_damage + _bonusDamage);
    }

    protected virtual void Awake()
    {
        _deathController = GetComponent<DeathController>();
    }
}