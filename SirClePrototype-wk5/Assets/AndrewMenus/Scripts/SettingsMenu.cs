using UnityEngine;
using System.Collections;

public class SettingsMenu : MonoBehaviour {
    public GameObject pauseMenu;
    private PauseMenu pauseHead;
	// Use this for initialization
	void Start () {
        if (!pauseHead)
            pauseHead = GameObject.FindObjectOfType<PauseMenu>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Back()
    {
        pauseHead.setSetting(false);
        pauseHead.setPause(true);
        pauseMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
