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

    public int barToIgnore;
    private bool pause;

    void Start()
    {
        music = GetComponent<AudioSource>();
        beatCount = beatOffset;
        barCount = 1;
        crochet = 60f / BPM;
        beatDuration = crochet;
        music.Play();
        StartCoroutine(startMetronome());
    }

    IEnumerator startMetronome()
    {
        yield return new WaitForSeconds(offset);

        StartCoroutine(Metronome());
    }

    IEnumerator Metronome()
    {
        onBeat();

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
                djTurn = false;
                Debug.Log("Player's turn");
            }
            else if (barCount % 2 != 0)
            {
                djTurn = true;
                Debug.Log("DJ's turn");
                StartCoroutine(Attack());
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

        yield return new WaitForSeconds(crochet * 2);

        Debug.Log(spawnList[1]);

        yield return new WaitForSeconds(crochet * 2);

        Debug.Log(spawnList[2]);

        yield return new WaitForSeconds(crochet * 2);

        Debug.Log(spawnList[3]);

        StartCoroutine(SpawnEnemies(spawnList));
    }

    IEnumerator SpawnEnemies(List<int> spawnHistory)
    {
        //yield return new WaitForSeconds(crochet);

        List<GameObject> spawnPoints = new List<GameObject>();
        for (int i = 0; i < 4; i++)
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

            yield return new WaitForSeconds(crochet * 2);
        }
    }
}