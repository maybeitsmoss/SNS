using UnityEngine;
using System.Collections;

public class popUp : MonoBehaviour
{
    public float speed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(doPopUp());    
    }

    // Update is called once per frame
    IEnumerator doPopUp()
    {
        transform.localScale = Vector3.zero;

        while (transform.localScale.x < 3.2f)
        {
            transform.localScale += Vector3.one * Time.deltaTime * speed;
            yield return null;
        }

        transform.localScale = new Vector3(3.2f, 3.2f, 3.2f);

        while (transform.localScale.x > 3f)
        {
            transform.localScale -= Vector3.one * Time.deltaTime * (speed * 0.5f);
            yield return null;
        }

        transform.localScale = new Vector3(3f, 3f, 3f);

        yield return new WaitForSeconds(0.25f);

        transform.localScale = new Vector3(3f, 3f, 3f);

        while (transform.localScale.x < 3.2f)
        {
            transform.localScale += Vector3.one * Time.deltaTime * (speed *0.5f);
            yield return null;
        }

        transform.localScale = new Vector3(3.2f, 3.2f, 3.2f);

        while (transform.localScale.x > 0f)
        {
            transform.localScale -= Vector3.one * Time.deltaTime * speed;
        }

        transform.localScale = Vector3.zero;

        Destroy(gameObject);


    }
}
