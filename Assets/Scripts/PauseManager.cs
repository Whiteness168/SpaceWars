using UnityEngine;

public class PauseManager : BaseMenuPanel
{
    private KeyCode _key;

    private bool IsKeyPressed()
    {
        if (Input.GetKeyDown(_key))
        {
            return true;
        }

        return false;
    }

    private void Awake()
    {
        _key = KeyCode.Escape;
    }

    protected override void CheckCondition()
    {
        if (IsKeyPressed())
        {
            if (!_menuPanel.activeSelf)
            {
                ShowPanel();
                Pause();
            }
            else
            {
                HidePanel();
                Resume();
            }
        }
    }

    protected override void Start()
    {
        _firstButton.onClick.AddListener(Resume);
        base.Start();
        
    }
}