using UnityEngine;
using System.Collections;

public class RangedAttack : MonoBehaviour {
	
	private PlayerMove playerMove;
	private CharacterMotor characterMotor;

	public GameObject ProjectileObject;
	public Transform SpawnPosition;

    public AudioClip noAmmo;

	public float WaitBeforeFiring =0.2f;
	public float CooldownTime =1f;

	private GameObject LastFiredProjectile;
	
	private bool CanShoot;

    public int bulletCount = 3;

	public float leftOrRight;

	// Use this for initialization
	void Start () {
		//We're supposed to be on the same gameobject as the PlayerMove...
		playerMove = GetComponent<PlayerMove>();
		CanShoot=true;
	}
	
	//Runs every frame
	void Update () {

		// Binary shooting directions, either just left or right. based on how much he's facing in the given direction.
        // NOTE: Currently broken-- can only shoot towards the right side of the screen
		if(this.gameObject.transform.rotation.y <= 180f)
		{
			leftOrRight = 90f;
		}

		if(this.gameObject.transform.rotation.y >= 180f)
		{
			leftOrRight = -90f;
		}

		//If the player pressed the P key & isn't on CoolDown & has ammo, subtract bullet count
		if (Input.GetKeyDown(KeyCode.P) && CanShoot && bulletCount > 0) {	
			//Now start a coroutine that will wait before firing.
			StartCoroutine(WaitAndFire(WaitBeforeFiring));
			CanShoot=false;
			StartCoroutine(CoolDown(CooldownTime));

            bulletCount--;
		}

        // we don't want the ammo to ever be a negative number
        if (bulletCount <= 0)
            bulletCount = 0;

        // When the player runs out of ammo and tries to fire a bullet, play the 'click' no ammo sound
        if (Input.GetKeyDown(KeyCode.P) && bulletCount <= 0)
        {
            GetComponent<AudioSource>().clip = noAmmo;
            GetComponent<AudioSource>().Play();

            Debug.Log("Out of ammo, sucker! Go find some more!");
        }
	}

	IEnumerator WaitAndFire(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		Vector3 spawnPos = Vector3.zero;

		spawnPos = SpawnPosition.position;

		//Instantiate mustache on our spawn position.
		LastFiredProjectile = GameObject.Instantiate(ProjectileObject,spawnPos,Quaternion.AngleAxis(leftOrRight,Vector3.up)) as GameObject;

		//Using other script to fire our stache.
		LastFiredProjectile.GetComponent<ScriptProjectile>().Initialize();
	}
	
	//Stops the player from spamming shots.
	IEnumerator CoolDown(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		CanShoot=true;
	}
}
