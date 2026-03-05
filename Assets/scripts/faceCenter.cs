using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class faceCenter : MonoBehaviour
{
    public float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(timer);

        Destroy(gameObject);
    }
}
