using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleScreen : MonoBehaviour
{
    public GameObject circleWipe;
    private Animator circleAnimator;

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "TitleScreen")
        {
            circleAnimator = circleWipe.GetComponent<Animator>();
            circleWipe.SetActive(false);
        }
        
    }

    public void PlayGame()
    {
        //SceneManager.LoadSceneAsync("thissomebullshit");
        StartCoroutine(SceneTransition("thissomebullshit"));
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
        StartCoroutine(SceneTransition("quit"));
    }

    IEnumerator SceneTransition(string sceneName)
    {
        circleWipe.SetActive(true);

        circleAnimator.SetBool("wipe", true);
        

        yield return new WaitForSeconds(2f);

        if (sceneName == "quit")
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(sceneName);
            Debug.Log("loaded");
        }
        
    }
}
