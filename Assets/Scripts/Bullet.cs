using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Weapon
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rb;
    public override float Damage => 0.25f;

    void Start()
    {
        _rb.velocity = transform.up * _speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            DealDamage(other.gameObject.GetComponent<Enemy>());
            Destroy(gameObject);
            Debug.Log("Hit");
        }
    }

    private void Update()
    {
        var max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if (transform.position.y > max.y)
        {
            Destroy(gameObject, .3f);
        }
    }
}
