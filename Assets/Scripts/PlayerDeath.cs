using UnityEngine.SceneManagement;

public class PlayerDeath : DeathController
{
    void Update()
    {
        if (CheckHealth())
        {
            SceneManager.LoadScene(0);
        }
    }
}
