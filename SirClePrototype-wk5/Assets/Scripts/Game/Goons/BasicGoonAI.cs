using UnityEngine;
using System.Collections;

public class BasicGoonAI : MonoBehaviour
{

    public bool facingRight = true;
    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public Transform plyrTrans;

    private float lockPos = 0;
    private Rigidbody rbd;
    public float h = 1;//H is for horizontal!
    public BoxCollider swapTrigger;
    private RangeCheck vision;
    private LaneSwapping swapEm;
    private GeneralZCheck[] zChk;
    private GeneralZCheck zChkAwy;
    private GeneralZCheck zChkTwrd;
    private bool swapped = false;
    public float swapCD;
    public float RANDswapCD;
    private int rand;
    private bool RANDSwapped = false;


    // Use this for initialization
    void Awake()
    {
        rbd = GetComponent<Rigidbody>();
        swapEm = GetComponent<LaneSwapping>();
        vision = GetComponentInChildren<RangeCheck>();
        zChk = GetComponentsInChildren<GeneralZCheck>();
        if(zChk[0].away)
        {
            zChkAwy = zChk[0];
            zChkTwrd = zChk[1];
        }
        else
        {
            zChkAwy = zChk[1];
            zChkTwrd = zChk[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        rand = Random.Range(0, 1);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);
    }

    void FixedUpdate()
    {
        if (vision.IsInRange())//If the player is close, move towards them
        {
            Debug.Log("hello");
            h = plyrTrans.position.x - transform.position.x;
            h /= Mathf.Abs(h);//h is used as left/right flip. we only care if it's negative or not.

            if (h * rbd.velocity.x < maxSpeed)//Give it force while below maxSpeed
                rbd.AddForce(Vector3.right * h * moveForce);

            if (Mathf.Abs(rbd.velocity.x) > maxSpeed)//Snap it back to maxSpeed if it accelerates too fast.
                rbd.velocity = new Vector3(Mathf.Sign(rbd.velocity.x) * maxSpeed, rbd.velocity.y);

            if (h > 0 && !facingRight)
                Flip();
            else if (h < 0 && facingRight)
                Flip();

            if (!swapped)
            {
                if (plyrTrans.position.z - transform.position.z < -.5 && zChkAwy.isHittingAway == false)
                {
                    StartCoroutine("WaitNSwap");
                    swapEm.LaneSwapTowards();
                }
                else if (plyrTrans.position.z - transform.position.z > .5 && zChkTwrd.isHittingTowards == false)
                {
                    StartCoroutine("WaitNSwap");
                    swapEm.LaneSwapAway();
                }
            }
            if (!RANDSwapped)
            {
                if (zChkAwy.isHittingAway == false && zChkTwrd.isHittingTowards == false)
                {
                    StartCoroutine("WaitNRandSwap");
                    if (rand == 0)
                        swapEm.LaneSwapTowards();
                    else
                        swapEm.LaneSwapAway();
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")//Whatever tag the player projectile is set to.
        {
            Destroy(gameObject);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    IEnumerator WaitNSwap()
    {
        swapped = true;
        yield return new WaitForSeconds(swapCD);
        swapped = false;
    }
    IEnumerator WaitNRandSwap()
    {
        RANDSwapped = true;
        yield return new WaitForSeconds(RANDswapCD);
        RANDSwapped = false;
    }
}