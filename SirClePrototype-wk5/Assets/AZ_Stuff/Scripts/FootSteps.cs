using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(AudioSource))]

public class FootSteps : MonoBehaviour {
	
	public AudioClip Footstep;
	private AudioSource footSteps;
	private float movementDistance;

	private float volLowRange = .5f;
	private float volHighRange = 0.8f;
	
	private float lowPitchRange = .75F;
	private float highPitchRange = 1.0F;
	void Awake()
	{
		movementDistance = 0.0f;
		footSteps = GetComponent<AudioSource>();
	}
	
	void Start ()
	{
	}
	
	
	void Update ()
	{

		if(Input.GetKey ("w") || Input.GetKey ("a") || Input.GetKey ("s") || Input.GetKey ("d"))
		{
			movementDistance += 0.1f;

		}
		
		if (movementDistance >= 1.3f)
		{
			footSteps.pitch = Random.Range (lowPitchRange,highPitchRange);
			float vol = Random.Range (volLowRange, volHighRange);
			footSteps.PlayOneShot(Footstep,vol);
			movementDistance = 0.0f;
		}
		
	}
}
