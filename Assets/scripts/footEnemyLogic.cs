using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class footEnemylogic : MonoBehaviour
{
    public Vector2 targetPoint;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public GameObject boomPrefab;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 newPosition = Vector2.MoveTowards(rb.position, targetPoint, moveSpeed * Time.deltaTime);
        rb.MovePosition(newPosition);

        if (transform.position.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "foot")
        {
            Instantiate(boomPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
}
