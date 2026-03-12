using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleScreen : MonoBehaviour
{
    public GameObject circleWipe;
    private Animator circleAnimator;

    public TitleMusic titleMusicScript;

    //private GameObject bgMusicObj;
    //private BGmusic BGmusicScript;

    void Start()
    {
        //bgMusicObj = GameObject.Find("TitleMusic");

        if(SceneManager.GetActiveScene().name == "TitleScreen")
        {
            //BGmusicScript = bgMusicObj.GetComponent<BGmusic>();
            circleAnimator = circleWipe.GetComponent<Animator>();
            circleWipe.SetActive(false);
        }
        
    }

    public void PlayGame()
    {
        //BGmusicScript.Restart();
        //SceneManager.LoadSceneAsync("thissomebullshit");
        //BGmusicScript.StartCoroutine("StopMusic");
        titleMusicScript.StartCoroutine("StopMusic");
        //titleMusicScript.StartCoroutine("StopIntroMusic");
        StartCoroutine(SceneTransition("thissomebullshit"));
    }
    public void LoadScene()
    {
        //BGmusicScript.noRestart();
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


        
        //BGmusicScript.StopTitleMusic();

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
