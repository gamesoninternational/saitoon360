using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCameraRotation : BasicCameraRotation
{
    Vector3 firstPoint;
    public float sensitivity = 2.5f;
    public float minZoom = 20f;
    public float maxZoom = 90f;

    public GameObject CameraObject;

    public float AngkaFOV;

    void Start()
    {
        
    }

    void Update()
    {
        TouchRotation();
        AngkaFOV = Camera.main.fieldOfView;
    }


    void TouchRotation()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Debug.Log("TouchPaseBegan");
                //firstPoint = Input.GetTouch(0).position;
                CameraObject.GetComponent<CameraController2>().enabled = true;
                
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Debug.Log("TouchPaseMoved");
                CameraObject.GetComponent<CameraController2>().enabled = true;
                
                /*Vector3 secondPoint = Input.GetTouch(0).position;

                float x = FilterGyroValues(secondPoint.x - firstPoint.x);
                RotateRightLeft(x * sensitivity);

                float y = FilterGyroValues(secondPoint.y - firstPoint.y);
                RotateUpDown(y * -sensitivity);

                firstPoint = secondPoint;*/
            }
        }

        else if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            if (touch0.phase == TouchPhase.Moved && touch1.phase == TouchPhase.Moved)
            {
                Debug.Log("Pinch");
                // Calculate pinch-to-zoom
                Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
                Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
                float prevTouchDeltaMag = (touch0PrevPos - touch1PrevPos).magnitude;
                float touchDeltaMag = (touch0.position - touch1.position).magnitude;
                float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

                // Adjust the FOV based on pinch gesture
                float newFov = Camera.main.fieldOfView + deltaMagnitudeDiff * Time.deltaTime * 0.75f;
                Camera.main.fieldOfView = Mathf.Clamp(newFov, minZoom, maxZoom);

                Debug.Log("Camera Controller Disabled");
                CameraObject.GetComponent<CameraController2>().enabled = false;
            }
        }
    }
    float FilterGyroValues(float axis)
    {
        float thresshold = 0.5f;
        if (axis < -thresshold || axis > thresshold)
        {
            return axis;
        }
        else
        {
            return 0;
        }
    }
}
