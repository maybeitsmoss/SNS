using UnityEngine;

public class slicedEnemy : MonoBehaviour
{

    private Rigidbody2D rb;
    public float force;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float rand1 = Random.Range(0, 1);
        float rand2 = Random.Range(0, 1);
        Vector2 direction = new Vector2(rand1, rand2);

        rb.AddForce(direction * force, ForceMode2D.Impulse);
    }
}
