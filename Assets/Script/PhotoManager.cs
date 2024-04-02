using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhotoManager : MonoBehaviour
{
    public int TotalPhoto;
    public int CountPhoto;

    public TextMeshProUGUI CountPhotoText;
    public GameObject TaskItemObj, TaskManagerObj, PhotoAsli;

    public bool SekaliPanggil;
    // Start is called before the first frame update
    void Start()
    {
        CountPhoto = PlayerPrefs.GetInt("Save Count Photo");
    }

    // Update is called once per frame
    void Update()
    {
        CountPhotoText.text = CountPhoto.ToString();
        if(CountPhoto == TotalPhoto){
            //Photo Terkumpul
            PhotoAsli.SetActive(true);
        }
    }

    public void PhotoTerkumpul(){
        if(CountPhoto == TotalPhoto){
            //Photo Terkumpul
            Debug.Log("Photo Terkumpul");
            TaskItemObj.GetComponent<TaskItem>().TaskSelesai();
            PlayerPrefs.SetInt("Save Count Task", TaskManagerObj.GetComponent<TaskManager>().TaskCount);
            
        }
    }
}
