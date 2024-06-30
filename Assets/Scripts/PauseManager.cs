using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private Button _buttonContinue;
    [SerializeField]
    private Button _buttonMainMenu;
    [SerializeField]
    private Button _buttonQuit;
    [SerializeField]
    private GameObject _pauseMenu;

    private bool _pauseGame;
    private KeyCode _key = KeyCode.Escape;

    private bool IsKeyPressed()
    {
        if (Input.GetKeyDown(_key))
        {
            return true;
        }

        return false;
    }

    private void GoToMainMenu()
    {
        Resume();
        SceneTransition.SwitchToScene("DemoMenu");
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void Pause()
    {
        _pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        _pauseGame = true;
    }

    private void Resume()
    { 
        _pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        _pauseGame = false;
    }

    private void CheckCondition()
    {
        if (IsKeyPressed())
        {
            if (!_pauseGame)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    void Start()
    {
        _buttonContinue.onClick.AddListener(Resume);
        _buttonMainMenu.onClick.AddListener(GoToMainMenu);
        _buttonQuit.onClick.AddListener(ExitGame);
    }

    void Update()
    {
        CheckCondition();
    }
}