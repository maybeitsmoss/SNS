using UnityEngine;

public class center : MonoBehaviour
{

    public health healthScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "enemy" || collider.tag == "footEnemy")
        {
            healthScript.TakeDamage();
            Destroy(collider.gameObject);
        }
    }
}
