using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoItem : MonoBehaviour
{
    public int SavePhoto;
    public GameObject Photo, PotonganPhoto, PhotoManagerObj;
    public string NamaPhoto;
    // Start is called before the first frame update
    void Start()
    {
        SavePhoto = PlayerPrefs.GetInt(NamaPhoto);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r")){
            PlayerPrefs.DeleteAll();
            Application.LoadLevel("Main");
        }

        if(SavePhoto == 1){
            Photo.SetActive(true);
            PotonganPhoto.SetActive(false);
        }
    }

    public void SelectPhoto(){
        SavePhoto = 1;
        PlayerPrefs.SetInt(NamaPhoto, SavePhoto);
        PhotoManagerObj.GetComponent<PhotoManager>().CountPhoto++;
        PlayerPrefs.SetInt("Save Count Photo", PhotoManagerObj.GetComponent<PhotoManager>().CountPhoto);
    }
}
