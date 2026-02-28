using UnityEngine;
using System.Collections;

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
            takeTurn();

            beatCount = 1;
            Debug.Log(beatCount);
            
        }
        else if (beatCount < 4)
        {
            beatCount += 1;
            Debug.Log(beatCount);
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
            else
            {
                djTurn = true;
                Debug.Log("DJ's turn");
            }
        }
    }
}