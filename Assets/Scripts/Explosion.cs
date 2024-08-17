using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private Pool _pool;
    [SerializeField]
    protected GameObject _explosionParticle;

    private Health _health;

    private void Explode()
    {
        var pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (_pool != null)
        {
            _pool.GetFreeElement(pos, Quaternion.identity);
        }

        if (_explosionParticle != null)
        {
            GameObject explosionRef = Instantiate(_explosionParticle, pos, Quaternion.identity);

            Destroy(explosionRef, 3f);
        }
    }

    private void Start()
    {
        if (gameObject.GetComponent<DeathController>() != null)
        {
            GetComponent<DeathController>().OnDeath += Explode;
        }
        else
        { 
            _health = GetComponent<Health>();
        }
    }

    private void Update()
    {
        if (_health != null)
        {
            if (_health.HealthPoint <= 0)
            {
                Explode();
            }    
        }
    }
}