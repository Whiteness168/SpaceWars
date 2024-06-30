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
        //ќпределите целевую позицию остановки дл€ каждого р€да кораблей
        _targetY = transform.position.y - 7.0f; // »спользуйте нужное вам рассто€ние
        _rb.AddForce(_speed * _direction * transform.up, ForceMode2D.Impulse);
    }

    void Update()
    {
        //≈сли текуща€ позици€ по Y меньше или равна целевой позиции остановки, остановите корабль
        if (transform.position.y <= _targetY)
        {
            _rb.velocity = Vector2.zero;
            Debug.Log("Stop");
        }

        AlienEnemyController alienEnemyController = GetComponent<AlienEnemyController>();
        alienEnemyController.arrayAlienEnemy[5].GetComponent<Rigidbody2D>().AddForce(_speed * _direction * transform.up, ForceMode2D.Impulse);
    }
}