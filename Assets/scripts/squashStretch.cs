using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class squashStretch : MonoBehaviour
{
    //amount of squash! (fraction of original Y scale)
    public float squishAmount;
    //public Conductor_2 conductorScript;
    public Conductor_3 conductorScript;
    public TutorialConductor tutorialScript;
    private bool offset = true;

    IEnumerator SquishCoroutine()
    {
        if (SceneManager.GetActiveScene().name == "thissomebullshit")
        {
            if (gameObject.tag == "flow" && offset == true)
            {
                offset = false;
                yield return new WaitForSeconds(tutorialScript.crochet);
            }
            
            if (gameObject.tag == "portal")
            {
                yield return new WaitForSeconds(tutorialScript.crochet * 2);
                
            }
            else
            {
                yield return new WaitForSeconds(tutorialScript.crochet);
            }
            

            //Debugging (no bugs only fish)
            //Debug.Log("SquishCoroutine started");

            //store original scale and create squished scale
            Vector3 originalScale = transform.localScale;
            Vector3 squishedScale = transform.localScale;
            squishedScale.y = originalScale.y * squishAmount;

            //squish!
            transform.localScale = squishedScale;
            

            if (gameObject.tag == "portal")
            {
                yield return new WaitForSeconds(tutorialScript.crochet * 2);
            }
            else
            {
                yield return new WaitForSeconds(tutorialScript.crochet);
            }

            //return to original size after another beat
            transform.localScale = originalScale;

            //start over
            StartCoroutine("SquishCoroutine");
        }
        else
        {
            if (gameObject.tag == "flow" && offset == true)
            {
                offset = false;
                yield return new WaitForSeconds(conductorScript.crochet);
            }
            
            if (gameObject.tag == "portal")
            {
                yield return new WaitForSeconds(conductorScript.crochet * 2);
                
            }
            else
            {
                yield return new WaitForSeconds(conductorScript.crochet);
            }
            

            //Debugging (no bugs only fish)
            //Debug.Log("SquishCoroutine started");

            //store original scale and create squished scale
            Vector3 originalScale = transform.localScale;
            Vector3 squishedScale = transform.localScale;
            squishedScale.y = originalScale.y * squishAmount;

            //squish!
            transform.localScale = squishedScale;
            

            if (gameObject.tag == "portal")
            {
                yield return new WaitForSeconds(conductorScript.crochet * 2);
            }
            else
            {
                yield return new WaitForSeconds(conductorScript.crochet);
            }

            //return to original size after another beat
            transform.localScale = originalScale;

            //start over
            StartCoroutine("SquishCoroutine");
        }
        
    }

    public void Stop()
    {
        StopCoroutine(nameof(SquishCoroutine));
    }

    
}
    