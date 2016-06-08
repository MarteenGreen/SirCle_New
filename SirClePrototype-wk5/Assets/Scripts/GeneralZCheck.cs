using UnityEngine;
using System.Collections;

public class GeneralZCheck : MonoBehaviour {

    public GameObject entity;
    public GameObject detector;

    public bool isHittingAway = false;
    public bool isHittingTowards = false;
    public bool away;

    // Update is called once per frame
    void Update()
    {
        detector.transform.position = entity.transform.position;
    }

    // when either his front or back colliders are hitting a wall
    void OnTriggerStay(Collider other)
    {
        if (away)
        {
            if (other.tag == "ground")
            {
                Debug.Log("GENERAL: hit!!!");
                isHittingAway = true;
            }
        }

        else
        {
            if (other.tag == "ground")
            {
                Debug.Log("GENERAL: hit!!!");
                isHittingTowards = true;
            }
        }
    }

    // when his colliders are no longer touching that wall
    void OnTriggerExit(Collider other)
    {
        if (away)
        {
            if (other.tag == "ground")
            {
                Debug.Log("GENERAL: exited");
                isHittingAway = false;
            }
        }

        else
        {
            if (other.tag == "ground")
            {
                Debug.Log("GENERAL: exited");
                isHittingTowards = false;
            }
        }
    }
}
