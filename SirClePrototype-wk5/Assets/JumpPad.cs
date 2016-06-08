using UnityEngine;
using System.Collections;

public class JumpPad : MonoBehaviour {

    public float force;
	// Use this for initialization
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Butts");
            other.GetComponent<Rigidbody>().AddForce(0, force, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Butts");
            other.GetComponent<Rigidbody>().AddForce(0, force + 50, 0);
        }
    }
}
