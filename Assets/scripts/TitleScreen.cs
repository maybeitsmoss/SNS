using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("tutorial");
    }    

}
