using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float _healthPoint;

    private Armor _armor;
    private Sounds _sounds;
    private float _startHealthPoint;
    private float _reducedLaserResistance;

    public event Action TookDamage;
    public event Action HealthZero;

    public float HealthPoint
    {
        get 
        { 
            return _healthPoint;
        }
    }

    public float ReducedLaserResistance
    {
        set
        { 
            _reducedLaserResistance = value;
        }
        get
        {
            return _reducedLaserResistance;
        }
    }
    
    public void TakeDamage(float damage)
    {
        damage += _reducedLaserResistance;
        TookDamage?.Invoke();

        if (_armor != null && _armor.ArmorPoint > 0)
        {
            _armor.BlockDamage(damage);

            if (_armor.ArmorPoint < 0)
            {
                _healthPoint -= Mathf.Abs(_armor.ArmorPoint);
            }
        }
        else
        {
            _healthPoint -= damage;
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
}