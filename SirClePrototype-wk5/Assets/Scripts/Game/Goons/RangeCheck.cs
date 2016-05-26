using UnityEngine;
using System.Collections;

public class RangeCheck : MonoBehaviour {
    private bool InRange;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            InRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            InRange = false;
        }
    }

    public bool IsInRange()
    {
        return InRange;
    }
}
