using UnityEngine;
using System.Collections;

public class ChangeMusic : MonoBehaviour {
	public ThemesScript Themes;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Themes = FindObjectOfType<ThemesScript>();	
	}
	void OnMouseDown(){
		if (gameObject.name == "Theme1") {

			Themes.Test=0;
			Themes.playing=false;
		}
		else if (gameObject.name == "Theme2") {
			
			Themes.Test=1;
			Themes.playing=false;
		}
		else if (gameObject.name == "Theme3") {
			
			Themes.Test=2;
			Themes.playing=false;
		}
		else if (gameObject.name == "Theme4") {
			
			Themes.Test=3;
			Themes.playing=false;
		}
	}
}
