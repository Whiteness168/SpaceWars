using UnityEngine;

[RequireComponent(typeof(Pool))]
public class SpawnerMeteorController : MonoBehaviour
{
    private float _randomX;
    private Vector2 _whereToSpawn;
    [SerializeField]
    private float _spawnDelay;
    [SerializeField]
    private Transform _firePoint;
    private float _nextSpawn = 0.0f;
    private Pool _pool;

    private void SpawnEnemy()
    {
        if (Time.time > _nextSpawn)
        {
            _nextSpawn = Time.time + _spawnDelay;
            _randomX = Random.Range(-9f, 9f);
            _whereToSpawn = new Vector2(_randomX, _firePoint.position.y);
            _pool.GetFreeElement(_whereToSpawn, Quaternion.identity);
        }
    }

    private void Awake()
    {
        _pool = GetComponent<Pool>();
    }

    void Update()
    {
        SpawnEnemy();
    }
}