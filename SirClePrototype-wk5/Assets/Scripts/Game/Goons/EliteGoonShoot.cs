using UnityEngine;
using System.Collections;

public class EliteGoonShoot : MonoBehaviour {

    private Cannon gun;
    private BasicGoonAI movement;
    private bool right;
    private bool once = true;
    private RangeCheck vision;

	// Use this for initialization
	void Start () {
        gun = GetComponentInChildren<Cannon>();
        movement = GetComponent<BasicGoonAI>();
        vision = GetComponentInChildren<RangeCheck>();
	}
	
	// Update is called once per frame
	void Update () {
        if (movement.h == 1)
            gun.direction = 90;
        else
            gun.direction = -90;
        if (vision.IsInRange() && once)
        {
            once = false;
            gun.setCanShoot(true);
        }
        else if (!vision.IsInRange())
        {
            Debug.Log("ONCE SWAP");
            once = true;
            gun.setCanShoot(false);
        }
    }
}
