using UnityEngine.SceneManagement;

public class LosePanelManager : BaseMenuPanel
{
    private string _currentScene;

    private void TryAgainLevel()
    {
        SceneTransition.SwitchToScene(_currentScene);
    }

    private void Awake()
    {
        _currentScene = SceneManager.GetActiveScene().name;
    }

    protected override void Start()
    {
        base.Start();
        _firstButton.onClick.AddListener(TryAgainLevel);
        _secondButton.onClick.AddListener(HidePanel);
        _thirdButton.onClick.AddListener(HidePanel);
    }
}