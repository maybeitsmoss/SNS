using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class center : MonoBehaviour
{

    public health healthScript;
    public float rotationSpeed;
    private Vector3 speed;

    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        speed = new Vector3(0, 0, rotationSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "enemy" || collider.tag == "footEnemy")
        {
            healthScript.TakeDamage();
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
