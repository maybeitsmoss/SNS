using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class levelManager : MonoBehaviour
{
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Restart()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SceneTransition(int sceneIndex)
    {
        Debug.Log("animaiton insert here");

        if (SceneManager.GetActiveScene().buildIndex < 5)
        {
            LoadScene(sceneIndex);
        }
        
    }
}
