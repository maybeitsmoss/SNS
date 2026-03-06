using UnityEngine;
using System.Collections;

public class tutDiaogue : MonoBehaviour
{
    public float offset;
    public float waitTime;
    public GameObject ebbPrefab;
    public GameObject flowPrefab;
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

        Debug.Log("TESTIN’, TESTIN’! MIC CHECK, ONE, TWO!");
        waitTime = 3.35f;
        InstantiateEbb();

        yield return new WaitForSeconds(3.35f);
        
        Debug.Log("YO, YOU HEAR US GOOD DOWN THERE, RIGHT? ACTUALLY, WHY AM I ASKING THAT LIKE WE NOT GODS?- WE COULD BE IN SURROUND SOUND IF WE WANTED TO BE!");
        waitTime = 8.05f;
        InstantiateFlow();

        yield return new WaitForSeconds(8.05f);
        
        Debug.Log("FLOW, WE’VE BEEN TRAPPED IN A TURN TABLE FOR THE PAST 48 HOURS CAUSE SOME TONE-DEAF DUMMY TRIED TO TAKE THE SOUL STEREO AND WE WOULDN’T LET EM’!");
        waitTime = 7.48f;
        InstantiateEbb();

        yield return new WaitForSeconds(7.48f);

        Debug.Log("WELL WHEN YA PUT IT LIKE THAT IT MAKES US SOUND INCOMPITANT…");
        waitTime = 3.23f;
        InstantiateFlow();

        yield return new WaitForSeconds(3.23f);

        Debug.Log("…WELL, SINCE WERE NOT KEEPIN’ SECRETS, YA DO HAVE A BIT OF A HABIT OF-");
        waitTime = 3.60f;
        InstantiateEbb();

        yield return new WaitForSeconds(3.60f);

        Debug.Log("I SAID US, DON’T YOU PUT THAT SMUT ON JUST ME! BESIDES, WE OUT NOW AIN’T WE NOT?");
        waitTime = 4.91f;
        InstantiateFlow();

        yield return new WaitForSeconds(4.91f);

        Debug.Log("YEAH YEAH, WHATEVER. ANYWAYS, YOU DOWN THERE! WHATCHA SAID YOUR NAME WAS AGAIN? ");
        waitTime = 5.16f;
        InstantiateEbb();

        yield return new WaitForSeconds(5.16f);

        Debug.Log("...");
        waitTime = 3.63f;
       

        yield return new WaitForSeconds(3.63f);

        Debug.Log("NOT ONE FOR TALKIN’ MUCH, EH? WELL IT AIN’T OUR PROBLEM! WE JUST GON’ CALL YOU...CUTTER!");
        waitTime = 6.36f;
        InstantiateFlow();

        yield return new WaitForSeconds(6.36f);

        Debug.Log("AND, CUTTER, SINCE YA PICKED UP THE SWORD AND STUFF, YOU’RE PRETTY MUCH ARE RESPONSIBLE FOR YOUR WORLD NOT COLLAPSIN’ NOW! THERE'S SOME MESSED UP DUDES OUT THERE WHO REALLY WANT THAT SOUL STEREO...");
        waitTime = 10.40f;
        InstantiateEbb();

        yield return new WaitForSeconds(10.40f);

        Debug.Log("OH! SEE THAT THING SPINNING IN THE CENTER OF THE ROOM BEHIND YA? YEAH, THAT BIG RECORD? THAT'S THE SOUL STEREO, THE VERY ESSENCE OF YOUR UNIVERSE MAKING YOUR LITTLE PAPER WORLD GO ROUND!");
        waitTime = 10.61f;
        InstantiateFlow();

        yield return new WaitForSeconds(10.61f);

        Debug.Log("WITHOUT IT, YOU’D ALL UP AND DIE!...BUT I DON’T REMEMBER IT LOOKIN’ SO...DINGEY.");
        waitTime = 7.61f;
        InstantiateEbb();

        yield return new WaitForSeconds(7.61f);

        Debug.Log("WELL SHER-ROCK HOLMES, THATS CAUSE IT AIN’T THE REAL THING. WE GOTTA MAKE SURE OUR NEW FOUND SCISSOR-SLINGER KNOWS WHAT THEY DOIN’ BEFORE WE PUT THE WORLD IN THEY HANDS!");
        waitTime = 7.26f;
        InstantiateFlow();

        yield return new WaitForSeconds(7.26f);

        Debug.Log("RIGHT, RIGHT. I GUESS WE DON’T GOT A CHOICE EITHER WITH LITTLE MISS DISCORDANCE THREATININ’ TO SHOW HER FACE AGAIN. YOU THINK SHES STILL USIN’ PORTALS TO SEND HER FIENDS OUR WAY?");
        waitTime = 9.95f;
        InstantiateEbb();

        yield return new WaitForSeconds(9.95f);

        Debug.Log("LIKE ALWAYS. BUT SINCE WE KNOW THAT IT GIVES US AN UPPER HAND! CUTTER, ENEMIES IS GON START APPEARING OUT THEM MAKE SHIFT HOLES. FLING YOURSELF AROUND AND CHOP EM’ UP ON BEAT!");
        waitTime = 9.45f;
        InstantiateFlow();

        yield return new WaitForSeconds(9.45f);

        Debug.Log("...");
        waitTime = 6.46f;

        yield return new WaitForSeconds(6.46f);
        
        Debug.Log("OH YEAH WE COOKIN’ LIKE HOT GREASE NOW! THEM FOES AIN’T ALWAYS GONNA COME OUT IN SLOW PATTERNS THOUGH...");
        waitTime = 5.64f;
        InstantiateFlow();

        yield return new WaitForSeconds(5.64f);

        Debug.Log("NOR ARE THEY GONNA BE ABLE TO GO DOWN WITH JUST THAT SWORD! THEM TEAL ONES YOU’S GONNA HAVE TO KICK!");
        waitTime = 5.42f;
        InstantiateEbb();

        yield return new WaitForSeconds(5.42f);

        Debug.Log("...");
        waitTime = 7.46f;

        yield return new WaitForSeconds(7.46f);
        
        Debug.Log("YA KNOW WHAT, I WAS HAVIN’ MY DOUBTS BUT THIS KIDS’ PRETTY GOOD! LET'S PICK UP THE PACE A BIT…");
        waitTime = 5.05f;
        InstantiateEbb();

        yield return new WaitForSeconds(5.05f);

        Debug.Log("WE’LL GIVE YOU A WARNING OR TWO, SINCE WE CAN GET A GOOD SENSE OF WHEN THE BIG BADS GON COME ON IN– BUT WE AIN’T GON SAY MUCH THIS TIME AROUND!");
        waitTime = 6.76f;
        InstantiateFlow();

        yield return new WaitForSeconds(6.76f);

        Debug.Log("...");

    }

}
