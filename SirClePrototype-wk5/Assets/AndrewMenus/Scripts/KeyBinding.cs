using UnityEngine;
using System.Collections;

public class KeyBinding : MonoBehaviour {

    private KeyboardManager keyboard;
    private KeyCode key;
    private GameObject keyText;
    public GameObject forKey;
    public GameObject backKey;
    public GameObject inKey;
    public GameObject outKey;
    public GameObject jumpKey;
    public GameObject fireKey;
    public GameObject menukey;
	// Use this for initialization
	void Start () {
        if (!keyboard)
        {
            keyboard = GameObject.FindObjectOfType<KeyboardManager>();
        }
	}

    public void changeForKey()
    {
        keyboard.Forward = key;
        
        
    }
}
