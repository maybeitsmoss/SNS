using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Conductor_2 : MonoBehaviour
{
    //public GameObjet enemyPrefab;
    public float BPM;
    private float crochet;
    private int beatCount;
    private float beatDuration;
    private int barCount;

    public int barOffset;
    public int beatOffset;
    public float offset = 0.2f;

    private AudioSource music;

    public bool djTurn;

    public GameObject leftTop;
    public GameObject leftBottom;
    public GameObject rightTop;
    public GameObject rightBottom;
    public GameObject enemyPrefab;
    public GameObject footEnemyPrefab;
    public GameObject exclaimPrefab;

    public int barToIgnore;
    public int endBar;

    private int difficulty;
    public List<int> difficultyChange;

    void Start()
    {
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
        yield return new WaitForSeconds(offset);

        music.Play();
        StartCoroutine(Metronome());
    }

    IEnumerator Metronome()
    {
        if(barCount < endBar)
        {
            onBeat();
        }
        

        yield return new WaitForSeconds(crochet * 2);

        //beatDuration = 1 / crochet;

        StartCoroutine(Metronome());

    }

    void onBeat()
    {
        if (beatCount >= 4)
        {
            barCount += 1;
            Debug.Log("New Bar: " + barCount);
            if (barCount != barToIgnore)
            {
                takeTurn();
            }
            else
            {
                barCount += 1;
            }
            

            beatCount = 1;
            //Debug.Log(beatCount);
            
        }
        else if (beatCount < 4)
        {
            beatCount += 1;
            //Debug.Log(beatCount);
        }
    }

    void takeTurn()
    {
        if(barCount >= barOffset)
        {
            if(barCount % 2 == 0)
            {
                if(barCount == difficultyChange[0])
                {
                    difficulty += 1;
                }
                else if (barCount == difficultyChange[1])
                {
                    difficulty += 1;
                }
                djTurn = false;
                Debug.Log("Player's turn");
            }
            else if (barCount % 2 != 0)
            {
                if(barCount == difficultyChange[0])
                {
                    difficulty += 1;
                }
                else if (barCount == difficultyChange[1])
                {
                    difficulty += 1;
                }

                djTurn = true;
                Debug.Log("DJ's turn");

                if (difficulty == 0)
                {
                    StartCoroutine(Attack());
                }
                else if (difficulty == 1)
                {
                    StartCoroutine(GroovyAttack1());
                }
                else if (difficulty == 2)
                {
                    StartCoroutine(FastAttack());
                }
                
            }
        }
    }

    IEnumerator Attack()
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

    IEnumerator GroovyAttack1()
    {
        List <int> spawnList = new List<int>();

        for (int i = 0; i < 5; i++)
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

        yield return new WaitForSeconds(crochet);

        Debug.Log(spawnList[3]);
        makePopup(spawnList[3]);

        yield return new WaitForSeconds(crochet);

        Debug.Log(spawnList[4]);
        makePopup(spawnList[4]);

        StartCoroutine(GroovySpawnEnemies(spawnList));

    }

     IEnumerator GroovySpawnEnemies(List<int> spawnHistory)
    {
        //yield return new WaitForSeconds(crochet);

        List<GameObject> spawnPoints = new List<GameObject>();
        for (int i = 0; i < spawnHistory.Count; i++)
        {
            if (spawnHistory[i] == 1)
            {
                int randomNum = Random.Range(1, 5);
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
                int randomNum = Random.Range(1, 5);
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
                int randomNum = Random.Range(1, 5);
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
                int randomNum = Random.Range(1, 5);
                if(randomNum == 4)
                {
                    Instantiate(footEnemyPrefab, rightBottom.transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(enemyPrefab, rightBottom.transform.position, Quaternion.identity);
                }
            }
            
            if (i < 2)
            {
                yield return new WaitForSeconds(crochet * 2);
            }
            else
            {
                yield return new WaitForSeconds(crochet);
            }
            
        }

    }

    IEnumerator FastAttack()
    {
        List<int> spawnList = new List<int>();

        for (int i = 0; i < 8; i++)
        {
            int randomSpawn = Random.Range(1, 5);
            spawnList.Add(randomSpawn);
        }

        Debug.Log(spawnList[0]);
        makePopup(spawnList[0]);

        yield return new WaitForSeconds(crochet);

        Debug.Log(spawnList[1]);
        makePopup(spawnList[1]);

        yield return new WaitForSeconds(crochet);

        Debug.Log(spawnList[2]);
        makePopup(spawnList[2]);

        yield return new WaitForSeconds(crochet);

        Debug.Log(spawnList[3]);
        makePopup(spawnList[3]);

        yield return new WaitForSeconds(crochet);

        Debug.Log(spawnList[4]);
        makePopup(spawnList[4]);

        yield return new WaitForSeconds(crochet);

        Debug.Log(spawnList[5]);
        makePopup(spawnList[5]);

        yield return new WaitForSeconds(crochet);

        Debug.Log(spawnList[6]);
        makePopup(spawnList[6]);

        yield return new WaitForSeconds(crochet);

        Debug.Log(spawnList[7]);
        makePopup(spawnList[7]);

        StartCoroutine(SpawnEnemies(spawnList));
    }

    IEnumerator SpawnEnemies(List<int> spawnHistory)
    {
        //yield return new WaitForSeconds(crochet);

        List<GameObject> spawnPoints = new List<GameObject>();
        for (int i = 0; i < spawnHistory.Count; i++)
        {
            if (spawnHistory[i] == 1)
            {
                int randomNum = Random.Range(1, 5);
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
                int randomNum = Random.Range(1, 5);
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
                int randomNum = Random.Range(1, 5);
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
                int randomNum = Random.Range(1, 5);
                if(randomNum == 4)
                {
                    Instantiate(footEnemyPrefab, rightBottom.transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(enemyPrefab, rightBottom.transform.position, Quaternion.identity);
                }
            }
            
            if(difficulty == 0 || difficulty == 1)
            {
                yield return new WaitForSeconds(crochet * 2);
            }
            else if (difficulty == 2)
            {
                yield return new WaitForSeconds(crochet);
            }
            
        }
    }
}