using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraZoom : MonoBehaviour
{
    public static bool zoomActive;

    public Camera Cam;
    public int cameraZoomAmount = 10;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main;
    }

    // Change the orthographic size of the camera to zoom in or out \\
    void LateUpdate()
    {
        if (zoomActive) {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, cameraZoomAmount, speed);
        }
        else {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 5, speed);
        }
    }
}
