using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecursivePreventSelfCollisions : MonoBehaviour
{

    public bool applyToBaseObject = false;

    //Go through each child and set its collider to ignore all other colliders in our gameObject
    void Awake()
    {
        #region Disable this objects collision with it's own children
        if (applyToBaseObject == true)
        {
            Collider collider1 = GetComponent<Collider>();
            if (collider1 != null)
            {//Checking for collider anyway just to be safe!
                foreach (Transform child2 in transform)
                {
                    //Debug.Log ("Finding collider2");
                    Collider collider2 = child2.GetComponent<Collider>();
                    if (collider2 == null)
                    {
                        continue;
                    }
                    else
                    {
                        Physics.IgnoreCollision(collider1, collider2);
                    }//Disable a collision
                }//Secondary foreach statement
            }
        }
        #endregion


        #region Disable collisions between all children
        foreach (Transform child1 in transform)
        {
            //Debug.Log ("Finding collider");
            Collider collider1 = child1.GetComponent<Collider>();
            if (collider1 == null)
            {
                continue;
            }
            else
            {//If this object does not have a collider, ignore it and move onto the next object
                foreach (Transform child2 in transform)
                {
                    //Debug.Log ("Finding collider2");
                    Collider collider2 = child2.GetComponent<Collider>();
                    if (collider2 == null)
                    {
                        continue;
                    }
                    else
                    {
                        Physics.IgnoreCollision(collider1, collider2);
                    }//Disable a collision


                }//Secondary foreach statement
            }
        }//Master foreach statement
        #endregion
    }
}