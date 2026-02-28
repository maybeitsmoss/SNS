using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class conductor : MonoBehaviour
{
    /*public float BPM;
    public float crochet;
    public float beatCount;
    public float songPosition;
    public int barCount;
    public int beatsPerBar = 4;
    public float nextBeatTime;

    float lastBeat;
    private int difficulty;

    public AudioSource music;
    private float dspSongTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        music = GetComponent<AudioSource>();
        //crochet = seconds between beats
        crochet = 60f / BPM;
        //records time when music starts
        dspSongTime = (float)AudioSettings.dspTime;

        music.Play();
        nextBeatTime = dspSongTime + crochet;

        //songPosition = correspoinding variable on audio component
        //songPosition = (float)(AudioSettings.dspTIme - dsptimesong) * song.pitch - offset
        //BPM = bpm

    }

    // Update is called once per frame
    void Update()
    {
        //how many seconds have passed since song start
        //songPosition = (float)(AudioSettings.dspTime - dspSongTime);
        //determine current beat
        //beatCount = songPosition / crochet;
        //determine current bar
        //barCount = Mathf.FloorToInt(beatCount / beatsPerBar) + 1;


        songPosition = (float)(AudioSettings.dspTime - dspSongTime);
        beatCount = songPosition / crochet;

        while(beatCount > nextBeatTime)
        {
            onBeat();
            nextBeatTime = dspSongTime + crochet;
        }

        //Debug.Log(beatCount);
        
    }

    void onBeat()
    {
        Debug.Log("Beat");
    }*/

    public AudioSource audioSource;
    public float BPM;

    private int lastBeatSample = 0;
    private int samplesPerBeat;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        samplesPerBeat = (int)((60f / BPM) * audioSource.clip.frequency);
        audioSource.Play();
    }

    void Update()
    {
        int currentSample = audioSource.timeSamples;

        if(currentSample >= lastBeatSample + samplesPerBeat)
        {
            while(currentSample >= lastBeatSample + samplesPerBeat)
            {
                lastBeatSample += samplesPerBeat;
                onBeat();
            }
        }

        if(currentSample < lastBeatSample)
        {
            lastBeatSample = 0;
        }
    }

    void onBeat()
    {
        Debug.Log("Beat");
    }




}
