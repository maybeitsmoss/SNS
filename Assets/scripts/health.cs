using UnityEngine;
using TMPro;

public class health : MonoBehaviour
{
    //public TMP_Text healthText;
    //private int healthCount = 100;

    //public GameObject healthBar;
    private float healthCount;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //healthText.text = healthCount.ToString();
        healthCount = 100f;

    }

    public void TakeDamage()
    {
        //healthCount -= 10;
        //healthText.text = healthCount.ToString();
        healthCount -= 10f;


        Vector3 squishedScale = new Vector3(healthCount / 100f, 1, 1);

        transform.localScale = squishedScale;

        Debug.Log(healthCount);

        
    }
}
