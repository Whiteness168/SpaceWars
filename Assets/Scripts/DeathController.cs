using System;
using UnityEngine;

[RequireComponent(typeof(PoolObject))]
public class DeathController : MonoBehaviour
{
    private bool _functionCalled = false;
    public bool FunctionCalled
    {
        get { return _functionCalled; }
    }

    private PoolObject _poolObject;
    private Health _health;

    public event Action OnDeath;

    protected bool CheckHealth()
    {
        if (gameObject.GetComponent<Health>() != null && gameObject.GetComponent<Health>().HealthPoint <= 0)
        {
            return true;
        }
        else
            return false;
    }

    public void Delete()
    {
        if (_health != null)
        {
            _health.NormalizeHealth();
        }

        _poolObject.ReturnToPool();
    }

    public void Die()
    {
        OnDeath?.Invoke();

        if (_health != null)
        {
            _health.NormalizeHealth();
        }

        _poolObject.ReturnToPool();
        Debug.Log($"{gameObject.name} return to pool");
    }

    private void Awake()
    {
        _poolObject = GetComponent<PoolObject>();
        _health = GetComponent<Health>();
    }


    void Update()
    {
        if (CheckHealth())
        {
            Die();
        }
    }
}