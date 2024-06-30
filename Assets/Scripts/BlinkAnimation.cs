using System.Threading.Tasks;
using UnityEngine;

public class BlinkAnimation : MonoBehaviour
{
    [SerializeField]
    private Material _matBlink;
    [SerializeField]
    private Material _matDefault;
    [SerializeField]
    private SpriteRenderer _spriteRend;

    private Health _health;
    private async void PerformBlink()
    {
        if (_health.FunctionCalled == true)
        {
            _spriteRend.material = _matBlink;
            await Task.Delay(200);

            if (_spriteRend != null)
            {
                _spriteRend.material = _matDefault;
            }
        }
    }

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    void Update()
    {
        PerformBlink();
    }
}