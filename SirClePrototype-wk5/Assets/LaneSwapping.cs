using UnityEngine;
using System.Collections;

public class LaneSwapping : MonoBehaviour {

	public int maxZDepth = 2;
	public GameObject player;

	private Vector3 tmpPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		tmpPos = transform.position;

		if(this.gameObject == player)
		{
			// playerzchecks is so the player can not lane swap into a solid wall
			if(Input.GetKeyDown(KeyCode.W) && PlayerZChecks.isHittingAway == false)
			{
				LaneSwapAway();
			}

			if(Input.GetKeyDown(KeyCode.S) && PlayerZChecks.isHittingTowards == false)
			{
				LaneSwapTowards();
			}
		}
	
	}

	// when a character needs to swap to a lane *away* from the camera
	public void LaneSwapAway()
	{
		if (tmpPos.z < maxZDepth)
		{
			tmpPos.z = tmpPos.z + 1;    	// assign individual Z axes
			transform.position = tmpPos;   // Assign back all Vector3
		}
	}

	// when a character needs to swap to a lane *towards* the camera
	public void LaneSwapTowards()
	{
		if (tmpPos.z > 0)
		{
			tmpPos.z = tmpPos.z - 1;    	// assign individual Z axes
			transform.position = tmpPos;   // Assign back all Vector3
		}
	}
}
