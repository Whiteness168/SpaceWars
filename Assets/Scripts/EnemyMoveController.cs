using System;
using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{
    [SerializeField]
    protected float _speed;
    [SerializeField]
    private int _direction;
    [SerializeField]
    private Rigidbody2D _rb;

    private float _targetY;

    public event Action OnStop;

    void SetTargetPoint()
    {
        _targetY = transform.position.y - 7.0f;
    }

    void StopMove()
    {
        if (transform.position.y <= _targetY)
        {
            _rb.velocity = Vector2.zero;
            OnStop?.Invoke();
        }
    }

    private void Move()
    {
        _rb.AddForce(_speed * _direction * transform.up, ForceMode2D.Impulse);
    }

    void Start()
    {
        SetTargetPoint();
        Move();
    }

    void Update()
    {
        StopMove();
    }
}