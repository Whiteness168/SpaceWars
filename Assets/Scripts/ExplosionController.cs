using System.Threading.Tasks;
using UnityEngine;

public class ExplosionController : MonoBehaviour {
    [SerializeField] private int _timeDelay;
    [SerializeField] private Sounds _sounds;
    [SerializeField] private PoolObject _poolObject;

    private void PlaySoundExplosion() {
        _sounds.PlayClip();
        Debug.Log("Booom!");
    }

    private async void DeleteExplosion() {
        await Task.Delay(_timeDelay);
        _poolObject.ReturnToPool();
    }

    private void OnEnable() {
        PlaySoundExplosion();
        DeleteExplosion();
    }
}
