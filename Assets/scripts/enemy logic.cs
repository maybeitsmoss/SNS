using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemylogic : MonoBehaviour
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

        if(transform.position.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        Vector2 newPosition = Vector2.MoveTowards(rb.position, targetPoint, moveSpeed * Time.deltaTime);
        rb.MovePosition(newPosition);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "sword")
        {
            Instantiate(boomPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
}
