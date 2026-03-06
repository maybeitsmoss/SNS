using UnityEngine;
using TMPro;
using System.Collections;

public class health : MonoBehaviour
{
    //public TMP_Text healthText;
    //private int healthCount = 100;

    //public GameObject healthBar;
    private float healthCount;
    private AudioSource recordScratch;
    public followMouse mouseScript;
    public center centerScript;
    public GameObject cussPrefabL;
    public GameObject cussPrefabR;
    private bool cussToggle = false;

    public GameObject boothPrefab;
    private Animator boothAnim;
    public GameObject backGround;
    private Animator bgAnim;

    private bool gameOver = false;

    //public Conductor_2 conductorScript;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bgAnim = backGround.GetComponent<Animator>();
        boothAnim = boothPrefab.GetComponent<Animator>();
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

            if (cussToggle == true)
            {
                Vector3 spawn = new Vector3(-15f, 28f, 0f);
                Instantiate(cussPrefabL, spawn, Quaternion.identity);
                cussToggle = false;
            }
            else if (cussToggle == false)
            {
                Vector3 spawn = new Vector3(16f, 28f, 0f);
                Instantiate(cussPrefabR, spawn, Quaternion.identity);
                cussToggle = true;
            }
            
            recordScratch.Play();
        }
        
        if (healthCount <= 0)
        {
            if (gameOver == false)
            {
                Conductor_2[] conductorScript = FindObjectsOfType<Conductor_2>();
                foreach (Conductor_2 scriptInstance in conductorScript)
                {
                    scriptInstance.StartCoroutine("FadeOut");
                }

                mouseScript.gameOver = true;

                centerScript.StartCoroutine("GameOver");

                boothAnim.Play("slideUp");

                //bgAnim.Play("gameOver");

                StartCoroutine(GameOver());

                gameOver = true;
            }
        }
        //healthCount -= 10;
        //healthText.text = healthCount.ToString();
        Debug.Log(healthCount);
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1f);

        int random = Random.Range(0, 2);
                
        if (random == 0)
        {
            bgAnim.Play("ebb");
        }
        else
        {
            bgAnim.Play("flow");
        }

    }
}
