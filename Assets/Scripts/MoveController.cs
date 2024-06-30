using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField]
    public Animator Animator;
    [SerializeField]
    private Rigidbody2D _rb;
    [SerializeField]
    protected float _speed;
    [SerializeField]
    private int _direction;

    private void Move()
    {
        _rb.AddForce(_speed * _direction * transform.up, ForceMode2D.Impulse);
    }

    void OnEnable()
    {
        Move();
    }
}