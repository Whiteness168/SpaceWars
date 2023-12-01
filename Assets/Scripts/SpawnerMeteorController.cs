using UnityEngine;

public class SpawnerMeteorController : MonoBehaviour
{
    private float _randomX;
    private Vector2 _whereToSpawn;
    [SerializeField]
    private float _spawnDelay;
    [SerializeField]
    private Transform _firePoint;
    [SerializeField]
    private GameObject _missileType;
    private float _nextSpawn = 0.0f;

    private void SpawnEnemy()
    {
        if (Time.time > _nextSpawn)
        {
            _nextSpawn = Time.time + _spawnDelay;
            _randomX = Random.Range(-9f, 9f);
            _whereToSpawn = new Vector2(_randomX, _firePoint.position.y);
            Instantiate(_missileType, _whereToSpawn, Quaternion.identity);
        }
    }

    void Update()
    {
        SpawnEnemy();
    }
}
