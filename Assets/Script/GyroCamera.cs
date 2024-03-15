using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroCamera : MonoBehaviour
{
    Vector3 rot;
    public float sensitivity;
    // Start is called before the first frame update
    void Start()
    {
        rot = Vector3.zero;
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        rot.y = -Input.gyro.rotationRateUnbiased.y;
        rot.x = -Input.gyro.rotationRateUnbiased.x;
        rot.z = Input.gyro.rotationRateUnbiased.z;
        transform.Rotate(rot*sensitivity);
    }
}
