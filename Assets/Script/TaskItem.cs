using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskItem : MonoBehaviour
{
    public int TaskSelesai;
    public GameObject CheckObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TaskSelesai == 1){
            CheckObj.SetActive(true);
        }
    }
}
