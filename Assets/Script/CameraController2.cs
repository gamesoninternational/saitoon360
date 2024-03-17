using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2 : MonoBehaviour
{
    public float speed = 3.5f;
    private float X;
    private float Y;

    private Camera ZoomCamera;
    private float ScrollSpeed = 10;
    public float minZoom = 20f;
    public float maxZoom = 90f;

    // Start is called before the first frame update
    void Start()
    {
        ZoomCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //Debug.Log("Camera Rotate");
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * speed, -Input.GetAxis("Mouse X") * speed, 0));
            X = transform.rotation.eulerAngles.x;
            Y = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(X, Y, 0);
        }

        if (ZoomCamera.orthographic)
        {
            ZoomCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
            float newFov = Camera.main.fieldOfView;
            Camera.main.fieldOfView = Mathf.Clamp(newFov, minZoom, maxZoom);
        }
        else
        {
            ZoomCamera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
            float newFov = Camera.main.fieldOfView;
            Camera.main.fieldOfView = Mathf.Clamp(newFov, minZoom, maxZoom);
        }
    }
}
