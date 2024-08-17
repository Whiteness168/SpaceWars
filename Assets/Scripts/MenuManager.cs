public class MenuManager : BaseMenuPanel
{
    private void OnClickStart()
    {
        SceneTransition.SwitchToScene("GamePlay");
    }

    private void ShowLevelMenu()
    {

    }

    protected override void Start()
    {
        _firstButton.onClick.AddListener(OnClickStart);
        _secondButton.onClick.AddListener(ShowLevelMenu);
        _thirdButton.onClick.AddListener(ExitGame);
        Resume();
    }

    protected override void Update()
    {

    }
}