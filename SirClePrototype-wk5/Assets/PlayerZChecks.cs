using UnityEngine;
using System.Collections;

public class PlayerZChecks : MonoBehaviour 
{
    public GameObject player;
    public GameObject detector;

	public static bool isHittingAway = false;
	public static bool isHittingTowards = false;

	// Update is called once per frame
	void Update () {
        detector.transform.position = player.transform.position;
	}

	// when either his front or back colliders are hitting a wall
    void OnTriggerStay(Collider other)
    {
		if(this.gameObject.name == "player z checks - away")
		{
	        if (other.tag == "ground")
	        {
	            Debug.Log("hit!!!");
				isHittingAway = true;
	        }
		}

		if(this.gameObject.name == "player z checks - towards")
		{
			if (other.tag == "ground")
			{
				Debug.Log("hit!!!");
				isHittingTowards = true;
			}
		}
    }

	// when his colliders are no longer touching that wall
	void OnTriggerExit(Collider other)
	{
		if(this.gameObject.name == "player z checks - away")
		{
			if (other.tag == "ground")
			{
				Debug.Log("exited");
				isHittingAway = false;
			}
		}

		if(this.gameObject.name == "player z checks - towards")
		{
			if (other.tag == "ground")
			{
				Debug.Log("exited");
				isHittingTowards = false;
			}
		}
	}
}
