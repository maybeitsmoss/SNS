using UnityEngine;

public class Conductor : MonoBehaviour
{

    public float offset;
    public float BPM;
    public float beatInterval;
    public float nextBeatTime;
    public float crochet;
    private int beatCount;

    private AudioSource music;


    void Awake()
    {
        music = GetComponent<AudioSource>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //turn bpm into bps
        crochet = BPM / 60f;
        beatCount = 0;
        nextBeatTime = (float)AudioSettings.dspTime;
        music.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(AudioSettings.dspTime >= nextBeatTime)
        {
            if(beatCount >= 4)
            {
                beatCount = 1;
                Debug.Log(beatCount);
            }
            else if(beatCount < 4)
            {
                beatCount += 1;
                Debug.Log(beatCount);
            }

            nextBeatTime += crochet;
        }

    }
}
