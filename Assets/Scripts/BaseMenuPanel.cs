using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class BaseMenuPanel : MonoBehaviour
{
    [SerializeField]
    protected Button _firstButton;
    [SerializeField]
    protected Button _secondButton;
    [SerializeField]
    protected Button _thirdButton;
    [SerializeField]
    protected GameObject _menuPanel;

    protected bool _pauseGame;

    [SerializeField]
    private TextMeshProUGUI _score;
    [SerializeField]
    private ScoreManager _scoreManager;

    private void ShowScore()
    {
        if (_score != null && _scoreManager != null)
        {
            _score.text = _scoreManager.Score.ToString();
        }
    }

    private void GoToMainMenu()
    {
        Resume();
        SceneTransition.SwitchToScene("DemoMenu");
    }

    protected virtual void Pause()
    {
        Time.timeScale = 0f;
    }

    protected void Resume()
    {
        Time.timeScale = 1f;
    }

    protected void HidePanel()
    {
        _menuPanel.SetActive(false);
    }

    protected void ShowPanel()
    {
        _menuPanel.SetActive(true);
    }

    protected void ExitGame()
    {
        Application.Quit();
    }

    protected virtual void Start()
    {
        _firstButton.onClick.AddListener(HidePanel);
        _secondButton.onClick.AddListener(GoToMainMenu);
        _thirdButton.onClick.AddListener(ExitGame);
    }

    protected virtual void CheckCondition()
    {
        if (_menuPanel.activeSelf)
        {
            Pause();
        }
    }

    protected virtual void Update()
    {
        CheckCondition();
        ShowScore();
    }
}