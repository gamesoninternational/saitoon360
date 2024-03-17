using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;

    private float mZCoord;

    public float rotateSpeed = 10;
    private string sumbu;
    private bool putar;

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos() {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }

    void Update()
    {
         if (putar){
            if(sumbu.ToUpper().Equals("XR")){
                transform.Rotate(Vector3.right * rotateSpeed);
            }
            if(sumbu.ToUpper().Equals("XL")){
                transform.Rotate(Vector3.left * rotateSpeed);
            }
            if(sumbu.ToUpper().Equals("YU")){
                transform.Rotate(Vector3.up * rotateSpeed);
            }
            if(sumbu.ToUpper().Equals("YD")){
                transform.Rotate(Vector3.down * rotateSpeed);
            }
         }
    }

    

    public void RotateObject(string sumbu){
        this.sumbu = sumbu;
        putar = true;
    }

    public void StopRotation(){
        putar = false;
    }

}
