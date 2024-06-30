using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb;
    [SerializeField]
    protected float _speed;
    [SerializeField]
    private int _direction;
    private Vector3 _newPosition;
    private float _targetY;

    void Start()
    {
        //���������� ������� ������� ��������� ��� ������� ���� ��������
        _targetY = transform.position.y - 7.0f; // ����������� ������ ��� ����������
        _rb.AddForce(_speed * _direction * transform.up, ForceMode2D.Impulse);
    }

    void Update()
    {
        //���� ������� ������� �� Y ������ ��� ����� ������� ������� ���������, ���������� �������
        if (transform.position.y <= _targetY)
        {
            _rb.velocity = Vector2.zero;
            Debug.Log("Stop");
        }

        AlienEnemyController alienEnemyController = GetComponent<AlienEnemyController>();
        alienEnemyController.arrayAlienEnemy[5].GetComponent<Rigidbody2D>().AddForce(_speed * _direction * transform.up, ForceMode2D.Impulse);
    }
}