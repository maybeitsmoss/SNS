using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class levelManager : MonoBehaviour
{
    public GameObject circleWipe;
    private Animator circleAnimator;
    private bool paused = false;
    public GameObject pauseMenu;
    public Conductor_2 conductor;
    private GameObject tutorialConductor;
    private AudioSource tutorialAudio;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "thissomebullshit")
        {
            tutorialConductor = GameObject.Find("tutorialConductor");
            tutorialAudio = tutorialConductor.GetComponent<AudioSource>();
        }

        pauseMenu.SetActive(false);
        circleAnimator = circleWipe.GetComponent<Animator>();
        circleAnimator.SetBool("wipe", false);
    }

    void Update()
    {
        if (Input.anyKeyDown && paused == false)
        {
            if (!(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)))
            {
                Pause();
            }
            
        }
        else if (Input.anyKeyDown && paused == true)
        {
            if (!(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)))
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
        paused = true;
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
        paused = false;
    }

    public void LoadScene(int sceneIndex)
    {
        Resume();
        Cursor.visible = false;
        StartCoroutine(SceneTransition(sceneIndex));
    }

    public void Restart()
    {
        if (SceneManager.GetActiveScene().name != "thissomebullshit")
        {
            conductor.StartCoroutine("FadeOut");
        }
        Resume();
        Cursor.visible = false;
        StartCoroutine(SceneTransition(SceneManager.GetActiveScene().buildIndex));
    }

    public void NextLevel()
    {
        Resume();
        Cursor.visible = false;
        attemptTracker.Reset();
        StartCoroutine(SceneTransition(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void MainMenu()
    {
        if (SceneManager.GetActiveScene().name != "thissomebullshit")
        {
            conductor.StartCoroutine("FadeOut");
        }
        Resume();
        Cursor.visible = false;
        StartCoroutine(SceneTransition(0));
    }

    IEnumerator SceneTransition(int sceneIndex)
    {
        //int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        circleAnimator.SetBool("wipe", true);

        if (SceneManager.GetActiveScene().name == "thissomebullshit")
        {
            float volume = tutorialAudio.volume;

            while (volume > 0f)
            {
                volume -= 0.01f;
                tutorialAudio.volume = volume;
                yield return null;
            }
        }
        

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(sceneIndex);

        //desired behavior: after three deaths, allow the player to skip the level. they may continue to retry the level as many times as
        //                  they like with the skip function remaining available, until they either skip the level or beat it.

        //current behavior: the option to skip the level appears only once every three attempts

        //problem: when the player progresses to the next level, if the player was allowed to skip, the counter is reset.
        //          this means when the player is able to skip but instead choose to replay, the counter is reset, because 
        //          the scene changes while allowSkip == true.


        

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("loaded");
        
    }
}
