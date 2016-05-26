using UnityEngine;
using System.Collections;

public class PlayNoise : MonoBehaviour {

	public AudioClip TrainTracks;

	private AudioSource source;
	private float volLowRange = .5f;
	private float volHighRange = 0.8f;

	private float lowPitchRange = .75F;
	private float highPitchRange = 1.5F;

	// Use this for initialization
	void Awake () {

		source = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {

		//source.pitch = Random.Range (lowPitchRange,highPitchRange);
		source.volume = Random.Range (volLowRange, volHighRange);
		if (Input.GetMouseButtonDown(0))
		{
			float vol = Random.Range (volLowRange, volHighRange);
			source.PlayOneShot(TrainTracks,vol);

		}
	}
}
