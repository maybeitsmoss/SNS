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

    void Start()
    {
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
        conductor.StartCoroutine("FadeOut");
        Resume();
        Cursor.visible = false;
        StartCoroutine(SceneTransition(SceneManager.GetActiveScene().buildIndex));
    }

    public void NextLevel()
    {
        Resume();
        Cursor.visible = false;
        StartCoroutine(SceneTransition(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void MainMenu()
    {
        conductor.StartCoroutine("FadeOut");
        Resume();
        Cursor.visible = false;
        StartCoroutine(SceneTransition(0));
    }

    IEnumerator SceneTransition(int sceneIndex)
    {
        //int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        circleAnimator.SetBool("wipe", true);
        

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(sceneIndex);

        if(attemptTracker.allowSkip == true)
        {
            attemptTracker.Reset();
        }
        Debug.Log("loaded");
        
    }
}
