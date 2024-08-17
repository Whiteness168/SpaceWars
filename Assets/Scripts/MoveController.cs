using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField]
    private int _direction;
    [SerializeField]
    public Animator Animator;
    [SerializeField]
    private Rigidbody2D _rb;
    [SerializeField]
    private Transform _transform;
    [SerializeField]
    protected float _speed;


    public float Speed
    {
        get 
        { 
            return _speed;
        }
        set 
        { 
            _speed = value;
        }
    }

    private void Move()
    {
        _rb.AddForce(_speed * _direction * transform.up, ForceMode2D.Impulse);
    }

    void CopyTransformProperties()
    {
        if (_transform != null)
        {
            transform.position = _transform.position;
            transform.rotation = _transform.rotation;
            transform.localScale = _transform.localScale;
        }
    }

    private void Start()
    {
        Speed = _speed;
    }

    void OnEnable()
    {
        CopyTransformProperties();
        Move();
    }
}