using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class snipSFX : MonoBehaviour
{

    private AudioSource audioClip;

    void Start()
    {
        audioClip = GetComponent<AudioSource>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            audioClip.Play();
            Debug.Log("snip");
        }
    }
}
