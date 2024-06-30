using UnityEngine;
using System.Threading.Tasks;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float _healthPoint;
    private float _startHealthPoint;
    private Sounds _sounds;

    public float HealthPoint
    {
        get { return _healthPoint; }
    }
    private bool _functionCalled;
    public bool FunctionCalled
    { 
        get { return _functionCalled; } 
    }
    private float _reducedLaserResistance;
    public float ReducedLaserResistance
    {
        set { _reducedLaserResistance = value;}
        get { return _reducedLaserResistance;}
    }
    private Armor _armor;
    public bool IsAlive => _healthPoint <= 0f;

    public void TakeDamage(float damage)
    {
        damage += _reducedLaserResistance;

        if (_armor != null && _armor.ArmorPoint > 0)
        {
            _armor.BlockDamage(damage);

            if (_armor.ArmorPoint < 0)
            {
                _healthPoint -= Mathf.Abs(_armor.ArmorPoint);
                _functionCalled = true;
            }
        }
        else
        {
            _healthPoint -= damage;
            _functionCalled = true;
        }
    }

    public void AddHealthPoint(float healthPoint)
    {
        _sounds.PlayClip();
        if (_healthPoint + healthPoint > 1f)
        {
            NormalizeHealth();
        }
        else
        _healthPoint += healthPoint;
    }

    private async void DefaultFunctionCalled()
    {
        if (_functionCalled == true)
        {
            await Task.Delay(100);
            _functionCalled = false;
        }
    }

    public void NormalizeHealth()
    {
        _healthPoint = _startHealthPoint;
    }

    private void Awake()
    {
        _armor = gameObject.GetComponent<Armor>();
        _startHealthPoint = _healthPoint;
        _sounds = GetComponent<Sounds>();
    }

    private void Update()
    {
        DefaultFunctionCalled();
    }
}