using System.Threading.Tasks;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    [SerializeField]
    private Sounds _sounds;
    [SerializeField]
    private PoolObject _poolObject;

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

    private void OnEnable ()
    {
        PlaySoundExplosion();
        DeleteExplosion();
    }
}