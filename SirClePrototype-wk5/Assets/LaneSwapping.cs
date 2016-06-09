using UnityEngine;
using System.Collections;

public class LaneSwapping : MonoBehaviour
{

    public int maxZDepth = 2;
    public int minZDepth = 0;
    public GameObject player;

    //private Vector3 tmpPos;
    public float swapDuration = 1.0f;

    public float swapDist = 1.0f;

    private bool canDodge;
    public float WaitBeforeDodging = 1f;
    public float CooldownDodgeTime = 1f;

    public bool isLaneSwappingAway = false;
    public bool isLaneSwappingTowards = false;

    private float startTime;

    // Use this for initialization
    void Start()
    {
        canDodge = true;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        // Gets the player's position every frame, so we can change it in the lane swap.
        //tmpPos = transform.position;

        if (this.gameObject == player)
        {
            // playerzchecks is so the player can not lane swap into a solid wall
            if (Input.GetKeyDown(KeyCode.W) && PlayerZChecks.isHittingAway == false && isLaneSwappingAway == false)
            {
                isLaneSwappingAway = true;
                LaneSwapAway();
                StartCoroutine(LaneSwapResetTime());
            }

            if (Input.GetKeyDown(KeyCode.S) && PlayerZChecks.isHittingTowards == false && isLaneSwappingTowards == false)
            {
                isLaneSwappingTowards = true;
                LaneSwapTowards();
                StartCoroutine(LaneSwapResetTime());
            }

            // roll dodge thru 2 lanes at once (while holding shift and pressing a direction), with a cooldown (to prevent dodge roll spamming)
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.W) && canDodge)
            {
                canDodge = false;
                LaneDodgeAway();
                //Now start a coroutine that will wait before dodging
                StartCoroutine(WaitAndDodge(WaitBeforeDodging));
                StartCoroutine(CoolDown(CooldownDodgeTime));
            }
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.S) && canDodge)
            {
                canDodge = false;
                LaneDodgeTowards();
                //Now start a coroutine that will wait before dodging
                StartCoroutine(WaitAndDodge(WaitBeforeDodging));
                StartCoroutine(CoolDown(CooldownDodgeTime));
            }
        }

    }

    // when a character needs to swap to a lane *away* from the camera
    public void LaneSwapAway()
    {
        if (transform.position.z < maxZDepth)
        {
            float add1z = transform.position.z + swapDist;
            StartCoroutine(MoveObject(transform.position.z, add1z, swapDuration));
        }
    }
    // when a character needs to swap to a lane *towards* the camera
    public void LaneSwapTowards()
    {
        if (transform.position.z > minZDepth)
        {
            float min1z = transform.position.z - swapDist;
            StartCoroutine(MoveObject(transform.position.z, min1z, swapDuration));
        }
    }

    // Dodge roll through 2 lanes away from the camera at once, instead of 1
    public void LaneDodgeAway()
    {
        if (transform.position.z < maxZDepth - swapDist)
        {
            float add2z = transform.position.z + 2f;
            StartCoroutine(MoveObject(transform.position.z, add2z, swapDuration));
        }
    }
    public void LaneDodgeTowards()
    {
        if (transform.position.z > minZDepth + swapDist)
        {
            float min2z = transform.position.z - 2f;
            StartCoroutine(MoveObject(transform.position.z, min2z, swapDuration));
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

    IEnumerator LaneSwapResetTime()
    {
        yield return new WaitForSeconds(swapDuration);
        isLaneSwappingAway = false;
        isLaneSwappingTowards = false;
    }

    IEnumerator MoveObject(float source, float target, float overTime)
    {
        Debug.Log(target);
        float startTime = Time.time;
        while (Time.time < startTime + overTime)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Lerp(transform.position.z, target, (Time.time - startTime) / overTime));
            yield return null;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, target);
    }
}
