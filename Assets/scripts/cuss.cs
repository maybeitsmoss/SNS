using UnityEngine;

public class cuss : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite cuss1;
    public Sprite cuss2;
    public Sprite cuss3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        int random = Random.Range(0, 3);

        if (random == 0)
        {
            spriteRenderer.sprite = cuss1;
        }
        else if (random == 1)
        {
            spriteRenderer.sprite = cuss2;
        }
        else if (random == 2)
        {
            spriteRenderer.sprite = cuss3;
        }
    }
}
