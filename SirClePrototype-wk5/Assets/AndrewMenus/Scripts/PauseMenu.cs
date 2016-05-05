using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject pause;
    public GameObject settings;
    public GameObject keyBinding;

    private bool paused;
    private bool isPause;
    private bool isSetting;
    private bool isKeys;
    private KeyboardManager keyboard;

	// Use this for initialization
	void Start () {
        if (!keyboard)
        {
            keyboard = GameObject.FindObjectOfType<KeyboardManager>();
        }
        paused = false;
        isPause = false;
        if (!pauseMenu)
        {
            pauseMenu = GameObject.Find("PauseMenu");
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(keyboard.Menu))
        {
            paused = !paused;
            isPause = paused;
        }

        if (paused)
        {
            pauseMenu.SetActive(true);
            if (isPause)
            {
                pause.SetActive(true);
                settings.SetActive(false);
                keyBinding.SetActive(false);
            }
            Time.timeScale = 0;
        }
        else if (!paused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }

	}

    public void Resume()
    {
        paused = false;
    }

    public void MainMenu()
    {
        Application.LoadLevel(1);
    }

    public void Quit()
    {
		Application.LoadLevel(Application.loadedLevel);
    }

    public void Settings()
    {
        
        settings.SetActive(true);
        isSetting = true;
        pause.SetActive(false);
        isPause = false;
        keyBinding.SetActive(false);
        isKeys = false;
    }

    public void KeyBind()
    {
        keyBinding.SetActive(true);
        isKeys = true;
        settings.SetActive(false);
        isSetting = false;     
    }

    public void setSetting(bool state)
    {
        isSetting = state;
    }
    public void setPause(bool state)
    {
        isPause = state;
    }
}
