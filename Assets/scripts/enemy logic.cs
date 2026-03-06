using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class enemylogic : MonoBehaviour
{
    public Vector2 targetPoint;
    private float moveSpeed;
    private Rigidbody2D rb;
    public GameObject halfPrefab;
    private GameObject record;

    public float stage1moveSpeed;
    public float stage2moveSpeed;
    public float stage3moveSpeed;
    public float stage0moveSpeed;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "bbringitbaack")
        {
            moveSpeed = stage1moveSpeed;
        }
        else if(SceneManager.GetActiveScene().name == "readyOrNot")
        {
            moveSpeed = stage2moveSpeed;
        }
        else if(SceneManager.GetActiveScene().name == "hhheyyyyyy")
        {
            moveSpeed = stage3moveSpeed;
        }
        else
        {
            moveSpeed = stage0moveSpeed;
        }
        record = GameObject.Find("radius");
        rb = GetComponent<Rigidbody2D>();
        targetPoint = record.transform.position;
        
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
            Instantiate(halfPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
}
