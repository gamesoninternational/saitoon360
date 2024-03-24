using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskItem : MonoBehaviour
{
    public int SaveTask;
    public string NamaTask;
    public GameObject CheckObj, TaskManagerObj;

    public GameObject ItemObj;
    // Start is called before the first frame update
    void Start()
    {
        SaveTask = PlayerPrefs.GetInt(NamaTask);
    }

    // Update is called once per frame
    void Update()
    {
        if(SaveTask == 1){
            CheckObj.SetActive(true);
            ItemObj.SetActive(false);
        }

        if (Input.GetKeyDown("t")){
            
            
        }
    }

    public void TaskSelesai(){
        SaveTask = 1;
        PlayerPrefs.SetInt(NamaTask, SaveTask);

        TaskManagerObj.GetComponent<TaskManager>().TaskCount++;
        PlayerPrefs.SetInt("Save Count Task", TaskManagerObj.GetComponent<TaskManager>().TaskCount);
        
    }
}
