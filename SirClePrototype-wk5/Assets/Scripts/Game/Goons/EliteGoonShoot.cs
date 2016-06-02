using UnityEngine;
using System.Collections;

public class EliteGoonShoot : MonoBehaviour {

    private Cannon gun;
    private BasicGoonAI movement;
    private bool right;
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
            gun.leftOrRight = 90;
        else
            gun.leftOrRight = -90;
        if (vision.IsInRange())
        {
            gun.setCanShoot(true);
        }
        else
        {
            gun.setCanShoot(false);
        }
    }
}
