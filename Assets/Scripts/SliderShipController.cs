using UnityEngine;
using System.Threading.Tasks;

public class SliderShipController : Enemy {
    [SerializeField] private Health _health;
    [SerializeField] private Collider2D _shieldCollider;
    [SerializeField] private SpriteRenderer _shieldSpriteRenderer;
    [SerializeField] private WingShipController _firstWing;
    [SerializeField] private WingShipController _secondWing;

    private Color _colorShield;

    private void BlockDamage() {
        if (_firstWing.IsActivate && _secondWing.IsActivate) {
            EnabledShield();
            IgnoreDamage();
        }
    }

    private void EnabledShield() {
        _colorShield.a = 1f;
        _shieldSpriteRenderer.color = _colorShield;
    }

    private void IgnoreDamage() {
        _health.NormalizeHealth();
    }

    private async void DisabledShield() {
        if (_colorShield.a == 1f) {
            _colorShield.a = 0f;
            await Task.Delay(200);
            _shieldSpriteRenderer.color = _colorShield;
        }
    }

    protected override void Awake() {
        _colorShield = _shieldSpriteRenderer.color;
        _health.TookDamage += BlockDamage;
    }

    protected override void Update() {
        DisabledShield();
    }
}
