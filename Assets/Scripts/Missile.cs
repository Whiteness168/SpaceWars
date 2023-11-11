using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Missile : Weapon
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private CapsuleCollider2D _collision;
    [SerializeField] private CircleCollider2D _explosion;
    public override float Damage => 100;

    void Start()
    {
        _rb.velocity = transform.up * _speed;
        _collision.enabled = true;
        _explosion.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy> ();

        if (enemy != null)
        {
            Debug.Log("Hit");
            _explosion.enabled = true;
            _collision.enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy> ();

        if (enemy != null)
        {
            DealDamage(enemy);
            Destroy(gameObject);
        }
        _explosion.enabled = false;
        _collision.enabled = true;
    }

    private void Explosion()
    {
        Enemy enemy = _collision.gameObject.GetComponent<Enemy>();

        Debug.Log("Explosion");
        if (enemy != null)
        {
            DealDamage(enemy);
            Destroy(gameObject);
            _explosion.enabled = false;
        }
    }


    void Update()
    {
        var max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if (transform.position.y > max.y)
        {
            Destroy(gameObject, .3f);
        }
    }
}
