using UnityEngine;
using System.Collections;
//CODE IS SHIT, NEEDS MEGA CLEANUP, IGNORE FOR NOW(AT LEAST IT WORKS)
public class Music : MonoBehaviour {

	public ThemesScript Themes;
			
	// Use this for initialization
	void Start () {

		Themes = FindObjectOfType<ThemesScript>();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision col)
	{
		
		if (col.gameObject.tag == "Jump") {
			if (Themes.Test == 0) {
				VolumeControl (Themes.Source, 1);
			} else if (Themes.Test == 1) {
				VolumeControl (Themes.Sources1, 1);
			}
	

		} else if (col.gameObject.tag == "Water") {
			if (Themes.Test == 0) {
				VolumeControl (Themes.Source, 2);
			}
			/*else if (Themes.Test ==1)
			{
				VolumeControl(Themes.Sources1,2);
			}*/
		} else if (col.gameObject.tag == "Change") {
			Themes.Test = 1;
			Themes.playing=false;
		}
	}
  public void VolumeControl(AudioSource[] SourceA,int Piece)
	{
		SourceA[Piece].volume = 0.4f;
	}
}
