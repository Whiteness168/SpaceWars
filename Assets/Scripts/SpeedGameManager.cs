using UnityEngine;

public class SpeedGameManager : MonoBehaviour
{
    [SerializeField]
    private float _delay;
    [SerializeField]
    private float _maxTime;
    [SerializeField]
    private float _nextBoost;
    [SerializeField]
    private float _boostScrollBack;
    [SerializeField]
    private float _boostSpeedMeteor;
    [SerializeField]
    private float _boostSpawnDelay;
    [SerializeField]
    private float _boostSpeedPlayer;
    [SerializeField]
    private float _boostSpeedBonus;

    private Pool _pool;
    private ScrollBackGround _backGround;
    private MoveController[] _bonusMoveController;
    private MoveController[] _meteorMoveController;
    private PlayerMoveController _playerMoveController;
    private SpawnerController _spawnerMeteorController;   

    private bool BoostTimer()
    {
        if (Time.time > _nextBoost && Time.time < _maxTime)
        {
            _nextBoost = Time.time + _delay;
            return true;
        }
        else 
            return false;
    }

    private void BoostSpeedBackground()
    {
         _backGround.firstBGSpeed += _boostScrollBack;
    }

    private void BoostSpeedSpawn()
    {
        if (_spawnerMeteorController.SpawnDelay > 0)
        {
            _spawnerMeteorController.SpawnDelay -= _boostSpawnDelay;
        }
    }

    private void BoostSpeedEnemy()
    {
        for (int i = 0; i < _meteorMoveController.Length; i++)
        {
            _meteorMoveController[i].Speed += _boostSpeedMeteor;
        }
    }

    private void BoostSpeedPlayer()
    {
        _playerMoveController.Speed += _boostSpeedPlayer;
    }

    private void BoostSpeedBonus()
    {
        for (int i = 0; i < _bonusMoveController.Length; i++)
        {
            _bonusMoveController[i].Speed += _boostSpeedBonus;
        }
    }

    private void NormalizeTime()
    {
        Time.timeScale = 1f;
    }

    private void Awake()
    {
        _backGround = GameObject.Find("ScrollBack").GetComponent<ScrollBackGround>();
        _spawnerMeteorController = GameObject.Find("SpawnerMeteor").GetComponent<SpawnerController>();
        _playerMoveController = GameObject.Find("SpaceShip").GetComponent<PlayerMoveController>();
    }

    private void Start()
    {
        _pool = GameObject.Find("SpawnerMeteor").GetComponent<Pool>();
        _meteorMoveController = new MoveController[_pool.PoolObject.Count];

        for (int i = 0; i < _pool.PoolObject.Count; i++)
        {
            _meteorMoveController[i] = _pool.PoolObject[i].GetComponent<MoveController>();
        }

        _pool = GameObject.Find("SpawnerBonus").GetComponent<Pool>();
        _bonusMoveController = new MoveController[_pool.PoolObject.Count];

        for (int i = 0; i < _pool.PoolObject.Count;i++)
        {
            _bonusMoveController[i] = _pool.PoolObject[i].GetComponent <MoveController>();
        }

        NormalizeTime();
    }

    private void Update()
    {
        if (BoostTimer())
        {
            BoostSpeedEnemy();
            BoostSpeedPlayer();
            BoostSpeedSpawn();
            BoostSpeedBackground();
        }
    }
}