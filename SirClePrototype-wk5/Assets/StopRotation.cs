using UnityEngine;
using System.Collections;

public class StopRotation : MonoBehaviour {

    void Update()
    {
        Vector3 up = Vector3.up;
        up.y = 0.0f;
    }
}
