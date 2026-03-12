using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TitleMusic : MonoBehaviour
{   
    //public AudioSource intro;
    public AudioSource loop;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //loop.Play();
        loop.volume = 1f;
    }

    IEnumerator StopMusic()
    {
        if (loop.isPlaying)
        {
            //Debug.Log("stopping music");

            float volume = loop.volume;

            while (volume > 0f)
            {
                volume -= 0.02f;
                loop.volume = volume;
                yield return null;
            }
        }
        
    }
    
}
