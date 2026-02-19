using UnityEngine;

public abstract class Enemy : MonoBehaviour {
    [SerializeField] private Pool _pool;
    [SerializeField] private GameObject _player;
    [SerializeField] private RayController _rayController;
    [SerializeField] private Transform _firePoint;

    [SerializeField] private float _shootDelay;
    [SerializeField] private float _nextShoot;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _desiredZAngle;

    private bool _canShoot;

    private Transform _entity;
    private Transform _cloneEnemy;
    private Transform _playerLocation;

    private void Shoot() {
        if (Time.time > _nextShoot && DetectedCollision() && _canShoot) {
            _nextShoot = Time.time + _shootDelay;
            _pool.GetFreeElement(_firePoint.position, _entity.rotation);
            //_sounds.PlayClip();
        }
    }

    protected void CanShoot() {
        _canShoot = true;
    }

    private bool DetectedCollision() {
        Collider2D collider = _rayController.Hit.collider;

        if (collider != null && _rayController.LineRenderer.enabled) {
            if (collider.gameObject.name == _player.name) {
                Debug.Log(collider.gameObject.name);

                return true;
            }
        }

        return false;
    }

    private void FindPlayer() {
        Collider2D collider = _rayController.Hit.collider;

        if (_rayController.LineRenderer.enabled && _canShoot && collider == null) {
            if (_entity.transform.position.x < _playerLocation.position.x) {
                RotatableController.Rotate(gameObject, _rotationSpeed, _desiredZAngle);
            }
            else if (_entity.transform.position.x > _playerLocation.position.x) {
                RotatableController.Rotate(gameObject, _rotationSpeed, -_desiredZAngle);
            }
        }
    }

    protected virtual void Awake() {
        _entity = gameObject.transform;
        _playerLocation = GameObject.Find("SpaceShip").transform;
    }

    protected virtual void Update() {
        Shoot();
        FindPlayer();
    }
}
