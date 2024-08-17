using System;
using UnityEngine;

[RequireComponent(typeof(PoolObject))]
public class DeathController : MonoBehaviour
{
    private Health _health;
    private PoolObject _poolObject;
    private ScoreManager _scoreManager;

    public event Action OnDeath;

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
    }

    private bool CheckHealth()
    {
        if (gameObject.GetComponent<Health>() != null && gameObject.GetComponent<Health>().HealthPoint <= 0)
        {
            return true;
        }
        else
            return false;
    }

    private void Awake()
    {
        _poolObject = GetComponent<PoolObject>();
        _health = GetComponent<Health>();
        _scoreManager = GameObject.Find("ScoreBar").GetComponent<ScoreManager>();
    }

    void Update()
    {
        if (CheckHealth())
        {
            _scoreManager.CalculateScore(gameObject.name);
            Die();
        }
    }
}