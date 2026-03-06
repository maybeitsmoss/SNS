using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class center : MonoBehaviour
{

    public GameObject healthBar;
    public health healthScript;
    public float rotationSpeed;
    private Vector3 speed;

    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        speed = new Vector3(0f, 0f, rotationSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(speed * Time.deltaTime);
    }

    IEnumerator GameOver()
    {
        while (rotationSpeed > 0f)
        {
            rotationSpeed -= 0.01f;
            speed = new Vector3(0f, 0f, rotationSpeed);
            yield return null;
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "enemy" || collider.tag == "footEnemy")
        {
            if(SceneManager.GetActiveScene().name != "thissomebullshit")
            {
                healthScript.TakeDamage();
            }
            else
            {
                healthBar.GetComponent<AudioSource>().Play();
            }
            
            Destroy(collider.gameObject);
            StartCoroutine(Hurt(0.15f));
        }
    }

    IEnumerator Hurt(float duration)
    {
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.2f);

        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float percent = elapsed / duration;
            spriteRenderer.color = Color.Lerp(Color.red, Color.white, percent);
            

            Color spriteColorRN = spriteRenderer.color;
            spriteColorRN.a = 0.75f;
            spriteRenderer.color = spriteColorRN;

            yield return null;
        }

        spriteRenderer.color = Color.white;

        Color spriteColor = spriteRenderer.color;
        spriteColor.a = 0.75f;
        spriteRenderer.color = spriteColor;

        
    }
}
