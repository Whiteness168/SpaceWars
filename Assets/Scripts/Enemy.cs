using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public virtual float Damage { get; protected set; }
    protected float Health;
    public virtual float Speed { get; protected set; }

    protected Material _matBlink;
    protected Material _matDefault;
    protected SpriteRenderer _spriteRend;

    protected UnityEngine.Object _explosion;

    public void CheckHealth()
    {
        if (Health <= 0f)
        {
            EnemyDeath();
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        _spriteRend.material = _matBlink;

        Invoke("ResourcesMaterial", 0.2f);
    }

    private void ResourcesMaterial()
    {
        _spriteRend.material = _matDefault;
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.name == "SpaceShip")
        {
            other.GetComponent<HealthBar>().TakeDamage(Damage);
            Destroy(gameObject);
        }
    }

    public void DestroyOutOfBounds()
    {
        var min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject, 0.3f);
        }
    }

    private void EnemyDeath()
    {
        GameObject explosionRef = (GameObject)Instantiate(_explosion);

        explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Destroy(explosionRef, 3f);
        Destroy(gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
