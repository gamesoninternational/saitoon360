using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LupTrigger : MonoBehaviour
{
    public GameObject LupObj;
    public GameObject FinishObj, UISuccess, Jumpscare, LineObj, TaskItemObj, TaskManagerObj;

    public GameObject Canvas1, Canvas2, Canvas3;

    public Animator CamAnim;

    public float StartPositionX, StartPositionY, StartPositionZ;
    public float StartRotationX, StartRotationY, StartRotationZ;
    // Start is called before the first frame update
    void Start()
    {
        //LupObj.transform.position = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Done"))
        {
            
            FinishObj.SetActive(false);
            UISuccess.SetActive(true);
            LineObj.SetActive(false);
            TaskItemObj.GetComponent<TaskItem>().TaskSelesai();
            PlayerPrefs.SetInt("Save Count Task", TaskManagerObj.GetComponent<TaskManager>().TaskCount);
        }

        if (other.CompareTag("ObstacleOut"))
        {
            Debug.Log("Stay on the Line");
        }
        if (other.CompareTag("ObstacleObj"))
        {
            Debug.Log("Jumpscare");
            Jumpscare.SetActive(true);
            CamAnim.SetTrigger("Jumpscare");
            StartCoroutine(AfterJumpscare());
            FinishObj.SetActive(false);
            Canvas1.SetActive(false);
            Canvas2.SetActive(false);
            Canvas3.SetActive(false);
            
        }

        
    }

    public void RestartGame(){
        LupObj.transform.position = new Vector3(StartPositionX, StartPositionY, StartPositionZ);
        LupObj.transform.eulerAngles = new Vector3(StartRotationX, StartRotationY, StartRotationZ);
        FinishObj.SetActive(true);
        UISuccess.SetActive(false);
        //Jumpscare.GetComponent<VidPlayer>().StopVideo();
        Jumpscare.SetActive(false);

        Canvas1.SetActive(true);
        Canvas2.SetActive(true);
        Canvas3.SetActive(true);

        
    }

    IEnumerator AfterJumpscare(){
        yield return new WaitForSeconds(4f);
        RestartGame();
    }
}
