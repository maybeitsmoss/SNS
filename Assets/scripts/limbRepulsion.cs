using UnityEngine;

public class limbRepulsion : MonoBehaviour
{
    public float repelStrength;
    public float repelRange;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        //make an array of all objects with repel script within distance
        Collider2D[] collidersToRepel = Physics2D.OverlapCircleAll(transform.position, repelRange);

        foreach (Collider2D collider in collidersToRepel)
        {
            if (collider.gameObject != this.gameObject)
            {
                Rigidbody2D otherRb = collider.GetComponent<Rigidbody2D>();
                if (otherRb != null)
                {
                    Vector2 direction = (Vector2)transform.position - (Vector2)collider.transform.position;
                    float distance = direction.magnitude;

                    if (distance > 0)
                    {
                        float forceStrength = repelStrength / (distance * distance);

                        otherRb.AddForce(direction.normalized * forceStrength);
                    }
                }
                
            }
        }
    }
}
