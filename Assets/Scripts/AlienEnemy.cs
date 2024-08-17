using UnityEngine;
public class AlienEnemy : MonoBehaviour
{
    [SerializeField]
    private Pool _pool;
    [SerializeField]
    private float _nextShoot;
    [SerializeField]
    private float _shootDelay;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private float _rotationSpeed;
    [SerializeField]
    private Transform _firePoint;
    [SerializeField]
    private RayController _rayController;

    private bool _canShoot;
    private Transform _enemy;
    private Transform _cloneEnemy;
    private Transform _payerLocation;

    private void Shoot()
    {
        if (Time.time > _nextShoot && DetectedCollision() && _canShoot)
        {
            _nextShoot = Time.time + _shootDelay;
            _pool.GetFreeElement(_firePoint.position, _enemy.rotation);
            //_sounds.PlayClip();
        }

    }

    private bool DetectedCollision()
    {
        Collider2D collider = _rayController.Hit.collider;

        if (collider != null && _rayController.LineRenderer.enabled)
        {
            if (collider.gameObject.name == _player.name)
            {
                Debug.Log(collider.gameObject.name);
                return true;
            }
        }
        return false;
    }

    private void FindPlayer()
    {
        Collider2D collider = _rayController.Hit.collider;

        if (_rayController.LineRenderer.enabled && _canShoot)
        {
            if (collider == null)
            {
                Vector3 currentEulerAngles = _enemy.transform.eulerAngles;

                float angleZ = currentEulerAngles.z;
                if (angleZ > 180)
                {
                    angleZ -= 360;
                }

                if (_enemy.transform.position.x < _payerLocation.position.x && angleZ < 30)
                {
                    currentEulerAngles.z += _rotationSpeed * Time.deltaTime;
                }
                else if (_enemy.transform.position.x > _payerLocation.position.x && angleZ > -30)
                {
                    currentEulerAngles.z -= _rotationSpeed * Time.deltaTime;
                }
                _enemy.transform.eulerAngles = currentEulerAngles;
            }
        }
    }
    private void CanShoot()
    {
        _canShoot = true;
    }

    private void Awake()
    {
        _enemy = gameObject.transform;
        _payerLocation = GameObject.Find("SpaceShip").transform;
        GetComponent<EnemyMoveController>().OnStop += CanShoot;
    }

    private void Update()
    {
        Shoot();
        FindPlayer();
    }
}