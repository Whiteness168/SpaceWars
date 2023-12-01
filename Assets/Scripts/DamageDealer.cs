using UnityEngine;

public abstract class DamageDealer : MonoBehaviour
{
    [SerializeField]
    protected float _damage;

    protected void DealDamage(Health health)
    {
        health.TakeDamage(_damage);
    }
}
