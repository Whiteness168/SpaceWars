using UnityEngine;

[RequireComponent(typeof(Pool))]
public class BonusSpawnerController : MonoBehaviour
{
    private float _randomX;
    private Vector2 _whereToSpawn;
    private float _spawnDelay;
    [SerializeField]
    private Transform _firePoint;
    [SerializeField]
    private GameObject[] _bonusType;
    private float _nextSpawn = 0.0f;
    private Pool _pool;

    private void SpawnEnemy()
    {
        if (Time.time > _nextSpawn)
        {
            _spawnDelay = Random.Range(5f, 10f);
            _nextSpawn = Time.time + _spawnDelay;
            _randomX = Random.Range(-9f, 9f);
            _whereToSpawn = new Vector2(_randomX, _firePoint.position.y);
            _pool.GetFreeElement(_whereToSpawn, Quaternion.identity);
        }
    }

    private GameObject ChoiceBonus(int index)
    {
        return _bonusType[index];
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