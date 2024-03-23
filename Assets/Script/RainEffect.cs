using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainEffect : MonoBehaviour
{
    public GameObject RainEffectObj;
    public bool RainEffectActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(RainEffectActive == true){
            RainEffectObj.SetActive(true);
        }
        if(RainEffectActive == false){
            RainEffectObj.SetActive(false);
        }
    }
}
