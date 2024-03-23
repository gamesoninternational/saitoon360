using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoManager : MonoBehaviour
{
    public int TotalPhoto;
    public int CountPhoto;
    // Start is called before the first frame update
    void Start()
    {
        CountPhoto = PlayerPrefs.GetInt("Save Count Photo");
    }

    // Update is called once per frame
    void Update()
    {
        if(CountPhoto == TotalPhoto){
            //Photo Terkumpul
            Debug.Log("Photo Terkumpul");
        }
    }
}
