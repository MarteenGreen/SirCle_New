using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

    private HP health;
    public int deathDelay;
    private bool dead = false;

	// Use this for initialization
	void Start () {
        health = GetComponent<HP>();
	}
	
	// Update is called once per frame
	void Update () {
        if (health.GetHP() <= 0)
            Dying();
	}
    void Dying()
    {
        //PlayAnimationHere
        StartCoroutine(WaitToDie(deathDelay));
    }
    IEnumerator WaitToDie(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if(gameObject.tag != "player")
            gameObject.SetActive(false);
        dead = true;
    }
    public bool GetDead()
    {
        return dead;
    }
}
