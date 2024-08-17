public class WinPanelManger : BaseMenuPanel
{
    private void StartNextLevel()
    {
        
    }

    protected override void Start()
    {
        base.Start();
        _firstButton.onClick.AddListener(StartNextLevel);
        _secondButton.onClick.AddListener(HidePanel);
        _thirdButton.onClick.AddListener(HidePanel);
    }
}