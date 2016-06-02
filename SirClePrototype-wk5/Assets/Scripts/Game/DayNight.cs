using UnityEngine;
using System.Collections;

public class DayNight : MonoBehaviour {

    public GameObject player;
    private float plyrStrt;
    public float reduc;
    public float offset;

	// Use this for initialization
	void Start () {
        plyrStrt = player.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        transform.localEulerAngles = new Vector3(((player.transform.position.x - plyrStrt) * reduc) - offset, 510, -180);
	}
}
