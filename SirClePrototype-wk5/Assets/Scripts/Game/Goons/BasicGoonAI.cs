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
    public RangeCheck Vision;
    private LaneSwapping swapEm;


    // Use this for initialization
    void Awake()
    {
        rbd = GetComponent<Rigidbody>();
        swapEm = GetComponent<LaneSwapping>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);
    }

    void FixedUpdate()
    {
        if (Vision.IsInRange())//If the player is close, move towards them
        {
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

            if (plyrTrans.position.z - transform.position.z < -.5)
                swapEm.LaneSwapTowards();
            else if(plyrTrans.position.z - transform.position.z > .5)
                swapEm.LaneSwapAway();
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
}