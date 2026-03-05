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
  
    public void QuitGame()
    {
        Application.Quit();
    }
}
