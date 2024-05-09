using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour
{
    public GameObject StoryObj;
    public int show;
    // Start is called before the first frame update
    void Start()
    {
        show = PlayerPrefs.GetInt("SaveStory");
        if (show == 1){
            StoryObj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndStory(){
        show = 1;
        PlayerPrefs.SetInt("SaveStory", show);
    }

    public void OpenStory(){
        show = 0;
        PlayerPrefs.SetInt("SaveStory", show);
    }
}
