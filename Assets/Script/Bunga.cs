using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunga : MonoBehaviour
{
    public GameObject BungaButton, BungaObj;

    public GameObject BungaManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectBunga(){
        BungaButton.SetActive(false);
        BungaObj.SetActive(true);
        BungaManagerScript.GetComponent<BungaManager>().BungaCount++;
    }
}
