using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class tutDiaogue : MonoBehaviour
{
    public float BPM;
    private float crochet;
    public float offset;
    public float waitTime;
    public GameObject ebbPrefab;
    public GameObject flowPrefab;
    public GameObject bubblePrefab;
    public TextMeshProUGUI ebbText;
    public TextMeshProUGUI flowText;
    public float typingSpeed;

    public GameObject leftTop;
    public GameObject leftBottom;
    public GameObject rightTop;
    public GameObject rightBottom;

    //public GameObject playerBubble;
    public GameObject exclaimPrefab;
    public GameObject blueExclaimPrefab;
    public GameObject enemyPrefab;
    public GameObject footEnemyPrefab;
    public GameObject boothPrefab;

    public levelManager levelManagerScript;

    private AudioSource music;

    private bool gameOver = false;

    public Animator cardboardRecordAnim;
    public Animator realRecordAnim;
    public Animator signAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        crochet = 60f / BPM;
        //playerBubble.GetComponent<SpriteRenderer>().enabled = false;
        boothPrefab.SetActive(false);
        music = GetComponent<AudioSource>();
        music.Play();
        StartCoroutine(StartDialogue(offset));
        //beatCount = beatOffset;
        //barCount = 1;
        //crochet = 60f / BPM;
        //beatDuration = crochet;
        //difficulty = 0;
        //music.Play();
    }

    public void InstantiateEbb()
    {
        Vector3 pos = new Vector3(-44f, 17.5f, 0f);
        Instantiate(ebbPrefab, pos, Quaternion.identity);
    }

    public void InstantiateFlow()
    {
        Vector3 pos = new Vector3(45.9f, 18.5f, 0f);
        Instantiate(flowPrefab, pos, Quaternion.identity);
    }

    IEnumerator StartDialogue(float offset)
    {
        Vector3 flowPos = new Vector3(-15.4f, 18.8f, 0f);
        Vector3 ebbPos = new Vector3(15.4f, 18.8f, 0f);

        yield return new WaitForSeconds(offset);

        StartCoroutine(TypeDialogue("TESTIN’, TESTIN’! Mic check, one, TWO!", 1));
        waitTime = 3.35f;

        Instantiate(bubblePrefab, ebbPos, Quaternion.identity);
        InstantiateEbb();

        yield return new WaitForSeconds(3.35f);
        
        StartCoroutine(TypeDialogue("Yo, you hear us good down there, right? Actually, why am I asking that like we not gods?- We could be in SURROUND SOUND if we wanted to be!", 0));
        waitTime = 8.05f;

        Instantiate(bubblePrefab, flowPos, Quaternion.identity);
        InstantiateFlow();

        yield return new WaitForSeconds(8.05f);
        
        StartCoroutine(TypeDialogue("Flow, we’ve been trapped in a turn table for the past 48 HOURS cause some tone-deaf dummy tried to take the soul stereo, and we wouldn’t let em’!", 1));
        waitTime = 7.48f;

        Instantiate(bubblePrefab, ebbPos, Quaternion.identity);
        InstantiateEbb();

        yield return new WaitForSeconds(7.48f);

        StartCoroutine(TypeDialogue("Well when ya put it like that it makes us sound incompetent…", 0));
        waitTime = 3.23f;

        Instantiate(bubblePrefab, flowPos, Quaternion.identity);
        InstantiateFlow();

        yield return new WaitForSeconds(3.23f);

        StartCoroutine(TypeDialogue("…Well, since we're not keepin’ secrets, ya dooo have a habit of-", 1));
        waitTime = 3.60f;

        Instantiate(bubblePrefab, ebbPos, Quaternion.identity);
        InstantiateEbb();

        yield return new WaitForSeconds(3.60f);

        StartCoroutine(TypeDialogue("I said us, don’t you put that smut on just me! Besides, we out now ain’t we not?", 0));
        waitTime = 4.91f;

        Instantiate(bubblePrefab, flowPos, Quaternion.identity);
        InstantiateFlow();

        yield return new WaitForSeconds(4.91f);

        StartCoroutine(TypeDialogue("Yeah yeah, whatever. Anyways, you down there! Whatcha said your name was again? ", 1));
        waitTime = 5.16f;

        Instantiate(bubblePrefab, ebbPos, Quaternion.identity);
        InstantiateEbb();

        yield return new WaitForSeconds(5.16f);

        ebbText.text = "";
        flowText.text = "";
        Debug.Log("...");
        waitTime = 3.63f;
        //playerBubble.GetComponent<SpriteRenderer>().enabled = true;
       

        yield return new WaitForSeconds(3.63f);

        //playerBubble.GetComponent<SpriteRenderer>().enabled = false;

        StartCoroutine(TypeDialogue("Not one for talkin’ much, eh? Well, it ain’t our problem! We just gon’ call you...cutter!", 0));
        waitTime = 6.36f;

        Instantiate(bubblePrefab, flowPos, Quaternion.identity);
        InstantiateFlow();

        yield return new WaitForSeconds(6.36f);

        StartCoroutine(TypeDialogue("And, cutter, since ya picked up the sword and stuff, you’re pretty much responsible for your world not collapsin’ now!", 1));
        waitTime = 10.40f;

        Instantiate(bubblePrefab, ebbPos, Quaternion.identity);
        InstantiateEbb();

        yield return new WaitForSeconds(6.58f);

        StartCoroutine(TypeDialogue("There's some pretty messed up dudes out there who really want that Soul Stereo...", 1));
        
        yield return new WaitForSeconds(3.82f);

        StartCoroutine(TypeDialogue("OH! See that spinning thing in the center of the room behind ya? Yeah, that big record?", 0));
        waitTime = 10.61f;

        Instantiate(bubblePrefab, flowPos, Quaternion.identity);
        InstantiateFlow();

        yield return new WaitForSeconds(4.71f);

        StartCoroutine(TypeDialogue("That's the SOUL STEREO, the very essence of your universe making your tiny little paper world go round!", 0));

        yield return new WaitForSeconds(5.90f);

        StartCoroutine(TypeDialogue("Without it, you’d all up and die!... But I don’t remember it lookin’ so...", 1));
        waitTime = 7.61f;

        Instantiate(bubblePrefab, ebbPos, Quaternion.identity);
        InstantiateEbb();

        yield return new WaitForSeconds(5.63f);

        StartCoroutine(TypeDialogue("...dingey.", 1));

        yield return new WaitForSeconds(1.98f);

        StartCoroutine(TypeDialogue("Well SHER-ROCK HOLMES, thats cause it ain’t the real thing.", 0));
        waitTime = 7.26f;

        Instantiate(bubblePrefab, flowPos, Quaternion.identity);
        InstantiateFlow();

        yield return new WaitForSeconds(3.05f);

        StartCoroutine(TypeDialogue("We gotta make sure our new found scissor-slinger knows what they doin’ before we put the world in they hands!", 0));

        yield return new WaitForSeconds(4.21f);

        StartCoroutine(TypeDialogue("Right, right. I guess we don’t got a choice either with little Miss Discordance threatinin’ to show her face again...", 1));
        waitTime = 9.95f;

        Instantiate(bubblePrefab, ebbPos, Quaternion.identity);
        InstantiateEbb();

        yield return new WaitForSeconds(6.46f);

        StartCoroutine(TypeDialogue("You think shes still usin’ portals to send her fiends our way?", 1));

        yield return new WaitForSeconds(3.49f);

        StartCoroutine(TypeDialogue("Like always. But since we know that it gives us an upper hand!", 0));
        waitTime = 9.45f;

        Instantiate(bubblePrefab, flowPos, Quaternion.identity);
        InstantiateFlow();

        yield return new WaitForSeconds(3.70f);

        StartCoroutine(TypeDialogue("Cutter, enemies is gon start appearing out them make shift holes. Fling yourself around and chop em’ up on beat!", 0));

        yield return new WaitForSeconds(5.75f);

        ebbText.text = "";
        flowText.text = "";
        Debug.Log("...");
        waitTime = 6.46f;

        yield return new WaitForSeconds (0.2f);

        //ATTACK 1
        Instantiate(exclaimPrefab, leftTop.transform.position, Quaternion.identity);

        yield return new WaitForSeconds (0.77f);

        Instantiate(enemyPrefab, leftTop.transform.position, Quaternion.identity);

        yield return new WaitForSeconds (0.77f);

        Instantiate(exclaimPrefab, rightTop.transform.position, Quaternion.identity);

        yield return new WaitForSeconds (0.77f);

        Instantiate(enemyPrefab, rightTop.transform.position, Quaternion.identity);

        yield return new WaitForSeconds (0.77f);

        Instantiate(exclaimPrefab, leftBottom.transform.position, Quaternion.identity);

        yield return new WaitForSeconds (0.77f);

        Instantiate(enemyPrefab, leftBottom.transform.position, Quaternion.identity);

        yield return new WaitForSeconds (0.77f);

        Instantiate(exclaimPrefab, rightBottom.transform.position, Quaternion.identity);

        yield return new WaitForSeconds (0.77f);

        Instantiate(enemyPrefab, rightBottom.transform.position, Quaternion.identity);

        yield return new WaitForSeconds (0.77f);


        ///RESUME DIALOGUE
        yield return new WaitForSeconds(0.07f);
        
        StartCoroutine(TypeDialogue("Oh yeah we cookin’ like hot grease now! Them foes ain’t always gonna come up in the same slow patterns though...", 0));
        waitTime = 5.64f;

        Instantiate(bubblePrefab, flowPos, Quaternion.identity);
        InstantiateFlow();

        yield return new WaitForSeconds(5.64f);

        StartCoroutine(TypeDialogue("Nor are they gonna be able to go down with just that sword! Them teal ones you’re gonna have to KICK!", 1));
        waitTime = 5.42f;

        Instantiate(bubblePrefab, ebbPos, Quaternion.identity);
        InstantiateEbb();

        yield return new WaitForSeconds(5.42f);

        ebbText.text = "";
        flowText.text = "";
        Debug.Log("...");
        waitTime = 7.46f;

        yield return new WaitForSeconds(.75f);

        //ATTACK 2
        Instantiate(blueExclaimPrefab, leftTop.transform.position, Quaternion.identity);

        yield return new WaitForSeconds (0.77f);

        Instantiate(footEnemyPrefab, leftTop.transform.position, Quaternion.identity);

        yield return new WaitForSeconds (0.77f);

        Instantiate(exclaimPrefab, rightTop.transform.position, Quaternion.identity);

        yield return new WaitForSeconds (0.77f);

        Instantiate(enemyPrefab, rightTop.transform.position, Quaternion.identity);

        yield return new WaitForSeconds (0.77f);

        Instantiate(blueExclaimPrefab, leftBottom.transform.position, Quaternion.identity);

        yield return new WaitForSeconds (0.77f);

        Instantiate(footEnemyPrefab, leftBottom.transform.position, Quaternion.identity);

        yield return new WaitForSeconds (0.77f);

        Instantiate(exclaimPrefab, rightBottom.transform.position, Quaternion.identity);

        yield return new WaitForSeconds (0.77f);

        Instantiate(enemyPrefab, rightBottom.transform.position, Quaternion.identity);

        yield return new WaitForSeconds (0.77f);


        //resume dialogue
        yield return new WaitForSeconds(.55f);
        
        StartCoroutine(TypeDialogue("Ya know what, I was havin’ my doubts but this kids’ pretty good! Let's pick up the pace a bit…", 1));
        waitTime = 5.05f;

        Instantiate(bubblePrefab, ebbPos, Quaternion.identity);
        InstantiateEbb();

        yield return new WaitForSeconds(5.05f);

        StartCoroutine(TypeDialogue("We’ll give you a warning or two, since we can get a good sense of when the big bads gon start coming in...", 0));
        waitTime = 6.76f;

        Instantiate(bubblePrefab, flowPos, Quaternion.identity);
        InstantiateFlow();

        yield return new WaitForSeconds(4.21f);

        StartCoroutine(TypeDialogue("...but we ain’t gon say much this time around!", 0));

        yield return new WaitForSeconds(2.55f);

        ebbText.text = "";
        flowText.text = "";
        Debug.Log("...");

        for (int i = 0; i < 4; i++)
        {
            List<int> spawnList = new List<int>();
            List<int> enemyList = new List<int>();

            for (int j = 0; j < 4; j++)
            {
                int randomSpawn = Random.Range(1, 5);
                spawnList.Add(randomSpawn);

                int randomEnemy = Random.Range(1, 5);
                enemyList.Add(randomEnemy);
            }

            exclaim(spawnList[0], enemyList[0]);

            yield return new WaitForSecondsRealtime(crochet * 2);

            exclaim(spawnList[1], enemyList[1]);

            yield return new WaitForSecondsRealtime(crochet * 2);

            exclaim(spawnList[2], enemyList[2]);

            yield return new WaitForSecondsRealtime(crochet * 2);

            exclaim(spawnList[3], enemyList[3]);

            yield return new WaitForSecondsRealtime(crochet * 2);

            spawnEnemy(spawnList[0], enemyList[0]);

            yield return new WaitForSecondsRealtime(crochet * 2);

            spawnEnemy(spawnList[1], enemyList[1]);

            yield return new WaitForSecondsRealtime(crochet * 2);

            spawnEnemy(spawnList[2], enemyList[2]);

            yield return new WaitForSecondsRealtime(crochet * 2);

            spawnEnemy(spawnList[3], enemyList[3]);

            yield return new WaitForSecondsRealtime(crochet * 2);
        }

        yield return new WaitForSeconds(crochet* 8);

        cardboardRecordAnim.SetBool("reveal", true);
        realRecordAnim.SetBool("reveal", true);
        signAnim.SetBool("reveal", true);

        yield return new WaitForSeconds(crochet * 4);

        StartCoroutine(EndLevel());

    }

    void exclaim(int location, int enemyType)
    {
        switch (location)
        {
            case 1:
                if(enemyType == 1)
                {
                    Instantiate(blueExclaimPrefab, leftTop.transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(exclaimPrefab, leftTop.transform.position, Quaternion.identity);
                }
                break;
            case 2:
                if(enemyType == 1)
                {
                    Instantiate(blueExclaimPrefab, rightTop.transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(exclaimPrefab, rightTop.transform.position, Quaternion.identity);
                }
                break;
            case 3:
                if(enemyType == 1)
                {
                    Instantiate(blueExclaimPrefab, leftBottom.transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(exclaimPrefab, leftBottom.transform.position, Quaternion.identity);
                }
                break;
            case 4:
                if(enemyType == 1)
                {
                    Instantiate(blueExclaimPrefab, rightBottom.transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(exclaimPrefab, rightBottom.transform.position, Quaternion.identity);
                }
                break;
        }
    }

    void spawnEnemy(int location, int enemyType)
    {
        switch (location)
        {
            case 1:
                if(enemyType == 1)
                {
                    Instantiate(footEnemyPrefab, leftTop.transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(enemyPrefab, leftTop.transform.position, Quaternion.identity);
                }
                break;
            case 2:
                if(enemyType == 1)
                {
                    Instantiate(footEnemyPrefab, rightTop.transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(enemyPrefab, rightTop.transform.position, Quaternion.identity);
                }
                break;
            case 3:
                if(enemyType == 1)
                {
                    Instantiate(footEnemyPrefab, leftBottom.transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(enemyPrefab, leftBottom.transform.position, Quaternion.identity);
                }
                break;
            case 4:
                if(enemyType == 1)
                {
                    Instantiate(footEnemyPrefab, rightBottom.transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(enemyPrefab, rightBottom.transform.position, Quaternion.identity);
                }
                break;
        }
    }

    IEnumerator TypeDialogue(string quote, int toggle)
    {
        if(toggle == 1)
        {
            ebbText.maxVisibleCharacters = 0;
            ebbText.text = quote;
            flowText.text = "";
        }
        else if(toggle == 0)
        {
            flowText.maxVisibleCharacters = 0;
            flowText.text = quote;
            ebbText.text = "";
        }

        int characterCount = quote.Length;

        if(toggle == 1)
        {
            for (int i = 0; i <= characterCount; i++)
            {
                ebbText.maxVisibleCharacters = i;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
        else if(toggle == 0)
        {
            for (int i = 0; i <= characterCount; i++)
            {
                flowText.maxVisibleCharacters = i;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
    }

    IEnumerator EndLevel()
    {
        yield return new WaitForSecondsRealtime(crochet * 16);

        if (gameOver == false)
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            attemptTracker.Reset();
            levelManagerScript.NextLevel();
            
            //levelManagerScript.StartCoroutine("SceneTransition");
        }
        
    }


}
