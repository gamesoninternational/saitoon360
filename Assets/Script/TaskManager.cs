using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public int TotalTask;
    public int TaskCount;

    public TextMeshProUGUI CountTaskText;

    public GameObject EndGameObj;
    // Start is called before the first frame update
    void Start()
    {
        TaskCount = PlayerPrefs.GetInt("Save Count Task");
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown("t")){
            TaskCount++;
        }*/
        CountTaskText.text = TaskCount.ToString();
        if (TaskCount == TotalTask){
            //Task Selesai
            EndGameObj.SetActive(true);
        }
    }

    


}
