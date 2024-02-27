using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using TouchPhase = UnityEngine.TouchPhase;

public class CameraController : BasicCameraRotation
{
    public float rotationSpeed;

    float pitch;
    float yaw;

    private float ScrollSpeed = 10;
    private Camera ZoomCamera;

    public float minZoom = 20f;
    public float maxZoom = 90f;

    private void Start()
    {
        ZoomCamera = Camera.main;
    }

    void Update() {
        TouchRotation();

        //PC Input
        if (Input.GetMouseButton(0))
        {
            float h = rotationSpeed * Input.GetAxis("Mouse X");
            float v = rotationSpeed * Input.GetAxis("Mouse Y");

            transform.Rotate(v, -h, 0);
            //Add these two lines
            float z = transform.eulerAngles.z;
            transform.Rotate(0, 0, -z);
        }

        if (ZoomCamera.orthographic)
        {
            ZoomCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;

        }
        else
        {
            ZoomCamera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
        } 
    }

    //mobile input
    void TouchRotation()
    {
        Touch touch0 = Input.GetTouch(0);
        Touch touch1 = Input.GetTouch(1);

        if (touch0.phase == TouchPhase.Moved && touch1.phase == TouchPhase.Moved)
        {
            // Calculate pinch-to-zoom
            Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
            Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
            float prevTouchDeltaMag = (touch0PrevPos - touch1PrevPos).magnitude;
            float touchDeltaMag = (touch0.position - touch1.position).magnitude;
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // Adjust the FOV based on pinch gesture
            float newFov = Camera.main.fieldOfView + deltaMagnitudeDiff * Time.deltaTime * 0.75f;
            Camera.main.fieldOfView = Mathf.Clamp(newFov, minZoom, maxZoom);
        }
    }
}