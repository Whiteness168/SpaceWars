using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    [SerializeField]
    private Text _loadingPercentage;
    [SerializeField]
    private Image _loadingProgressBar;

    private Animator _componentAnimator;
    private AsyncOperation _loadingSceneOperation;

    private static SceneTransition _instance;
    private static bool _shouldPlayOpeningAnimation = false;

    public static void SwitchToScene(string sceneName)
    {
        _instance._componentAnimator.SetTrigger("Scene Closing");

        _instance._loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);

        _instance._loadingSceneOperation.allowSceneActivation = false;

        _instance._loadingProgressBar.fillAmount = 0;
    }

    private void Start()
    {
        _instance = this;

        _componentAnimator = GetComponent<Animator>();

        if (_shouldPlayOpeningAnimation)
        {
            _componentAnimator.SetTrigger("Scene Opening");
            _instance._loadingProgressBar.fillAmount = 1;

            _shouldPlayOpeningAnimation = false;
        }
    }

    private void Update()
    {
        if (_loadingSceneOperation != null)
        {
            _loadingPercentage.text = Mathf.RoundToInt(_loadingSceneOperation.progress * 100) + "%";

            _loadingProgressBar.fillAmount = Mathf.Lerp(_loadingProgressBar.fillAmount, _loadingSceneOperation.progress,
                Time.deltaTime * 5);
        }
    }

    public void OnAnimationOver()
    {
        _shouldPlayOpeningAnimation = true;

        _loadingSceneOperation.allowSceneActivation = true;
    }
}