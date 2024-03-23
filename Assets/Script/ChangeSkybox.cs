using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class ChangeSkybox : MonoBehaviour
{
    public Material KeScene;
    public GameObject CurrentCanvasUI, NextCanvasUI;

    public float SpeedZoom = 100;
    public float MinFOV = 8;
    public float MaxFOV = 60;

    public int zoomInOut;

    public Animator CamAnim;
    private Camera CamObject;

    
    // Start is called before the first frame update
    void Start()
    {
        CamObject = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (zoomInOut == 1) {
            CamObject.fieldOfView = Mathf.MoveTowards(CamObject.fieldOfView, MinFOV, SpeedZoom * Time.deltaTime);
        }

        

        /*if (zoomInOut == 0)
        {
            CamObject.fieldOfView = Mathf.MoveTowards(CamObject.fieldOfView, MaxFOV, SpeedZoom * Time.deltaTime);
        }*/
    }

    public void keScene(){
        CamObject.GetComponent<TouchCameraRotation>().enabled = false;
        CamObject.GetComponent<CameraController2>().enabled = false;
        //CamObject.GetComponent<Animator>().enabled = true;

        
        
        CamAnim.SetTrigger("CameraTransition");

        ZoomInCam();
        StartCoroutine(SceneTransition());
    }

    IEnumerator SceneTransition() {
        yield return new WaitForSeconds(0.35f);
        zoomInOut = 3;
        yield return new WaitForSeconds(0.35f);
        CamObject.fieldOfView = 60;
        RenderSettings.skybox = KeScene;
        CurrentCanvasUI.SetActive(false);
        NextCanvasUI.SetActive(true);
        CamObject.GetComponent<TouchCameraRotation>().enabled = true;
        CamObject.GetComponent<CameraController2>().enabled = true;
        //CamObject.GetComponent<Animator>().enabled = false;
        //zoomInOut = 3;
        //CamObject.fieldOfView = Mathf.Lerp(CamObject.fieldOfView, MaxFOV, SpeedZoom * Time.deltaTime);
        //CamObject.GetComponent<Animator>().enabled = false;

    }

    public void ZoomInCam() {
        zoomInOut = 1;
    }
    /*public void ZoomOutCam()
    {
        zoomInOut = 0;
    }*/
}

