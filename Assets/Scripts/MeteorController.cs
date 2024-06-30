using UnityEngine;

public class MeteorController : MonoBehaviour
{
    [SerializeField]
    protected GameObject _explosion;
    [SerializeField]
    private GameObject _explosionAnimation;
    private Pool _pool;
    private PoolObject _poolObject;

    private void Explosion()
    {
        var pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (_explosionAnimation != null)
        {
            //GameObject explosionAnimationRef = Instantiate(_explosionAnimation, pos, Quaternion.identity);
            _pool.GetFreeElement(pos, Quaternion.identity);
        }

        GameObject explosionRef = Instantiate(_explosion, pos, Quaternion.identity);

        Destroy(explosionRef, 3f);
    }

    private void Start()
    {
        _pool = GetComponent<Pool>();
        GetComponent<DeathController>().OnDeath += Explosion;
    }
}