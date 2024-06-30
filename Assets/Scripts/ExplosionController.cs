using System.Threading.Tasks;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    private Pool _pool;
    private PoolObject _poolObject;
    private Sounds _sounds;

    private void PlaySoundExplosion()
    {
        _sounds.PlayClip();
        Debug.Log("Booom!");
    }

    private async void DeleteExplosion() 
    {
        await Task.Delay(1000);
        _poolObject.ReturnToPool();
    }

    private void Start()
    {
        _pool = GetComponent<Pool>();
        _sounds = GetComponent<Sounds>();
        _poolObject = GetComponent<PoolObject>();
    }

    private void OnEnable ()
    {
        _pool = GetComponent<Pool>();
        _sounds = GetComponent<Sounds>();
        _poolObject = GetComponent<PoolObject>();
        PlaySoundExplosion();
        DeleteExplosion();
    }
}