using UnityEngine;

[RequireComponent(typeof(Pool))]
public class SpawnerController : MonoBehaviour
{
    [SerializeField]
    private bool _randomSpawn;
    [SerializeField]
    private float _spawnDelay;
    [SerializeField]
    private Transform _firePoint;

    private Pool _pool;
    private float _randomX;
    private float _nextSpawn;
    private Vector2 _whereToSpawn;

    public float SpawnDelay
    {
        get
        {
            return _spawnDelay; 
        } 
        set
        {
            _spawnDelay = value; 
        }
    }

    private void SpawnEnemy()
    {
        if (Time.time > _nextSpawn)
        {
            if (_randomSpawn)
            {
                _spawnDelay = Random.Range(5f, 10f);
            }
            _nextSpawn = Time.time + _spawnDelay;
            _randomX = Random.Range(-9f, 9f);
            _whereToSpawn = new Vector2(_randomX, _firePoint.position.y);
            _pool.GetFreeElement(_whereToSpawn, Quaternion.identity);
        }
    }

    private void Awake()
    {
        _pool = GetComponent<Pool>();
        SpawnDelay = _spawnDelay;
    }

    void Update()
    {
        SpawnEnemy();
    }
}