using UnityEngine;

public class AOEDamageDealer : DamageDealer
{
    [SerializeField] 
    private CapsuleCollider2D _collision;
    [SerializeField] 
    private CircleCollider2D _explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();

        if (health != null)
        {
            if (collision.name != "SpaceShip")
            {
                _collision.enabled = false;
                _explosion.enabled = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();

        if (health != null )
        {
            if (collision.name != "SpaceShip")
            {
                DealDamage(collision.GetComponent<Health>());
                _deathController.Die();
            }
        }
    }

    private void OnEnable()
    {
        _collision.enabled = true;
        _explosion.enabled = false;
    }
}