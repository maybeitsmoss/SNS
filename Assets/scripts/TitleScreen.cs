using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("thissomebullshit");
    }
    public void LoadScene()
    {
        SceneManager.LoadSceneAsync("credits");

    }

    public void LoadLevel()
    {
        Debug.Log("Loaded Level");

        SceneManager.LoadScene("TitleScreen");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
