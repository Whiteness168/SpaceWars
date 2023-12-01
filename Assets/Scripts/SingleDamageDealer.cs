using UnityEngine;

public class SingleDamageDealer : DamageDealer
{            
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();

        if (health != null)
        {
            if (gameObject.CompareTag("Player"))
            {
                if (collision.name != "SpaceShip")
                {
                    DealDamage(health);
                    GetComponent<DeathController>().Die();
                }
            }
            else
            {
                DealDamage(health);
                GetComponent<DeathController>().Die();
            }
        }
    }
}
