using UnityEngine;
using TMPro;

public class health : MonoBehaviour
{
    //public TMP_Text healthText;
    //private int healthCount = 100;

    //public GameObject healthBar;
    private float healthCount;
    private AudioSource recordScratch;
    public followMouse mouseScript;
    public center centerScript;

    //public Conductor_2 conductorScript;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        recordScratch = GetComponent<AudioSource>();
        //healthText.text = healthCount.ToString();
        healthCount = 100f;

    }

    public void TakeDamage()
    {
        if (healthCount > 0)
        {
            healthCount -= 10f;

            Vector3 squishedScale = new Vector3(healthCount / 100f, 1, 1);

            transform.localScale = squishedScale;
            
            recordScratch.Play();
        }
        
        if (healthCount <= 0)
        {
            Conductor_2[] conductorScript = FindObjectsOfType<Conductor_2>();
            foreach (Conductor_2 scriptInstance in conductorScript)
            {
                scriptInstance.StartCoroutine("FadeOut");
            }

            mouseScript.gameOver = true;

            centerScript.StartCoroutine("GameOver");
        }
        //healthCount -= 10;
        //healthText.text = healthCount.ToString();
        

        Debug.Log(healthCount);

        
    }
}
