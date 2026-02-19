using System;
using UnityEngine;

public class EnemyMoveController : MonoBehaviour {
    [SerializeField] protected float _speed;
    [SerializeField] private int _direction;
    [SerializeField] private Rigidbody2D _rb;

    private float _targetY;

    public event Action OnStop;

    private void SetTargetPoint() {
        _targetY = transform.position.y - 7.0f;
    }

    private void StopMove() {
        if (transform.position.y <= _targetY) {
            _rb.linearVelocity = Vector2.zero;
            OnStop?.Invoke();
        }
    }

    private void Move() {
        _rb.AddForce(_speed * _direction * transform.up, ForceMode2D.Impulse);
    }

    private void Start() {
        SetTargetPoint();
        Move();
    }

    private void Update() {
        StopMove();
    }
}
