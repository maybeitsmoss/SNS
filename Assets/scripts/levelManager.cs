using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public static class levelManager
{
    public static void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public static void Restart()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void NextLevel()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void SceneTransition(int sceneIndex)
    {
        Debug.Log("animaiton insert here");

        if (SceneManager.GetActiveScene().buildIndex < 5)
        {
            LoadScene(sceneIndex);
        }
        
    }
}
