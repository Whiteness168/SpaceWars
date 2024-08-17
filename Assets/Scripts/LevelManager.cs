using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private GameObject _losePanel;
    [SerializeField]
    private GameObject _winPanel;
    [SerializeField]
    private GameObject _meteorSpawner;
    [SerializeField]
    private GameObject _bonusSpawner;
    [SerializeField]
    private GameObject _alienSpawner;
    [SerializeField]
    private ScoreManager _scoreManager;

    private bool _finish;
    private bool _levelControl;
    private Health _playerHealth;
    private Armor _playerArmor;
    private string _currentScene;
    private ushort _currentLevel;

    private void CheckLevel()
    {
        if (_currentScene == "GamePlay")
        {
            _currentLevel = 1;
            _meteorSpawner.SetActive(true);
        }
    }

    private void SetupLevel()
    {
        switch (_currentLevel)
        {
            case 1:
            {
                FirstLevel();
                break;
            }    
        }
    }

    private void FirstLevel()
    {
        if (CheckProgress())
        {
            _playerHealth.NormalizeHealth();
            _playerArmor.NormalizeArmor();
            _meteorSpawner.SetActive(false);
            _alienSpawner.GetComponent<AlienEnemyController>().enabled = true;
        }
        else
        {
            IsFinish(CheckAllEnemiesDefeated());
        }
    }

    private bool CheckProgress()
    {
        if (_scoreManager.Score >= 10 && _levelControl == true)
        {
            _levelControl = false;
            return true;
        }
        return false;
    }

    private bool CheckAllEnemiesDefeated()
    {
        if (_scoreManager.AmountKilledAliens == 39)
        {
            return true;
        }
        return false;
    }

    private void CheckLevelOutcome()
    {
        if (_playerHealth.HealthPoint <= 0)
        {
            ShowLosePanel();
        }
        if (_finish)
        {
            ShowWinPanel();
        }
    }

    private void IsFinish(bool finish)
    {
        _finish = finish;
    }

    private void ShowWinPanel()
    {
        _winPanel.SetActive(true);
    }

    private void ShowLosePanel()
    {
        _losePanel.SetActive(true);
    }

    private void Awake()
    {
        _levelControl = true;
        _currentScene = SceneManager.GetActiveScene().name;
        _playerHealth = _player.GetComponent<Health>();
        _playerArmor = _player.GetComponent<Armor>();
    }

    private void Start()
    {
        CheckLevel();
    }

    void Update()
    {
        SetupLevel();
        CheckLevelOutcome();
    }
} 