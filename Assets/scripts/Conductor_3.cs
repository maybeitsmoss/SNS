using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Conductor_3 : MonoBehaviour
{
    //public GameObjet enemyPrefab;
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
    public GameObject blueExclaimPrefab;

    public levelManager levelManagerScript;

    public int barToIgnore;
    public int endBar;
    private bool gameOver = false;

    private int difficulty;
    public List<int> difficultyChange;

    private bool restart;

    void Start()
    {
        Time.timeScale = 1f;
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
            //onBeat();
            if(beatCount >= 4)
            {
                barCount += 1;
                beatCount = 1;

                if (barCount == barOffset)
                {
                    StartCoroutine(Attack1());
                }
            }
            else
            {
                beatCount += 1;
            }
        }
        else
        {
            StartCoroutine(EndLevel());
        }

        Debug.Log("bar: " + barCount);

        

        yield return new WaitForSeconds(crochet * 2);

        StartCoroutine(Metronome());
    }

    IEnumerator Attack1()
    {
        for (int i = 0; i < difficultyChange[0]; i++)
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

        if (SceneManager.GetActiveScene().name == "bbringitbaack")
        {
            yield return new WaitForSecondsRealtime(crochet * 8);
        }
        

        StartCoroutine(Attack2());
    }

    IEnumerator Attack2()
    {
        for (int i = 0; i < difficultyChange[1]; i++)
        {
            List<int> spawnList = new List<int>();
            List<int> enemyList = new List<int>();

            for (int j = 0; j < 5; j++)
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

            yield return new WaitForSecondsRealtime(crochet);

            exclaim(spawnList[3], enemyList[3]);

            yield return new WaitForSecondsRealtime(crochet);

            exclaim(spawnList[4], enemyList[4]);

            yield return new WaitForSecondsRealtime(crochet * 2);

            spawnEnemy(spawnList[0], enemyList[0]);

            yield return new WaitForSecondsRealtime(crochet * 2);

            spawnEnemy(spawnList[1], enemyList[1]);

            yield return new WaitForSecondsRealtime(crochet * 2);

            spawnEnemy(spawnList[2], enemyList[2]);

            yield return new WaitForSecondsRealtime(crochet);

            spawnEnemy(spawnList[3], enemyList[3]);

            yield return new WaitForSecondsRealtime(crochet);

            spawnEnemy(spawnList[4], enemyList[4]);

            yield return new WaitForSecondsRealtime(crochet * 2);
        }
        StartCoroutine(Attack3());
    }

    IEnumerator Attack3()
    {
        for (int i = 0; i < difficultyChange[2]; i++)
        {
            List<int> spawnList = new List<int>();
            List<int> enemyList = new List<int>();

            for (int j = 0; j < 8; j++)
            {
                int randomSpawn = Random.Range(1, 5);
                spawnList.Add(randomSpawn);

                int randomEnemy = Random.Range(1, 5);
                enemyList.Add(randomEnemy);
            }

            exclaim(spawnList[0], enemyList[0]);

            yield return new WaitForSecondsRealtime(crochet);

            exclaim(spawnList[1], enemyList[1]);

            yield return new WaitForSecondsRealtime(crochet);

            exclaim(spawnList[2], enemyList[2]);

            yield return new WaitForSecondsRealtime(crochet);

            exclaim(spawnList[3], enemyList[3]);

            yield return new WaitForSecondsRealtime(crochet);

            exclaim(spawnList[4], enemyList[4]);

            yield return new WaitForSecondsRealtime(crochet);

            exclaim(spawnList[5], enemyList[5]);

            yield return new WaitForSecondsRealtime(crochet);

            exclaim(spawnList[6], enemyList[6]);

            yield return new WaitForSecondsRealtime(crochet);

            exclaim(spawnList[7], enemyList[7]);

            yield return new WaitForSecondsRealtime(crochet);

            spawnEnemy(spawnList[0], enemyList[0]);

            yield return new WaitForSecondsRealtime(crochet);

            spawnEnemy(spawnList[1], enemyList[1]);

            yield return new WaitForSecondsRealtime(crochet);

            spawnEnemy(spawnList[2], enemyList[2]);

            yield return new WaitForSecondsRealtime(crochet);

            spawnEnemy(spawnList[3], enemyList[3]);

            yield return new WaitForSecondsRealtime(crochet);

            spawnEnemy(spawnList[4], enemyList[4]);

            yield return new WaitForSecondsRealtime(crochet);

            spawnEnemy(spawnList[5], enemyList[5]);

            yield return new WaitForSecondsRealtime(crochet);

            spawnEnemy(spawnList[6], enemyList[6]);

            yield return new WaitForSecondsRealtime(crochet);

            spawnEnemy(spawnList[7], enemyList[7]);

            yield return new WaitForSecondsRealtime(crochet);
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

    IEnumerator FadeOut()
    {
        gameOver = true;
        //endBar = barCount - 2;

        float startVolume = music.volume;
        float startTime = Time.timeScale;
        float startPitch = music.pitch;
        float timer = 0f;

        squashStretch[] squashScript = FindObjectsOfType<squashStretch>();
            foreach (squashStretch scriptInstance in squashScript)
            {
                scriptInstance.Stop();
            }

        popUp[] popUpScript = FindObjectsOfType<popUp>();
            foreach (popUp scriptInstance in popUpScript)
            {
                scriptInstance.StartCoroutine("FadeAway");
            }

        while (timer < fadeOutDuration)
        {
            timer += Time.deltaTime;
            music.volume = Mathf.Lerp(startVolume, 0f, timer / fadeOutDuration);
            music.pitch = Mathf.Lerp(startPitch, 0f, timer / fadeOutDuration);
            //Time.timeScale = Mathf.Lerp(startTime, 0f, timer / fadeOutDuration);
            yield return null;
        }
        music.volume = 0f;
        music.pitch = 0f;

        music.Stop();
        

        

        music.volume = startVolume;
        music.pitch = startPitch;

    }
}