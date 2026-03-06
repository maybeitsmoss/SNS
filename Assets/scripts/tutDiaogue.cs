using UnityEngine;
using System.Collections;
using TMPro;

public class tutDiaogue : MonoBehaviour
{
    public float offset;
    public float waitTime;
    public GameObject ebbPrefab;
    public GameObject flowPrefab;
    public TextMeshProUGUI ebbText;
    public TextMeshProUGUI flowText;
    public float typingSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StartDialogue(offset));
    }

    public void InstantiateEbb()
    {
        Vector3 pos = new Vector3(-44f, 17.5f, 0f);
        Instantiate(ebbPrefab, pos, Quaternion.identity);
    }

    public void InstantiateFlow()
    {
        Vector3 pos = new Vector3(45.9f, 18.5f, 0f);
        Instantiate(flowPrefab, pos, Quaternion.identity);
    }

    IEnumerator StartDialogue(float offset)
    {
        yield return new WaitForSeconds(offset);
        StartCoroutine(TypeDialogue("TESTIN’, TESTIN’! Mic check, one, TWO!", 1));
        waitTime = 3.35f;
        InstantiateEbb();

        yield return new WaitForSeconds(3.35f);
        
        StartCoroutine(TypeDialogue("Yo, you hear us good down there, right? Actually, why am I asking that like we not gods?- We could be in SURROUND SOUND if we wanted to be!", 0));
        waitTime = 8.05f;
        InstantiateFlow();

        yield return new WaitForSeconds(8.05f);
        
        StartCoroutine(TypeDialogue("Flow, we’ve been trapped in a turn table for the past 48 HOURS cause some tone-deaf dummy tried to take the soul stereo, and we wouldn’t let em’!", 1));
        waitTime = 7.48f;
        InstantiateEbb();

        yield return new WaitForSeconds(7.48f);

        StartCoroutine(TypeDialogue("Well when ya put it like that it makes us sound incompetent…", 0));
        waitTime = 3.23f;
        InstantiateFlow();

        yield return new WaitForSeconds(3.23f);

        StartCoroutine(TypeDialogue("…Well, since were not keepin’ secrets, ya do have a habit of-", 1));
        waitTime = 3.60f;
        InstantiateEbb();

        yield return new WaitForSeconds(3.60f);

        StartCoroutine(TypeDialogue("I said us, don’t you put that smut on just me! Besides, we out now ain’t we not?", 0));
        waitTime = 4.91f;
        InstantiateFlow();

        yield return new WaitForSeconds(4.91f);

        StartCoroutine(TypeDialogue("Yeah yeah, whatever. Anyways, you down there! Whatcha said your name was again? ", 1));
        waitTime = 5.16f;
        InstantiateEbb();

        yield return new WaitForSeconds(5.16f);

        ebbText.text = "";
        flowText.text = "";
        Debug.Log("...");
        waitTime = 3.63f;
       

        yield return new WaitForSeconds(3.63f);

        StartCoroutine(TypeDialogue("Not one for talkin’ much, eh? Well it ain’t our problem! We just gon’ call you...cutter!", 0));
        waitTime = 6.36f;
        InstantiateFlow();

        yield return new WaitForSeconds(6.36f);

        StartCoroutine(TypeDialogue("And, cutter, since ya picked up the sword and stuff, you’re pretty much responsible for your world not collapsin’ now!", 1));
        waitTime = 10.40f;
        InstantiateEbb();

        yield return new WaitForSeconds(6.58f);

        StartCoroutine(TypeDialogue("There's some pretty messed up dudes out there who really want that soul stereo...", 1));
        
        yield return new WaitForSeconds(3.82f);

        StartCoroutine(TypeDialogue("OH! See that thing spinning in the center of the room behind ya? Yeah, that big record?", 0));
        waitTime = 10.61f;
        InstantiateFlow();

        yield return new WaitForSeconds(4.71f);

        StartCoroutine(TypeDialogue("That's the soul stereo, the very essence of your universe making your tiny little paper world go round!", 0));

        yield return new WaitForSeconds(5.90f);

        StartCoroutine(TypeDialogue("Without it, you’d all up and die!... But I don’t remember it lookin’ so...", 1));
        waitTime = 7.61f;
        InstantiateEbb();

        yield return new WaitForSeconds(5.23f);

        StartCoroutine(TypeDialogue("...dingey.", 1));

        yield return new WaitForSeconds(2.38f);

        StartCoroutine(TypeDialogue("Well SHER-ROCK HOLMES, thats cause it ain’t the real thing.", 0));
        waitTime = 7.26f;
        InstantiateFlow();

        yield return new WaitForSeconds(3.05f);

        StartCoroutine(TypeDialogue("We gotta make sure our new found scissor-slinger knows what they doin’ before we put the world in they hands!", 0));

        yield return new WaitForSeconds(4.21f);

        StartCoroutine(TypeDialogue("Right, right. I guess we don’t got a choice either with little miss discordance threatinin’ to show her face again...", 1));
        waitTime = 9.95f;
        InstantiateEbb();

        yield return new WaitForSeconds(6.46f);

        StartCoroutine(TypeDialogue("You think shes still usin’ portals to send her fiends our way?", 1));

        yield return new WaitForSeconds(3.49f);

        StartCoroutine(TypeDialogue("Like always. But since we know that it gives us an upper hand!", 0));
        waitTime = 9.45f;
        InstantiateFlow();

        yield return new WaitForSeconds(3.70f);

        StartCoroutine(TypeDialogue("Cutter, enemies is gon start appearing out them make shift holes. Fling yourself around and chop em’ up on beat!", 0));

        yield return new WaitForSeconds(5.75f);

        ebbText.text = "";
        flowText.text = "";
        Debug.Log("...");
        waitTime = 6.46f;

        yield return new WaitForSeconds(6.46f);
        
        StartCoroutine(TypeDialogue("Oh yeah we cookin’ like hot grease now! Them foes ain’t always gonna come out in slow patterns though...", 0));
        waitTime = 5.64f;
        InstantiateFlow();

        yield return new WaitForSeconds(5.64f);

        StartCoroutine(TypeDialogue("Nor are they gonna be able to go down with just that sword! Them teal ones you’s gonna have to KICK!", 1));
        waitTime = 5.42f;
        InstantiateEbb();

        yield return new WaitForSeconds(5.42f);

        ebbText.text = "";
        flowText.text = "";
        Debug.Log("...");
        waitTime = 7.46f;

        yield return new WaitForSeconds(7.46f);
        
        StartCoroutine(TypeDialogue("Ya know what, I was havin’ my doubts but this kids’ pretty good! Let's pick up the pace a bit…", 1));
        waitTime = 5.05f;
        InstantiateEbb();

        yield return new WaitForSeconds(5.05f);

        StartCoroutine(TypeDialogue("We’ll give you a warning or two, since we can get a good sense of when the big bads gon come on in...", 0));
        waitTime = 6.76f;
        InstantiateFlow();

        yield return new WaitForSeconds(4.21f);

        StartCoroutine(TypeDialogue("...but we ain’t gon say much this time around!", 0));

        yield return new WaitForSeconds(2.55f);

        ebbText.text = "";
        flowText.text = "";
        Debug.Log("...");

    }

    IEnumerator TypeDialogue(string quote, int toggle)
    {
        if(toggle == 1)
        {
            ebbText.maxVisibleCharacters = 0;
            ebbText.text = quote;
            flowText.text = "";
        }
        else if(toggle == 0)
        {
            flowText.maxVisibleCharacters = 0;
            flowText.text = quote;
            ebbText.text = "";
        }

        int characterCount = quote.Length;

        if(toggle == 1)
        {
            for (int i = 0; i <= characterCount; i++)
            {
                ebbText.maxVisibleCharacters = i;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
        else if(toggle == 0)
        {
            for (int i = 0; i <= characterCount; i++)
            {
                flowText.maxVisibleCharacters = i;
                yield return new WaitForSeconds(typingSpeed);
            }
        }



    }


}
