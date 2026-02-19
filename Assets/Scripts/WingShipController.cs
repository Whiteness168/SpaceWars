using System.Threading.Tasks;
using UnityEngine;

public class WingShipController : MonoBehaviour {
    [SerializeField] private GameObject _wing;
    [SerializeField] private Health _health;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _desiredZAngle;

    private bool _isActivate;
    private bool _animationPlayed;

    private float _startZAngle;
    private SpriteRenderer _spriteRenderer;

    public bool IsActivate {
        get { return _isActivate; }
    }

    private void ActivateWing() {
        //RotatableController.Rotate(_wing, _rotationSpeed, _desiredZAngle);
        //if (_isActivate == false)
        //{
        RotatableController.Rotate(gameObject, _rotationSpeed, _desiredZAngle);
        _isActivate = true;
        //}
    }

    private void DeactivateWing() {
        RotatableController.Rotate(_wing, _rotationSpeed, _startZAngle);
        _isActivate = false;
    }

    private async void WingExplosion() {
        if (_health.HealthPoint <= 0) {
            _animator.SetBool("IsDead", _animationPlayed);
            _isActivate = false;
            await Task.Delay(510);
            _wing.SetActive(false);
        }
    }

    private void Awake() {
        _startZAngle = gameObject.transform.rotation.z;
        _isActivate = false;
        _animationPlayed = true;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        ActivateWing();
        WingExplosion();
    }
}
