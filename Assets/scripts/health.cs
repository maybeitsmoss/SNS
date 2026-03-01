using UnityEngine;
using TMPro;

public class health : MonoBehaviour
{
    public TMP_Text healthText;
    private int healthCount = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthText.text = healthCount.ToString();
    }

    public void TakeDamage()
    {
        healthCount -= 10;
        healthText.text = healthCount.ToString();
    }
}
