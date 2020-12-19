using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideVisual : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {

        Debug.Log("collide!!!");
        if (collision.relativeVelocity.magnitude > 0)
        {

            //Debug.Log("collide!!!");

            //if (!disease.getActiveStatus(this)) return;

            collision.gameObject.GetComponentInParent<Human>().infectThis();


        }
    }
}
