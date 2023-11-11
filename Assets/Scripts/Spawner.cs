 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner  : MonoBehaviour
{
    [SerializeField] 
    private GameObject _obj;
    private float _randomX;
    private Vector2 _whereToSpawn;
    [SerializeField]
    private float _spawnDelay;
    private float _nextSpawn = 0.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _nextSpawn)
        {
            _nextSpawn = Time.time + _spawnDelay;
            _randomX = Random.Range(-9f, 9f);
            _whereToSpawn = new Vector2(_randomX, transform.position.y);
            Instantiate(_obj, _whereToSpawn, Quaternion.identity);
        }
    }
}
