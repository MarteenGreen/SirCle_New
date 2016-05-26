using UnityEngine;
using System.Collections;
//CODE IS SHIT, NEEDS MEGA CLEANUP, IGNORE FOR NOW(AT LEAST IT WORKS)
public class ThemesScript : MonoBehaviour {

	public AudioClip[] Theme1;
	public AudioClip[] Theme2;
	
	public AudioSource[] Source;
	public AudioSource[] Sources1;

	public int Test;

	public bool playing = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (Test == 0 && playing == false) {

			for (int j = 0; j <Theme2.Length; j++) {
				StopMusic (j, Theme2, Sources1);
			}

			for (int i = 0; i <Theme1.Length; i++) {

				PlayMusic (i, Theme1, Source);
			}

			playing = true;
		}

		else if (Test == 1 && playing ==false) 
		{
			for (int j = 0; j <Theme1.Length; j++) {

				StopMusic (j, Theme1, Source);}

			for (int j = 0; j <Theme2.Length; j++) {
			PlayMusic (j, Theme2, Sources1);
			}
			playing= true;

		}

	}
	public void PlayMusic(int Piece, AudioClip[]Theme, AudioSource[] SourceA)
	{
		SourceA[Piece].clip = Theme[Piece];
		SourceA[Piece].Play();
		if (Piece != 0) {
			SourceA [Piece].volume = 0.0f;
		}
	}

	public void StopMusic(int Piece, AudioClip[]Theme, AudioSource[] SourceA)
	{
		SourceA[Piece].clip = Theme[Piece];
		SourceA[Piece].Stop();
	}
}
