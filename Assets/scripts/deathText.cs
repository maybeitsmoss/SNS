using UnityEngine;
using TMPro;
public class deathText : MonoBehaviour
{
    public TextMeshProUGUI deathTextElement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deathTextElement = GetComponent<TextMeshProUGUI>();

        int randomNum = Random.Range(0, 10);

        switch (randomNum)
        {
            case 0:
                deathTextElement.text = "Looks like someone got outpaced…";
                break;
            case 1:
                deathTextElement.text = "Should I lower the tempo? Or my expectations…";
                break;
            case 2:
                deathTextElement.text = "We clearly aren’t on the same wavelength…";
                break;
            case 3:
                deathTextElement.text = "Sounds like someone's in treble...";
                break;
            case 4:
                deathTextElement.text = "Oh- was that it?";
                break;
            case 5:
                deathTextElement.text = "That performance lacked star quality!";
                break;
            case 6:
                deathTextElement.text = "Let's spin that back again...";
                break;
            case 7:
                deathTextElement.text =  "Nobody's raving over that performance...";
                break;
            case 8:
                deathTextElement.text = "This beat is bass-ically impossible!";
                break;
            case 9:
                deathTextElement.text = "I think my heart skipped a beat! Or was that you...?";
                break;
        }
    }
}

