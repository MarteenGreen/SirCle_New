using UnityEngine;
using System.Collections;

public class LaneSwapping : MonoBehaviour {

	public int maxZDepth = 2;
	public GameObject player;

	private Vector3 tmpPos;
    
    private bool canDodge;
    public float WaitBeforeDodging = 1f;
    public float CooldownDodgeTime = 1f;

	// Use this for initialization
	void Start () {
        canDodge = true;
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

            // roll dodge thru 2 lanes at once (while holding shift and pressing a direction), with a cooldown (to prevent dodge roll spamming)
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.W) && canDodge)
            {
                LaneDodgeAway();
                //Now start a coroutine that will wait before dodging
                StartCoroutine(WaitAndDodge(WaitBeforeDodging));
                canDodge = false;
                StartCoroutine(CoolDown(CooldownDodgeTime));	
            }
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.S) && canDodge)
            {
                LaneDodgeTowards();
                //Now start a coroutine that will wait before dodging
                StartCoroutine(WaitAndDodge(WaitBeforeDodging));
                canDodge = false;
                StartCoroutine(CoolDown(CooldownDodgeTime));
            }
		}
	
	}

	// when a character needs to swap to a lane *away* from the camera
	public void LaneSwapAway()
	{
		if (tmpPos.z < maxZDepth)
		{
			tmpPos.z = tmpPos.z + 1;    	// assign individual Z axes
            // tmpPos.z =  Mathf.Lerp(tmpPos.z, 1f, 0.5f); // only lerps everytime the key is pressed. will change.
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

    // Dodge roll through 2 lanes away from the camera at once, instead of 1
    public void LaneDodgeAway()
    {
        if (tmpPos.z < maxZDepth)
        {
            tmpPos.z = tmpPos.z + 2;    	// assign individual Z axes
            transform.position = tmpPos;   // Assign back all Vector3
        }
    }
    public void LaneDodgeTowards()
    {
        if (tmpPos.z > 0)
        {
            tmpPos.z = tmpPos.z - 2;    	// assign individual Z axes
            transform.position = tmpPos;   // Assign back all Vector3
        }
    }

    IEnumerator WaitAndDodge(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

    // Stops the player from spamming dodges
    IEnumerator CoolDown(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canDodge = true;
    }
}
