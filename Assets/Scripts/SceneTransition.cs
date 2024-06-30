using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    [SerializeField]
    private Text _loadingPercentage;
    [SerializeField]
    private Image _loadingProgressBar;

    private static SceneTransition _instance;
    private Animator _componentAnimator;
    private AsyncOperation _loadingSceneOperation;

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

            // Чтобы если следующий переход будет обычным SceneManager.LoadScene, не проигрывать анимацию opening:
            _shouldPlayOpeningAnimation = false;
        }
    }

    private void Update()
    {
        if (_loadingSceneOperation != null)
        {
            _loadingPercentage.text = Mathf.RoundToInt(_loadingSceneOperation.progress * 100) + "%";

            // Просто присвоить прогресс:
            //LoadingProgressBar.fillAmount = loadingSceneOperation.progress; 

            // Присвоить прогресс с быстрой анимацией, чтобы ощущалось плавнее:
            _loadingProgressBar.fillAmount = Mathf.Lerp(_loadingProgressBar.fillAmount, _loadingSceneOperation.progress,
                Time.deltaTime * 5);
        }
    }

    public void OnAnimationOver()
    {
        // Чтобы при открытии сцены, куда мы переключаемся, проигралась анимация opening:
        _shouldPlayOpeningAnimation = true;

        _loadingSceneOperation.allowSceneActivation = true;
    }
}