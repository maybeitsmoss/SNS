using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TutorialConductor : MonoBehaviour
{

    public float BPM;
    public float crochet;
    private int beatCount;
    private float beatDuration;
    private int barCount;

    public int barOffset;
    public int beatOffset;
    public float offset = 0.2f;

    private AudioSource music;
    public float fadeOutDuration;

    public bool djTurn;

    public GameObject leftTop;
    public GameObject leftBottom;
    public GameObject rightTop;
    public GameObject rightBottom;
    public GameObject enemyPrefab;
    public GameObject footEnemyPrefab;
    public GameObject exclaimPrefab;

    public levelManager levelManagerScript;

    public int barToIgnore;
    public int endBar;
    private bool gameOver = false;

    private int difficulty;
    public List<int> difficultyChange;

    private bool restart;


    public List<int> barsToPlay;

    public GameObject boothPrefab;
    private Animator boothAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boothPrefab.SetActive(false);
        music = GetComponent<AudioSource>();
        beatCount = beatOffset;
        barCount = 1;
        crochet = 60f / BPM;
        beatDuration = crochet;
        difficulty = 0;
        //music.Play();
        StartCoroutine(startMetronome());
    }

    IEnumerator startMetronome()
    {
        //bool restart;

        yield return new WaitForSeconds(offset);

        music.Play();
        StartCoroutine(Metronome());
        Debug.Log("started metronome");

        if (restart == false)
        {
            squashStretch[] squashScript = FindObjectsOfType<squashStretch>();
            foreach (squashStretch scriptInstance in squashScript)
            {
                scriptInstance.StartCoroutine("SquishCoroutine");
            }

            restart = true;
        }
    }

    IEnumerator Metronome()
    {
        if(barCount < endBar)
        {
            onBeat();
        }
        else
        {
            StartCoroutine(EndLevel());
        }


        yield return new WaitForSeconds(crochet * 2);

        StartCoroutine(Metronome());

    }

    IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(crochet * 24);

        if (gameOver == false)
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            levelManagerScript.NextLevel();
            //levelManagerScript.StartCoroutine("SceneTransition");
        }
        
    }

    void onBeat()
    {
        if (beatCount >= 4)
        {
            barCount += 1;
            takeTurn();
            beatCount = 1;
            Debug.Log("New Bar: " + barCount);
            
        }
        else if (beatCount < 4)
        {
            beatCount += 1;
            Debug.Log(beatCount);
        }
    }

    void takeTurn()
    {
        if (barsToPlay.Contains(barCount))
        {
            if(difficulty == 0)
            {
                StartCoroutine(Attack());
                difficulty += 1;
            }
            else if(difficulty == 1)
            {
                StartCoroutine(GroovyAttack1());
                difficulty += 1;
            }
            else if(difficulty == 2)
            {
                StartCoroutine(FastAttack());
            }
        }
    }

    IEnumerator Attack()
    {
        //boothPrefab.SetActive(true);
        //boothAnimator.Play("slideDown");
        

        Instantiate(exclaimPrefab, leftTop.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(crochet * 2);

        //boothAnimator.Play("idle");

        Instantiate(enemyPrefab, leftTop.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(crochet * 2);

        Instantiate(exclaimPrefab, rightTop.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(crochet * 2);

        Instantiate(enemyPrefab, rightTop.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(crochet * 2);

        Instantiate(exclaimPrefab, leftBottom.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(crochet * 2);

        Instantiate(enemyPrefab, leftBottom.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(crochet * 2);

        Instantiate(exclaimPrefab, rightBottom.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(crochet * 2);

        Instantiate(enemyPrefab, rightBottom.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(crochet * 2);
        //boothAnimator.Play("slideUp");
        
    }

    IEnumerator GroovyAttack1()
    {
        Instantiate(exclaimPrefab, leftTop.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(crochet * 2);

        Instantiate(footEnemyPrefab, leftTop.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(crochet * 2);

        Instantiate(exclaimPrefab, rightTop.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(crochet * 2);

        Instantiate(enemyPrefab, rightTop.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(crochet * 2);

        Instantiate(exclaimPrefab, leftBottom.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(crochet * 2);

        Instantiate(footEnemyPrefab, leftBottom.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(crochet * 2);

        Instantiate(exclaimPrefab, rightBottom.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(crochet * 2);

        Instantiate(enemyPrefab, rightBottom.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(crochet * 2);
    }

    IEnumerator FastAttack()
    {
        List<int> spawnList = new List<int>();

        for (int i = 0; i < 4; i++)
        {
            int randomSpawn = Random.Range(1, 5);
            spawnList.Add(randomSpawn);
        }

        Debug.Log(spawnList[0]);
        makePopup(spawnList[0]);

        yield return new WaitForSeconds(crochet * 2);

        Debug.Log(spawnList[1]);
        makePopup(spawnList[1]);

        yield return new WaitForSeconds(crochet * 2);

        Debug.Log(spawnList[2]);
        makePopup(spawnList[2]);

        yield return new WaitForSeconds(crochet * 2);

        Debug.Log(spawnList[3]);
        makePopup(spawnList[3]);

        StartCoroutine(SpawnEnemies(spawnList));

        yield return new WaitForSeconds(crochet * 10);

        if (barCount < endBar)
        {
            StartCoroutine("FastAttack");
        }
        
    }

    void makePopup(int location)
    {
        if (location == 1)
        {
            Instantiate(exclaimPrefab, leftTop.transform.position, Quaternion.identity);
        }
        else if (location == 2)
        {
            Instantiate(exclaimPrefab, leftBottom.transform.position, Quaternion.identity);
        }
        else if (location == 3)
        {
            Instantiate(exclaimPrefab, rightTop.transform.position, Quaternion.identity);
        }
        else if (location == 4)
        {
            Instantiate(exclaimPrefab, rightBottom.transform.position, Quaternion.identity);
        }
    }

     IEnumerator SpawnEnemies(List<int> spawnHistory)
    {
        //yield return new WaitForSeconds(crochet);

        List<GameObject> spawnPoints = new List<GameObject>();
        for (int i = 0; i < spawnHistory.Count; i++)
        {
            if (spawnHistory[i] == 1)
            {
                int randomNum = Random.Range(1, 6);
                if(randomNum == 4)
                {
                    Instantiate(footEnemyPrefab, leftTop.transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(enemyPrefab, leftTop.transform.position, Quaternion.identity);
                }
            }
            else if (spawnHistory[i] == 2)
            {
                int randomNum = Random.Range(1, 6);
                if(randomNum == 4)
                {
                    Instantiate(footEnemyPrefab, leftBottom.transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(enemyPrefab, leftBottom.transform.position, Quaternion.identity);
                }
            }
            else if (spawnHistory[i] == 3)
            {
                int randomNum = Random.Range(1, 6);
                if(randomNum == 4)
                {
                    Instantiate(footEnemyPrefab, rightTop.transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(enemyPrefab, rightTop.transform.position, Quaternion.identity);
                }
            }
            else if (spawnHistory[i] == 4)
            {
                int randomNum = Random.Range(1, 6);
                if(randomNum == 4)
                {
                    Instantiate(footEnemyPrefab, rightBottom.transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(enemyPrefab, rightBottom.transform.position, Quaternion.identity);
                }
            }
            
            
            yield return new WaitForSeconds(crochet * 2);
            
            
        }
    }
   
}
