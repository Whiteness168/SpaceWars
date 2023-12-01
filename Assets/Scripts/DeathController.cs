using System;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    private bool _functionCalled = false;
    public bool FunctionCalled
    {
        get { return _functionCalled; }
    }

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

    public void Die()
    {
        Destroy(gameObject);
    }


    void Update()
    {
        if (CheckHealth())
        {
            OnDeath?.Invoke();
            Die();
        }
    }
}
