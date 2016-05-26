using UnityEngine;
using System.Collections;

public class IFrames : MonoBehaviour {

    public float invincSecs;
    public bool invincible = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool IsInvincible()
    {
        return invincible;
    }

    public void ActivateIFrames()
    {
        StartCoroutine("InvincibleWait");
    }

    IEnumerator InvincibleWait()
    {
        invincible = true;
        yield return new WaitForSeconds(invincSecs);
        invincible = false;
    }
}
