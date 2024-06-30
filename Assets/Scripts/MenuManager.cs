using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Button _buttonStart;
    [SerializeField]
    private Button _buttonLevel;
    [SerializeField]
    private Button _buttonQuit;

    private void OnClickStart()
    {
        SceneTransition.SwitchToScene("GamePlay");
    }

    private void ExitGame()
    {
        Application.Quit();
    }
    void Start()
    {
        _buttonStart.onClick.AddListener(OnClickStart);
        _buttonQuit.onClick.AddListener(ExitGame);
    }
}