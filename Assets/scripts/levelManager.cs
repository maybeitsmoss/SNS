using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class levelManager : MonoBehaviour
{
    public GameObject circleWipe;
    private Animator circleAnimator;

    void Start()
    {
        circleAnimator = circleWipe.GetComponent<Animator>();
        circleAnimator.SetBool("wipe", false);
    }

    public void LoadScene(int sceneIndex)
    {
        Cursor.visible = false;
        StartCoroutine(SceneTransition(sceneIndex));
    }

    public void Restart()
    {
        Cursor.visible = false;
        StartCoroutine(SceneTransition(SceneManager.GetActiveScene().buildIndex));
    }

    public void NextLevel()
    {
        Cursor.visible = false;
        StartCoroutine(SceneTransition(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator SceneTransition(int sceneIndex)
    {
        //int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        circleAnimator.SetBool("wipe", true);
        

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(sceneIndex);
        Debug.Log("loaded");
        
    }
}
