using UnityEngine;
using System.Collections;

public class tutPopUp : MonoBehaviour
{
    public float speed = 10f;
    public float timeToWait;
    public float offset;
    //private bool gameOver = false;
    private SpriteRenderer spriteRenderer;
    private tutDiaogue dialogueScript;

    public GameObject ebbNamePlate;
    public GameObject flowNamePlate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueScript = GameObject.Find("tutorialConductor").GetComponent<tutDiaogue>();

        if (GetComponent<SpriteRenderer>() != null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if(gameObject.tag == "speechBubble")
        {
            ebbNamePlate.SetActive(false);
            flowNamePlate.SetActive(false);
        }
        
        StartCoroutine(doPopUp());    
    }

    /*void Update()
    {
        if (gameOver == true)
        {
            Color temp = spriteRenderer.color;
            temp.a = 0f;
            spriteRenderer.color = temp;
        }
    }*/

    void Update()
    {
        if (gameObject.tag == "speechBubble" && transform.position.x > 0f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            ebbNamePlate.SetActive(true);
            flowNamePlate.SetActive(false);

        }
        else if (gameObject.tag == "speechBubble" && transform.position.x < 0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            ebbNamePlate.SetActive(false);
            flowNamePlate.SetActive(true);
        }
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

        yield return new WaitForSeconds(dialogueScript.waitTime);

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

    IEnumerator FadeAway()
    {
        if (gameObject.tag == "portal")
        {
            Color temp = spriteRenderer.color;
            while (temp.a > 0)
            {
                //Color temp = spriteRenderer.color;

                temp.a -= 0.01f;

                spriteRenderer.color = temp;

                yield return null;
            }
        }
    }
}
