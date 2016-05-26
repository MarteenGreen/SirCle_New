using UnityEngine;
using System.Collections;



/// <summary>
/// Sets The Manger to Edit the GamePad use. Used for only buttons not Left or Right Joystick Support.
/// Left and Right Joystick are handled by Unity's InputManager
/// 
/// Turns out that Unity already has a pretty good setup for Controller support.
/// This Script might be redundant. Most of the Use of the Original Keyboard script
/// was to simplify access to variable names for other scripts and so all the names got
/// called the same. Looks like I might just have to draw up the schematics by hand so
/// everyone knows it by that and not this manager.
/// 
/// Either That or this will be for button Inputs, the Movement of Joysticks on the controller
/// are governed slightly differently than button inputs. Since you have to make the type change
/// from button to Joystick Axis.
/// </summary>
public class GamePadManager : MonoBehaviour {

    public KeyCode Jump;
    public KeyCode LS_Right;
    public KeyCode LS_Left;
    public KeyCode Menu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(Jump))
        {
            Debug.Log("Jump");
        }

        if (Input.GetKey(LS_Right))
        {
            Debug.Log("LS_Right");
        }

        if (Input.GetKey(LS_Left))
        {
            Debug.Log("LS_Left");
        }

        if (Input.GetKey(Menu))
        {
            Debug.Log("Menu");
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            Debug.Log("FUCK");
            Debug.Log(Input.GetAxis("Horizontal"));
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            //Debug.Log("FUCK 2");
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            //Debug.Log(Input.GetAxis("Vertical"));
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            Debug.Log("FUCK 4");
            Debug.Log(Input.GetAxis("Vertical"));
        }
	}
}
