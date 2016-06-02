using UnityEngine;
using System.Collections;

public class CameraRaycast : MonoBehaviour 
{
    Camera camera;

    public GameObject toHide;
    public bool turnInvisible = false;

	private float alphaObject;

    void Start()
    {
        camera = GetComponent<Camera>();
		alphaObject = toHide.GetComponent<MeshRenderer>().material.color.a;
    }

    void Update()
    {
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        { 
            // make this object transparent if NOT player
            if (hit.transform.tag == "ground")
            {
                toHide = hit.transform.gameObject;
                toHide.GetComponent<MeshRenderer>().enabled = false;
                turnInvisible = true;
			}

			// Once the player is visible by the camera again, turn the object back on.
            if (toHide.GetComponent<MeshRenderer>().enabled == false && hit.transform.tag == "Player")
            {
                toHide.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
