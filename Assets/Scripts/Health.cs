using UnityEngine;
using System.Threading.Tasks;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float _healthPoint;

    public float HealthPoint
    {
        get { return _healthPoint; }
    }
    private bool _functionCalled;
    public bool FunctionCalled
    { 
        get { return _functionCalled; } 
    }

    public bool IsAlive => _healthPoint <= 0f;

    public void TakeDamage(float damage)
    {
        _healthPoint -= damage;
        _functionCalled = true;
        Debug.Log("Damage");
    }

    private async void DefaultFunctionCalled()
    {
        if (_functionCalled == true)
        {
            await Task.Delay(100);
            _functionCalled = false;
        }
    }

    private void Update()
    {
        DefaultFunctionCalled();
    }
}
