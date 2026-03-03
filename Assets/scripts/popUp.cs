using UnityEngine;
using System.Collections;

public class popUp : MonoBehaviour
{
    public float speed = 10f;
    public float timeToWait;
    public float offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(doPopUp());    
    }

    // Update is called once per frame
    IEnumerator doPopUp()
    {

        transform.localScale = Vector3.zero;

        yield return new WaitForSeconds(offset);

        while (transform.localScale.x < 1.2f)
        {
            transform.localScale += Vector3.one * Time.deltaTime * speed;
            yield return null;
        }

        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

        while (transform.localScale.x > 1f)
        {
            transform.localScale -= Vector3.one * Time.deltaTime * (speed * 0.5f);
            yield return null;
        }

        transform.localScale = new Vector3(1f, 1f, 1f);

        yield return new WaitForSeconds(timeToWait);

        transform.localScale = new Vector3(1f, 1f, 1f);

        while (transform.localScale.x < 1.2f)
        {
            transform.localScale += Vector3.one * Time.deltaTime * (speed *0.5f);
            yield return null;
        }

        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

        while (transform.localScale.x > 0f)
        {
            transform.localScale -= Vector3.one * Time.deltaTime * speed;
        }

        transform.localScale = Vector3.zero;

        Destroy(gameObject);


    }
}
