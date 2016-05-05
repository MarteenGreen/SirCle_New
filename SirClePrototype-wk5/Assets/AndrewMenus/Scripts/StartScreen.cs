using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void StartGame()
    {
        Application.LoadLevel(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
