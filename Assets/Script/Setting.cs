using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public GameObject MainCanvas;
    public GameObject AudioGame;
    // Start is called before the first frame update
    void Start()
    {
        AudioGame = GameObject.FindGameObjectWithTag("AudioObj");
        MainCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MuteSound(){
        AudioGame.GetComponent<AudioSource>().mute = true;
    }

    public void UnMuteSound(){
        AudioGame.GetComponent<AudioSource>().mute = false;
    }
}
