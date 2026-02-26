using UnityEngine;

public class musicController : MonoBehaviour
{
    public float BPM;
    public float crochet;

    public float barCount;
    public float beatCount;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        crochet = (60 / BPM);
        Debug.Log(crochet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
